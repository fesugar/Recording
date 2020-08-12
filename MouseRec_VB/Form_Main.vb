#Region "版 本 注 释 "
' ----------------------------------------------------------------
' 项目名称 ：MouseRec_VB
' 项目描述 ：Recording for VB.NET
' 类 名 称 ：Form_Main
' 类 描 述 ：主窗体
' 命名空间 ：MouseRec_VB
' CLR 版本 ：4.0
' 作    者 ：fesugar
' 邮    箱 ：fesugar@fesugar.com
' 创建时间 ：12:42 2020/3/16
' 更新时间 ：12:42 2020/3/16
' 版 本 号 ：v1.0.0.0
' 参考文献 ：
' *****************************************************************
' * Copyright @ fesugar.com 2020. All rights reserved.
' *****************************************************************
' ----------------------------------------------------------------*
#End Region

Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema

Public Class Form_Main
    ''' <summary>
    ''' 声明鼠标操作库
    ''' </summary>
    ReadOnly Io_Api_hook = New Io_Api.Io_hook

    Dim WithEvents MyHook As New SystemHook

    ''' <summary>
    ''' 初始化
    ''' </summary>
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Initia_()
        MetrotipAll.SetToolTip(btnRecording, "~~录制鼠标点击时坐标和动作~~")
        MetrotipAll.SetToolTip(btnPlayback, "~~回放录制的鼠标点击动作~~")
        MetrotipAll.SetToolTip(btnReset, "~~重置当前所有记录~~")
        MetrotipAll.SetToolTip(lblHotkey, "~~停止快捷热键~~")
        MetrotipAll.SetToolTip(nudSecond, "~~设置每次鼠标点击动作间隔时间~~")

        lblCountdown.Text = Nothing

        '禁用 1 2 3 4 列筛选功能 
        dgvRec.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvRec.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvRec.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvRec.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        '设置label5 位置大小
        ' Me.Label5.Location = New System.Drawing.Point(0, 0)
        'Me.Label5.Size = New System.Drawing.Size(350, 450)
        ' 重绘label5 为圆
        'Dim btnPath = New System.Drawing.Drawing2D.GraphicsPath()
        'btnPath.AddEllipse(New Rectangle(90, 150, 150, 150))
        'Label5.Region = New System.Drawing.Region(btnPath)
    End Sub
    ''' <summary>
    ''' 录制按钮事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnRecording_Click(sender As Object, e As EventArgs) Handles btnRecording.Click
        If Me.btnRecording.Tag = 0 Then  '0 未启动状态
            btnRecording.Tag = 1
            btnRecording.Text = "录制中-再次点击停止"
            MetrolblState.Text = "状态：录制中... ..."
            MyHook.StartHook(False, True)
            btnPlayback.Enabled = False
        ElseIf btnRecording.Tag = 1 Then  '1 启动状态
            btnRecording.Tag = 0
            btnRecording.Text = "停止中-再次点击录制"
            MetrolblState.Text = "状态：停止录制"
            MyHook.UnHook()
            btnPlayback.Enabled = True

        End If

        If bgwRun.WorkerSupportsCancellation = True Then
            ' Cancel the asynchronous operation.
            bgwRun.CancelAsync()
        Else
            btnPlayback.Text = "录制回放"  '当未运行任务会导致无法置于默认值，此处添加恢复默认内容
        End If

    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim unused = MsgBox(String.Format("{0},{1}", MousePosition.X, MousePosition.Y))
        ' Io_Api.mouse_click("L", True)
        ' Io_Api.mouse_move(33, 88)
        'AddHandler MyHook.MouseActivity, AddressOf MouseAct
        'MyHook.StartHook(False, True)
#If DEBUG Then
        MsgBox(My.Application.Info.Version.ToString)
#Else
        Me.Text = "鼠标动作录制工具-v" & My.Application.Info.Version.Major.ToString

#End If

    End Sub
    '用以在MetroGrid1 自动添加序号栏目
    Sub Addnum(ByVal rn As Integer)
        Dim i As Integer
        For i = 1 To rn
            dgvRec.Rows(i - 1).Cells(0).Value = rn - i + 1
        Next

        dgvRec.Refresh()
    End Sub
    ''' <summary>
    ''' 回放按钮事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnPlayback_Click(sender As Object, e As EventArgs) Handles btnPlayback.Click
        'Dim i, j As Integer
        'For i = 0 To DataGridView1.RowCount - 1
        '    For j = 0 To DataGridView1.ColumnCount - 1
        '        MsgBox(DataGridView1.Item(j, i).Value)
        '    Next
        'Next
        If dgvRec.Rows.GetRowCount(0) = 0 Then Return

        If Me.btnPlayback.Tag = 0 Then

            If chkLoop.CheckState <> CheckState.Checked Then chkLoop.Enabled = False
            MetrolblState.Text = "状态：回放中... ..."
            If bgwRun.IsBusy <> True Then
                ' Start the asynchronous operation.
                bgwRun.RunWorkerAsync()
                btnPlayback.Tag = 1
                btnPlayback.Text = "回放中-再次点击停止"
                MyHook.StartHook(True, False)
                lblHotkey.Visible = True
            End If

        ElseIf btnPlayback.Tag = 1 Then
            If chkLoop.CheckState <> CheckState.Checked Then chkLoop.Enabled = False
            If bgwRun.WorkerSupportsCancellation = True Then
                ' Cancel the asynchronous operation.
                bgwRun.CancelAsync()
                btnPlayback.Tag = 0
                btnPlayback.Text = "停止中-再次点击回放"
                MyHook.UnHook()
                lblHotkey.Visible = False
            End If
        End If

    End Sub

    Delegate Sub Gxdjs(data As String) '定义委托
    ''' <summary>
    ''' 被委托的中间类
    ''' </summary>
    Private Sub Djs(n As String)
        Me.Invoke(New Gxdjs(AddressOf Cdjs), n) '用Invoke跨线程更新UI
    End Sub

    Private Sub Cdjs(data As String) '这里要和委托定义时的参数保持一致
        lblCountdown.Text = data
    End Sub

    ' This event handler is where the time-consuming work is done.
    Private Sub BgwRun_DoWork(ByVal sender As System.Object,
    ByVal e As DoWorkEventArgs) Handles bgwRun.DoWork
        Djs("③")
        System.Threading.Thread.Sleep(1000)
        Djs("②")
        System.Threading.Thread.Sleep(1000)
        Djs("①")
        System.Threading.Thread.Sleep(1000)
        Djs(Nothing)
        On Error Resume Next
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim fengge() As String
        Dim str1 As String
        Dim i, j As Integer
        If chkLoop.CheckState = CheckState.Unchecked Then
            GoTo NoWhile '跳转
        Else
            While chkLoop.CheckState = CheckState.Checked
                For i = dgvRec.RowCount - 1 To 0 Step -1
                    If (worker.CancellationPending = True) Then
                        e.Cancel = True
                        Exit Sub
                    Else
                        str1 = dgvRec.Item(1, i).Value
                        fengge = Split(str1, ",")


                        Io_Api_hook.mouse_move(CInt(fengge(0)), CInt(fengge(1)))
                        If dgvRec.Item(2, i).Value.ToString = "Left" Then Io_Api_hook.mouse_click()

                        If dgvRec.Item(2, i).Value.ToString = "Left" Then Io_Api_hook.mouse_click()
                        If dgvRec.Item(2, i).Value.ToString = "Right" Then Io_Api_hook.mouse_click("R")
                        If dgvRec.Item(2, i).Value.ToString = "Middle" Then Io_Api_hook.mouse_click("M")

                        dgvRec.ClearSelection()
                        'dgvRec.CurrentCell = dgvRec.Rows(i).Cells(0) '设置选中单独一列突出显示
                        dgvRec.Rows(i).Selected = True ' 设置被操作的行为选中
                        dgvRec.FirstDisplayedScrollingRowIndex = i

                        For j = 0 To CInt(dgvRec.Item(3, i - 1).Value)
                            If (worker.CancellationPending = True) Then
                                e.Cancel = True
                                Exit Sub
                            Else
                                ' Perform a time consuming operation and report progress.
                                System.Threading.Thread.Sleep(1000)
                                worker.ReportProgress((j / CInt(dgvRec.Item(3, i - 1).Value) * 100))
                            End If
                        Next


                    End If
                Next
            End While
            Exit Sub '===
        End If


NoWhile:
        For i = dgvRec.RowCount - 1 To 0 Step -1
            If (worker.CancellationPending = True) Then
                e.Cancel = True
                Exit Sub
            Else
                str1 = dgvRec.Item(1, i).Value
                fengge = Split(str1, ",")
                Io_Api_hook.mouse_move(CInt(fengge(0)), CInt(fengge(1)))

                If dgvRec.Item(2, i).Value.ToString = "Left" Then Io_Api_hook.mouse_click()
                If dgvRec.Item(2, i).Value.ToString = "Right" Then Io_Api_hook.mouse_click("R")
                If dgvRec.Item(2, i).Value.ToString = "Middle" Then Io_Api_hook.mouse_click("M")

                dgvRec.ClearSelection()
                'dgvRec.CurrentCell = dgvRec.Rows(i).Cells(0) '设置选中单独一列突出显示
                dgvRec.Rows(i).Selected = True ' 设置被操作的行为选中
                dgvRec.FirstDisplayedScrollingRowIndex = i

                For j = 0 To CInt(dgvRec.Item(3, i - 1).Value)
                    ' i-1 用来修正已经执行完最后一个点击功能后，
                    ' 会继续循环一次设置的耗时， 这个耗时是多余的
                    If (worker.CancellationPending = True) Then
                        e.Cancel = True
                        Exit Sub
                    Else
                        ' Perform a time consuming operation and report progress.
                        System.Threading.Thread.Sleep(1000)
                        worker.ReportProgress((j / CInt(dgvRec.Item(3, i - 1).Value) * 100))
                    End If
                Next

            End If

        Next
    End Sub

    ' This event handler updates the progress.
    Private Sub BgwRun_ProgressChanged(ByVal sender As System.Object,
    ByVal e As ProgressChangedEventArgs) Handles bgwRun.ProgressChanged
        grpPreview.Text = "预览 == 距离下一操作等待时间百分比" + (e.ProgressPercentage.ToString() + "%")
    End Sub

    ' This event handler deals with the results of the background operation.
    Private Sub BgwRun_RunWorkerCompleted(ByVal sender As System.Object,
    ByVal e As RunWorkerCompletedEventArgs) Handles bgwRun.RunWorkerCompleted
        If e.Cancelled = True Then
            MetrolblState.Text = "状态： 已终止回放"
        ElseIf e.Error IsNot Nothing Then
            MetrolblState.Text = "状态： " & e.Error.Message
        Else
            MetrolblState.Text = "状态： 已完成回放"
        End If
        btnPlayback.Text = "动作回放"
        Me.btnPlayback.Tag = 0
        grpPreview.Text = "预览 "
        chkLoop.Enabled = True
        lblHotkey.Visible = False
    End Sub

    Private Sub ChkLoop_CheckStateChanged(sender As Object, e As EventArgs) Handles chkLoop.CheckStateChanged
        If chkLoop.CheckState = CheckState.Checked Then
            chkLoop.Text = "已启用循环回放"
        Else
            chkLoop.Text = "已停用循环回放"
        End If
    End Sub
    'Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)
    'Public Const MOUSEEVENTF_LEFTDOWN = &H2 '模拟鼠标左键按下
    'Public Const MOUSEEVENTF_LEFTUP = &H4 '模拟鼠标左键释放
    'Public Const MOUSEEVENTF_MIDDLEDOWN = &H20 '模拟鼠标中间键按下
    'Public Const MOUSEEVENTF_MIDDLEUP = &H40 '模拟鼠标中间键释放
    'Public Const MOUSEEVENTF_RIGHTDOWN = &H8 '模拟鼠标右键按下
    'Public Const MOUSEEVENTF_RIGHTUP = &H10 '模拟鼠标右键释放
    'Public Const MOUSEEVENTF_MOVE = &H1 '模拟鼠标指针移动
    '        '在（10，10）模拟鼠标左键按下 
    '    mouse_event(MOUSEEVENTF_LEFTDOWN, 10, 10, 0, 0)

    Private Sub MouseAct(sender As Object, e As MouseEventArgs) Handles MyHook.MouseActivity
        '  If btnRecording.ContainsFocus = True Then Return '录制按钮有焦点不录制自身
        If MousePosition.X > Me.Location.X And
            MousePosition.X < Me.Location.X + Me.Width And
            MousePosition.Y > Me.Location.Y And
            MousePosition.Y < Me.Location.Y + Me.Height Then Return
        '屏幕位置在程序窗体中操作点击不记录

        lblCursorPosition.Text = String.Format("光标位置：{0},{1}", MousePosition.X, MousePosition.Y)


        Select Case Control.MouseButtons
            Case MouseButtons.Left

            Case MouseButtons.Middle

            Case MouseButtons.Right
            Case Else
                Exit Sub
        End Select

        Dim Index As Integer = dgvRec.Rows.Add()
        dgvRec.Rows（Index）.Cells（0）.Value = Index + 1
        dgvRec.Rows（Index）.Cells（1）.Value = String.Format("{0},{1}", MousePosition.X, MousePosition.Y)
        dgvRec.Rows(Index).Cells(2）.Value = Control.MouseButtons
        dgvRec.Rows(Index).Cells（3）.Value = nudSecond.Value
        'addnum(DataGridView1.RowCount)

        'DataGridView1.Rows(0).Add(2, String.Format("{0},{1}", MousePosition.X, MousePosition.Y))
        dgvRec.Sort(dgvRec.Columns（"id"）, ListSortDirection.Descending)

        'DataGridView1.Rows(0).Cells(1).Value = Label2.Text
        '  DataGridView1.Rows.Item.AppendText(String.Format（"坐标 X{0},Y{1} 在{2}时操作左键单击{3}", MousePosition.X, MousePosition.Y, DateTime.Now.ToLongTimeString, vbNewLine))

    End Sub


    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dgvRec.Rows.Clear()
        Initia_()
    End Sub

    Public Sub Initia_()
        If bgwRun.WorkerSupportsCancellation = True Then bgwRun.CancelAsync()
        Me.btnRecording.Enabled = True
        Me.btnRecording.Tag = 0
        Me.btnPlayback.Tag = 0
        Me.btnPlayback.Enabled = False
        'DataGridView1.TopLeftHeaderCell.Value = "序号"
        bgwRun.WorkerReportsProgress = True
        bgwRun.WorkerSupportsCancellation = True
        MetrolblState.Text = "状态：初始化完成"
        ' CheckBox1.Enabled = False '功能开发中
        chkLoop.CheckState = CheckState.Unchecked
        Me.btnRecording.Text = "录制动作"
        Me.btnPlayback.Text = "动作回放"
        MyHook.UnHook()
        lblHotkey.Visible = False
    End Sub

    Private Sub FormMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MyHook.MouseHookInvalid = False Then MyHook.UnHook()
    End Sub

    Private Sub LlbExplain_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbExplain.LinkClicked
        System.Diagnostics.Process.Start("http://www.fesugar.com/")
    End Sub


    Private Sub Bt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyHook.KeyDown
        '   If (e.KeyCode = Keys.V And e.Control) Then  全局下 组合按键不行了

        If e.KeyCode = Keys.F8 Then Me.btnPlayback.PerformClick()

        '  If e.Control And e.KeyCode = Keys.V Then e.SuppressKeyPress = False '允许Ctrl+V

    End Sub

    '删除条事件
    Private Sub DgvRec_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgvRec.UserDeletedRow
        '解决删除后序号不连续问题
        Addnum(dgvRec.Rows.Count)
    End Sub

    Private xml_FilePath As String '用来记录当前打开文件的路径的


    ''' <summary>
    ''' 右键菜单导出记录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripMenuItemExport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExport.Click
        Try

            If dgvRec.Rows.Count > 0 Then

                Dim f = New SaveFileDialog With {
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments,
                    .Filter = "XML数据 (*.xml)|*.xml|所有文件(*.*)|*>**",
                    .FilterIndex = 1,
                    .RestoreDirectory = True
                }
                If f.ShowDialog = DialogResult.OK And f.FileName.Length > 0 Then
                    '保存csv

                    '        Dim document As New XmlDocument
                    '        If (Me.xml_FilePath <> "") Then
                    '            document.Load(Me.xml_FilePath)
                    '            Dim xmlElement_MouseRec As XmlNode = document.SelectSingleNode("MouseRec")
                    '            xmlElement_MouseRec.RemoveAll()
                    '            Dim row As Integer = MetrodgvRec.Rows.Count
                    '            Dim cell As Integer = MetrodgvRec.Rows.Item(1).Cells.Count
                    '            Dim i As Integer
                    '            For i = 0 To (row - 1) - 1
                    '                Dim xmlElement_event As XmlElement = document.CreateElement("event")
                    '                Dim xmlElement_id As XmlElement = document.CreateElement("id")
                    '                xmlElement_id.InnerText = MetrodgvRec.Rows.Item(i).Cells.Item(0).Value.ToString
                    '                xmlElement_event.AppendChild(xmlElement_id)
                    '                Dim xmlElement_position As XmlElement = document.CreateElement("position")
                    '                xmlElement_position.InnerText = MetrodgvRec.Rows.Item(i).Cells.Item(1).Value.ToString
                    '                xmlElement_event.AppendChild(xmlElement_position)
                    '                Dim xmlElement_mousebutton As XmlElement = document.CreateElement("mousebutton")
                    '                xmlElement_mousebutton.InnerText = MetrodgvRec.Rows.Item(i).Cells.Item(2).Value.ToString
                    '                xmlElement_event.AppendChild(xmlElement_mousebutton)
                    '                Dim xmlElement_interval As XmlElement = document.CreateElement("interval")
                    '                xmlElement_interval.InnerText = MetrodgvRec.Rows.Item(i).Cells.Item(3).Value.ToString
                    '                xmlElement_event.AppendChild(xmlElement_interval)
                    '                xmlElement_MouseRec.AppendChild(xmlElement_event)
                    '            Next i
                    '            document.Save(Me.xml_FilePath)
                    '        Else
                    '            Dim dialog As New SaveFileDialog With {
                    '    .Filter = "xml文件(*.xml)|*.xml"
                    '}
                    '            If (dialog.ShowDialog = DialogResult.OK) Then
                    '                Dim xmlElement_MouseRec As XmlElement = document.CreateElement("MouseRec")
                    '                Dim row As Integer = MetrodgvRec.Rows.Count
                    '                Dim i As Integer
                    '                For i = 0 To (row - 1) - 1
                    '                    Dim xmlElement_event As XmlElement = document.CreateElement("event")
                    '                    Dim xmlElement_id As XmlElement = document.CreateElement("id")
                    '                    xmlElement_id.InnerText = MetrodgvRec.Rows.Item(i).Cells.Item(0).Value.ToString
                    '                    xmlElement_event.AppendChild(xmlElement_id)
                    '                    Dim xmlElement_position As XmlElement = document.CreateElement("position")
                    '                    xmlElement_position.InnerText = MetrodgvRec.Rows.Item(i).Cells.Item(1).Value.ToString
                    '                    xmlElement_event.AppendChild(xmlElement_position)
                    '                    Dim xmlElement_mousebutton As XmlElement = document.CreateElement("mousebutton")
                    '                    xmlElement_mousebutton.InnerText = MetrodgvRec.Rows.Item(i).Cells.Item(2).Value.ToString
                    '                    xmlElement_event.AppendChild(xmlElement_mousebutton)
                    '                    Dim xmlElement_interval As XmlElement = document.CreateElement("interval")
                    '                    xmlElement_interval.InnerText = MetrodgvRec.Rows.Item(i).Cells.Item(3).Value.ToString
                    '                    xmlElement_event.AppendChild(xmlElement_interval)
                    '                    xmlElement_MouseRec.AppendChild(xmlElement_event)
                    '                Next i
                    '                document.AppendChild(document.CreateXmlDeclaration("1.0", "utf-8", ""))
                    '                document.AppendChild(xmlElement_MouseRec)
                    '                document.Save(dialog.FileName)

                    '            End If
                    '        End If
                    Me.xml_FilePath = f.FileName
                    Dim document As New XmlDocument
                    Dim xmlElement_MouseRec As XmlElement = document.CreateElement("MouseRec")
                    Dim row As Integer = dgvRec.Rows.Count
                    Dim i As Integer
                    For i = 0 To (row - 1)
                        Dim xmlElement_event As XmlElement = document.CreateElement("event")
                        Dim xmlElement_id As XmlElement = document.CreateElement("id")
                        xmlElement_id.InnerText = dgvRec.Rows.Item(i).Cells.Item(0).Value.ToString
                        xmlElement_event.AppendChild(xmlElement_id)
                        Dim xmlElement_position As XmlElement = document.CreateElement("position")
                        xmlElement_position.InnerText = dgvRec.Rows.Item(i).Cells.Item(1).Value.ToString
                        xmlElement_event.AppendChild(xmlElement_position)
                        Dim xmlElement_mousebutton As XmlElement = document.CreateElement("mousebutton")
                        xmlElement_mousebutton.InnerText = dgvRec.Rows.Item(i).Cells.Item(2).Value.ToString
                        xmlElement_event.AppendChild(xmlElement_mousebutton)
                        Dim xmlElement_interval As XmlElement = document.CreateElement("interval")
                        xmlElement_interval.InnerText = dgvRec.Rows.Item(i).Cells.Item(3).Value.ToString
                        xmlElement_event.AppendChild(xmlElement_interval)
                        xmlElement_MouseRec.AppendChild(xmlElement_event)
                    Next i
                    document.AppendChild(document.CreateXmlDeclaration("1.0", "utf-8", ""))
                    document.AppendChild(xmlElement_MouseRec)
                    document.Save(Me.xml_FilePath)

                    MetroFramework.MetroMessageBox.Show(Me, vbLf + "文件已存储成功！", "保存文件！", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Else

                MetroFramework.MetroMessageBox.Show(Me, vbLf + "没有可用的数据导出", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, vbLf + Err.Description + vbLf + Err.Source + vbLf + Err.Number.ToString, "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' 右键菜单载入记录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolStripMenuItemImport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemImport.Click
        Try

            If dgvRec.Rows.Count > 0 Then
                If MetroFramework.MetroMessageBox.Show(Me, vbLf + "发现当前存在数据，确定导入并清空已有数据吗？", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then Exit Sub

            End If

            Dim f = New OpenFileDialog With {
                .Multiselect = False
                }
            If f.ShowDialog() = DialogResult.OK Then
                ' Dim filepath = f.FileName '文件路径  
                'Dim filename = f.SafeFileName '文件名 不含路径    

                If Xmlvalidate(f.FileName) = False Then '验证 xml 是否合
                    MetroFramework.MetroMessageBox.Show(Me, vbLf + "导入的数据格式错误，请选择正确的格式重试。", "格式错误！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                '读取CSV文件到DataGridView控件
                Me.xml_FilePath = f.FileName
                Dim xmlDocument As New XmlDocument
                xmlDocument.Load(Me.xml_FilePath)
                Dim xmlNodeList As XmlNodeList = xmlDocument.SelectSingleNode("MouseRec").ChildNodes
                dgvRec.Rows.Clear() '清空数据
                Initia_() '初始化所有控件状态
                Dim xmlNode As XmlNode
                For Each xmlNode In xmlNodeList
                    Dim element As XmlElement = DirectCast(xmlNode, XmlElement)
                    Dim index As Integer = dgvRec.Rows.Add
                    dgvRec.Rows.Item(index).Cells.Item(0).Value = element.ChildNodes.Item(0).InnerText
                    dgvRec.Rows.Item(index).Cells.Item(1).Value = element.ChildNodes.Item(1).InnerText
                    dgvRec.Rows.Item(index).Cells.Item(2).Value = element.ChildNodes.Item(2).InnerText
                    dgvRec.Rows.Item(index).Cells.Item(3).Value = element.ChildNodes.Item(3).InnerText
                Next
                BtnRecording_Click(Me, e) '操作录制按钮更改回放按钮状态
                BtnRecording_Click(Me, e) '停止录制按钮
                btnRecording.Enabled = False '禁用录制功能 '排序未解决

            End If
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(Me, vbLf + Err.Description + vbLf + Err.Source + vbLf + Err.Number.ToString, "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MetrocmsRec_Opening(sender As Object, e As CancelEventArgs) Handles MetrocmsRec.Opening
        If btnRecording.Tag = 1 Then  '1 启动状态
            btnRecording.Tag = 0
            btnRecording.Text = "停止中-再次点击录制"
            MetrolblState.Text = "状态：停止录制"
            MyHook.UnHook()
            btnPlayback.Enabled = True

        End If
    End Sub

    REM 验证  xsd 开始
    REM https://docs.microsoft.com/zh-cn/dotnet/api/system.xml.schema.extensions.validate?redirectedfrom=MSDN&view=netframework-4.8

    Dim errors As Boolean = False

    Private Sub XSDErrors(ByVal o As Object, ByVal e As ValidationEventArgs)
        Console.WriteLine("{0}", e.Message)
        errors = True
    End Sub
    Private Function Xmlvalidate(xmlurl As String) As Boolean
        Dim xsdMarkup As XDocument =
        <?xml version="1.0" encoding="utf-8"?>
        <xs:schema id="MouseRec" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
            <xs:element name="MouseRec" msdata:IsDataSet="true" msdata:Locale="en-US">
                <xs:complexType>
                    <xs:choice minOccurs="0" maxOccurs="unbounded">
                        <xs:element name="event">
                            <xs:complexType>
                                <xs:sequence>
                                    <xs:element name="id" type="xs:string" minOccurs="0"/>
                                    <xs:element name="position" type="xs:string" minOccurs="0"/>
                                    <xs:element name="mousebutton" type="xs:string" minOccurs="0"/>
                                    <xs:element name="interval" type="xs:string" minOccurs="0"/>
                                </xs:sequence>
                            </xs:complexType>
                        </xs:element>
                    </xs:choice>
                </xs:complexType>
            </xs:element>
        </xs:schema>

        Dim schemas As XmlSchemaSet = New XmlSchemaSet()
        schemas.Add("", xsdMarkup.CreateReader)

        Dim doc1 As XDocument = XDocument.Load(xmlurl)

        Console.WriteLine("Validating doc1")
        errors = False
        doc1.Validate(schemas, AddressOf XSDErrors)
        Return IIf(errors, False, True)
    End Function

    REM 验证  xsd 结束
End Class
