#Region "版 本 注 释 "
' ----------------------------------------------------------------
' 项目名称 ：MouseRec_VB
' 项目描述 ：Recording for VB.NET
' 类 名 称 ：SystemHook
' 类 描 述 ：钩子
' 命名空间 ：MouseRec_VB
' CLR 版本 ：4.0
' 作    者 ：fesugar
' 邮    箱 ：fesugar@fesugar.com
' 创建时间 ：12:42 2020/3/16
' 更新时间 ：12:42 2020/3/16
' 版 本 号 ：v1.0.0.0
' 参考文献 ：博客: http://hi.baidu.com/clso
'            论坛: http://clso.xuntan.com
' *****************************************************************
' * Copyright @ fesugar.com 2020. All rights reserved.
' *****************************************************************
' ----------------------------------------------------------------*
#End Region

Imports System.Reflection, System.Threading, System.ComponentModel, System.Runtime.InteropServices
''' <summary>本类可以在.NET环境下使用系统键盘与鼠标钩子</summary>
Public Class SystemHook
#Region "定义结构"
    Private Structure MouseHookStruct
        Dim PT As Point
        Dim Hwnd As Integer
        Dim WHitTestCode As Integer
        Dim DwExtraInfo As Integer
    End Structure
    Private Structure MouseLLHookStruct
        Dim PT As Point
        Dim MouseData As Integer
        Dim Flags As Integer
        Dim Time As Integer
        Dim DwExtraInfo As Integer
    End Structure
    Private Structure KeyboardHookStruct
        Dim vkCode As Integer
        Dim ScanCode As Integer
        Dim Flags As Integer
        Dim Time As Integer
        Dim DwExtraInfo As Integer
    End Structure
#End Region
#Region "API声明导入"
    Private Declare Function SetWindowsHookExA Lib "user32" (ByVal idHook As Integer, ByVal lpfn As HookProc, ByVal hMod As IntPtr, ByVal dwThreadId As Integer) As Integer
    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal idHook As Integer) As Integer
    Private Declare Function CallNextHookEx Lib "user32" (ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
    Private Declare Function ToAscii Lib "user32" (ByVal uVirtKey As Integer, ByVal uScancode As Integer, ByVal lpdKeyState As Byte(), ByVal lpwTransKey As Byte(), ByVal fuState As Integer) As Integer
    Private Declare Function GetKeyboardState Lib "user32" (ByVal pbKeyState As Byte()) As Integer
    Private Declare Function GetKeyState Lib "user32" (ByVal vKey As Integer) As Short
    Private Delegate Function HookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
#End Region
#Region "常量声明"
    Private Const WH_MOUSE_LL = 14
    Private Const WH_KEYBOARD_LL = 13
    Private Const WH_MOUSE = 7
    Private Const WH_KEYBOARD = 2
    Private Const WM_MOUSEMOVE = &H200
    Private Const WM_LBUTTONDOWN = &H201
    Private Const WM_RBUTTONDOWN = &H204
    Private Const WM_MBUTTONDOWN = &H207
    Private Const WM_LBUTTONUP = &H202
    Private Const WM_RBUTTONUP = &H205
    Private Const WM_MBUTTONUP = &H208
    Private Const WM_LBUTTONDBLCLK = &H203
    Private Const WM_RBUTTONDBLCLK = &H206
    Private Const WM_MBUTTONDBLCLK = &H209
    Private Const WM_MOUSEWHEEL = &H20A
    Private Const WM_KEYDOWN = &H100
    Private Const WM_KEYUP = &H101
    Private Const WM_SYSKEYDOWN = &H104
    Private Const WM_SYSKEYUP = &H105
    Private Const VK_SHIFT As Byte = &H10
    Private Const VK_CAPITAL As Byte = &H14
    Private Const VK_NUMLOCK As Byte = &H90
#End Region
    ''' <summary>鼠标激活事件</summary>
    Public Event MouseActivity As MouseEventHandler
    ''' <summary>键盘按下事件</summary>
    Public Event KeyDown As KeyEventHandler
    ''' <summary>键盘输入事件</summary>
    Public Event KeyPress As KeyPressEventHandler
    ''' <summary>键盘松开事件</summary>
    Public Event KeyUp As KeyEventHandler
    Private hMouseHook As Integer
    Private hKeyboardHook As Integer
    Private Shared MouseHookProcedure As HookProc
    Private Shared KeyboardHookProcedure As HookProc
    ''' <summary>创建一个全局鼠标键盘钩子 (请使用Start方法开始监视)</summary>
    Sub New()
        '留空即可
    End Sub
    ''' <summary>创建一个全局鼠标键盘钩子，决定是否安装钩子</summary>
    ''' <param name="InstallAll">是否立刻挂钩系统消息</param>
    Sub New(ByVal InstallAll As Boolean)
        If InstallAll Then StartHook(True, True)
    End Sub
    ''' <summary>创建一个全局鼠标键盘钩子，并决定安装钩子的类型</summary>
    ''' <param name="InstallKeyboard">挂钩键盘消息</param>
    ''' <param name="InstallMouse">挂钩鼠标消息</param>
    Sub New(ByVal InstallKeyboard As Boolean, ByVal InstallMouse As Boolean)
        StartHook(InstallKeyboard, InstallMouse)
    End Sub
    ''' <summary>析构函数</summary>
    Protected Overrides Sub Finalize()
        UnHook() '卸载对象时反注册系统钩子
        MyBase.Finalize()
    End Sub
    ''' <summary>开始安装系统钩子</summary>
    ''' <param name="InstallKeyboardHook">挂钩键盘消息</param>
    ''' <param name="InstallMouseHook">挂钩鼠标消息</param>
    Public Sub StartHook(Optional ByVal InstallKeyboardHook As Boolean = True, Optional ByVal InstallMouseHook As Boolean = False)
        '注册键盘钩子
        If InstallKeyboardHook AndAlso hKeyboardHook = 0 Then
            KeyboardHookProcedure = New HookProc(AddressOf KeyboardHookProc)
            hKeyboardHook = SetWindowsHookExA(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly.GetModules()(0)), 0)
            If hKeyboardHook = 0 Then '检测是否注册完成
                UnHook(True, False) '在这里反注册
                Throw New Win32Exception(Marshal.GetLastWin32Error) '报告错误
            End If
        End If
        '注册鼠标钩子
        If InstallMouseHook AndAlso hMouseHook = 0 Then
            MouseHookProcedure = New HookProc(AddressOf MouseHookProc)
            hMouseHook = SetWindowsHookExA(WH_MOUSE_LL, MouseHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly.GetModules()(0)), 0)
            If hMouseHook = 0 Then
                UnHook(False, True)
                Throw New Win32Exception(Marshal.GetLastWin32Error)
            End If
        End If
    End Sub
    ''' <summary>立刻卸载系统钩子</summary>
    ''' <param name="UninstallKeyboardHook">卸载键盘钩子</param>
    ''' <param name="UninstallMouseHook">卸载鼠标钩子</param>
    ''' <param name="ThrowExceptions">是否报告错误</param>
    Public Sub UnHook(Optional ByVal UninstallKeyboardHook As Boolean = True, Optional ByVal UninstallMouseHook As Boolean = True, Optional ByVal ThrowExceptions As Boolean = False)
        '卸载键盘钩子
        If hKeyboardHook <> 0 AndAlso UninstallKeyboardHook Then
            Dim retKeyboard As Integer = UnhookWindowsHookEx(hKeyboardHook)
            hKeyboardHook = 0
            If ThrowExceptions AndAlso retKeyboard = 0 Then '如果出现错误，是否报告错误
                Throw New Win32Exception(Marshal.GetLastWin32Error) '报告错误
            End If
        End If
        '卸载鼠标钩子
        If hMouseHook <> 0 AndAlso UninstallMouseHook Then
            Dim retMouse As Integer = UnhookWindowsHookEx(hMouseHook)
            hMouseHook = 0
            If ThrowExceptions AndAlso retMouse = 0 Then
                Throw New Win32Exception(Marshal.GetLastWin32Error)
            End If
        End If
    End Sub
    '键盘消息的委托处理代码
    Private Function KeyboardHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        Dim handled As Boolean = False
        If nCode >= 0 Then
            Dim MyKeyboardHookStruct As KeyboardHookStruct = DirectCast(Marshal.PtrToStructure(lParam, GetType(KeyboardHookStruct)), KeyboardHookStruct)
            '激活KeyDown
            If wParam = WM_KEYDOWN OrElse wParam = WM_SYSKEYDOWN Then '如果消息为按下普通键或系统键
                Dim e As New KeyEventArgs(MyKeyboardHookStruct.vkCode)
                RaiseEvent KeyDown(Me, e) '激活事件
                handled = handled Or e.Handled '是否取消下一个钩子
            End If
            '激活KeyUp
            If wParam = WM_KEYUP OrElse wParam = WM_SYSKEYUP Then
                Dim e As New KeyEventArgs(MyKeyboardHookStruct.vkCode)
                RaiseEvent KeyUp(Me, e)
                handled = handled Or e.Handled
            End If
            '激活KeyPress
            If wParam = WM_KEYDOWN Then
                Dim isDownShift As Boolean = (GetKeyState(VK_SHIFT) & &H80 = &H80)
                Dim isDownCapslock As Boolean = (GetKeyState(VK_CAPITAL) <> 0)
                Dim keyState(256) As Byte
                GetKeyboardState(keyState)
                Dim inBuffer(2) As Byte
                If ToAscii(MyKeyboardHookStruct.vkCode, MyKeyboardHookStruct.ScanCode, keyState, inBuffer, MyKeyboardHookStruct.Flags) = 1 Then
                    Dim key As Char = Chr(inBuffer(0))
                    If isDownCapslock Xor isDownShift And Char.IsLetter(key) Then
                        key = Char.ToUpper(key)
                    End If
                    Dim e As New KeyPressEventArgs(key)
                    RaiseEvent KeyPress(Me, e)
                    handled = handled Or e.Handled
                End If
            End If
            '取消或者激活下一个钩子
            If handled Then Return 1 Else Return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam)
        End If
    End Function
    '鼠标消息的委托处理代码
    Private Function MouseHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        If nCode >= 0 Then
            Dim mouseHookStruct As MouseLLHookStruct = DirectCast(Marshal.PtrToStructure(lParam, GetType(MouseLLHookStruct)), MouseLLHookStruct)
            Dim moubut As MouseButtons = MouseButtons.None '鼠标按键
            Dim mouseDelta As Integer = 0 '滚轮值
            Select Case wParam
                Case WM_LBUTTONDOWN
                    moubut = MouseButtons.Left
                Case WM_RBUTTONDOWN
                    moubut = MouseButtons.Right
                Case WM_MBUTTONDOWN
                    moubut = MouseButtons.Middle
                Case WM_MOUSEWHEEL
                    Dim int As Integer = (mouseHookStruct.MouseData >> 16) And &HFFFF
                    '本段代码CLE添加，模仿C#的Short从Int弃位转换
                    If int > Short.MaxValue Then mouseDelta = int - 65536 Else mouseDelta = int
            End Select
            Dim clickCount As Integer = 0 '单击次数
            If moubut <> MouseButtons.None Then
                If wParam = WM_LBUTTONDBLCLK OrElse wParam = WM_RBUTTONDBLCLK OrElse wParam = WM_MBUTTONDBLCLK Then
                    clickCount = 2
                Else
                    clickCount = 1
                End If
            End If
            Dim e As New MouseEventArgs(moubut, clickCount, mouseHookStruct.PT.X, mouseHookStruct.PT.Y, mouseDelta)
            RaiseEvent MouseActivity(Me, e)
        End If
        Return CallNextHookEx(hMouseHook, nCode, wParam, lParam) '激活下一个钩子
    End Function
    ''' <summary>键盘钩子是否无效</summary>
    Public Property KeyHookInvalid() As Boolean
        Get
            Return hKeyboardHook = 0
        End Get
        Set(ByVal value As Boolean)
            If value Then UnHook(True, False) Else StartHook(True, False)
        End Set
    End Property
    ''' <summary>鼠标钩子是否无效</summary>
    Public Property MouseHookInvalid() As Boolean
        Get
            Return hMouseHook = 0
        End Get
        Set(ByVal value As Boolean)
            If value Then UnHook(False, True) Else StartHook(False, True)
        End Set
    End Property
End Class