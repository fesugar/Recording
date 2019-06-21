Imports System.ComponentModel

Public Class Form1
    ''' <summary>
    ''' 声明鼠标操作库
    ''' </summary>
    ReadOnly Io_Api = New io_apis.Io_Api

    Dim WithEvents MyHook As New SystemHook

    ''' <summary>
    ''' 初始化
    ''' </summary>
    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Initia_()
        MetroToolTip1.SetToolTip(Button1, "~~录制鼠标点击时坐标和动作~~")
        MetroToolTip1.SetToolTip(Button2, "~~回放录制的鼠标点击动作~~")
        MetroToolTip1.SetToolTip(Button3, "~~重置当前所有记录~~")
        MetroToolTip1.SetToolTip(Label4, "~~停止快捷热键~~")
        MetroToolTip1.SetToolTip(NumericUpDown1, "~~设置每次鼠标点击动作间隔时间~~")
        MetroToolTip1.SetToolTip(CheckBox1, "~~选中状态，会一直重复~~")
        Label5.Text = Nothing

        '禁用 1 2 3 4 列筛选功能 
        MetroGrid1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        MetroGrid1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        MetroGrid1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        MetroGrid1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        '设置label5 位置大小
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Size = New System.Drawing.Size(450, 450)
        ' 重绘label5 为圆
        Dim btnPath = New System.Drawing.Drawing2D.GraphicsPath()
        btnPath.AddEllipse(New Rectangle(90, 105, 150, 150))
        Label5.Region = New System.Drawing.Region(btnPath)
    End Sub
    ''' <summary>
    ''' 录制按钮事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Button1.Tag = 0 Then  '0 未启动状态
            Button1.Tag = 1
            Button1.Text = "录制中-再次点击停止"
            MetroLabel1.Text = "状态：录制中... ..."
            MyHook.StartHook(False, True)
            Button2.Enabled = False
        ElseIf Button1.Tag = 1 Then  '1 启动状态
            Button1.Tag = 0
            Button1.Text = "停止中-再次点击录制"
            MetroLabel1.Text = "状态：停止录制"
            MyHook.UnHook()
            Button2.Enabled = True

        End If

        If BackgroundWorker1.WorkerSupportsCancellation = True Then
            ' Cancel the asynchronous operation.
            BackgroundWorker1.CancelAsync()
        Else
            Button2.Text = "录制回放"  '当未运行任务会导致无法置于默认值，此处添加恢复默认内容
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            MetroGrid1.Rows(i - 1).Cells(0).Value = rn - i + 1
        Next

        MetroGrid1.Refresh()
    End Sub
    ''' <summary>
    ''' 回放按钮事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim i, j As Integer
        'For i = 0 To DataGridView1.RowCount - 1
        '    For j = 0 To DataGridView1.ColumnCount - 1
        '        MsgBox(DataGridView1.Item(j, i).Value)
        '    Next
        'Next
        If MetroGrid1.Rows.GetRowCount(0) = 0 Then Return

        If Me.Button2.Tag = 0 Then

            If CheckBox1.CheckState <> CheckState.Checked Then CheckBox1.Enabled = False
            MetroLabel1.Text = "状态：回放中... ..."
            If BackgroundWorker1.IsBusy <> True Then
                ' Start the asynchronous operation.
                BackgroundWorker1.RunWorkerAsync()
                Button2.Tag = 1
                Button2.Text = "回放中-再次点击停止"
                MyHook.StartHook(True, False)
                Label4.Visible = True
            End If

        ElseIf Button2.Tag = 1 Then
            If CheckBox1.CheckState <> CheckState.Checked Then CheckBox1.Enabled = False
            If BackgroundWorker1.WorkerSupportsCancellation = True Then
                ' Cancel the asynchronous operation.
                BackgroundWorker1.CancelAsync()
                Button2.Tag = 0
                Button2.Text = "停止中-再次点击回放"
                MyHook.UnHook()
                Label4.Visible = False
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
        Label5.Text = data
    End Sub

    ' This event handler is where the time-consuming work is done.
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object,
    ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

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
        If CheckBox1.CheckState = CheckState.Unchecked Then
            GoTo NoWhile '跳转
        Else
            While CheckBox1.CheckState = CheckState.Checked
                For i = MetroGrid1.RowCount - 1 To 0 Step -1
                    If (worker.CancellationPending = True) Then
                        e.Cancel = True
                        Exit Sub
                    Else
                        str1 = MetroGrid1.Item(1, i).Value
                        fengge = Split(str1, ",")


                        Io_Api.mouse_move(CInt(fengge(0)), CInt(fengge(1)))
                        If MetroGrid1.Item(2, i).Value.ToString = "Left" Then Io_Api.mouse_click()

                        If MetroGrid1.Item(2, i).Value.ToString = "Left" Then Io_Api.mouse_click()
                        If MetroGrid1.Item(2, i).Value.ToString = "Right" Then Io_Api.mouse_click("R")
                        If MetroGrid1.Item(2, i).Value.ToString = "Middle" Then Io_Api.mouse_click("M")

                        For j = 0 To CInt(MetroGrid1.Item(3, i - 1).Value)
                            If (worker.CancellationPending = True) Then
                                e.Cancel = True
                                Exit Sub
                            Else
                                ' Perform a time consuming operation and report progress.
                                System.Threading.Thread.Sleep(1000)
                                worker.ReportProgress((j / CInt(MetroGrid1.Item(3, i - 1).Value) * 100))
                            End If
                        Next


                    End If
                Next
            End While
            Exit Sub '===
        End If


NoWhile:
        For i = MetroGrid1.RowCount - 1 To 0 Step -1
            If (worker.CancellationPending = True) Then
                e.Cancel = True
                Exit Sub
            Else
                str1 = MetroGrid1.Item(1, i).Value
                fengge = Split(str1, ",")
                Io_Api.mouse_move(CInt(fengge(0)), CInt(fengge(1)))

                If MetroGrid1.Item(2, i).Value.ToString = "Left" Then Io_Api.mouse_click()
                If MetroGrid1.Item(2, i).Value.ToString = "Right" Then Io_Api.mouse_click("R")
                If MetroGrid1.Item(2, i).Value.ToString = "Middle" Then Io_Api.mouse_click("M")

                For j = 0 To CInt(MetroGrid1.Item(3, i - 1).Value) 'i-1 用来修正已经执行完最后一个点击功能后，会继续循环一次设置的耗时，这个耗时是多余的
                    If (worker.CancellationPending = True) Then
                        e.Cancel = True
                        Exit Sub
                    Else
                        ' Perform a time consuming operation and report progress.
                        System.Threading.Thread.Sleep(1000)
                        worker.ReportProgress((j / CInt(MetroGrid1.Item(3, i - 1).Value) * 100))
                    End If
                Next

            End If

        Next
    End Sub

    ' This event handler updates the progress.
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object,
    ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        GroupBox1.Text = "预览 == 下次点击等待时间百分比" + (e.ProgressPercentage.ToString() + "%")
    End Sub

    ' This event handler deals with the results of the background operation.
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object,
    ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            MetroLabel1.Text = "状态： 已终止回放"
        ElseIf e.Error IsNot Nothing Then
            MetroLabel1.Text = "状态： " & e.Error.Message
        Else
            MetroLabel1.Text = "状态： 已完成回放"
        End If
        Button2.Text = "动作回放"
        Me.Button2.Tag = 0
        GroupBox1.Text = "预览 "
        CheckBox1.Enabled = True
        Label4.Visible = False
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            CheckBox1.Text = "已启用循环回放"
        Else
            CheckBox1.Text = "已停用循环回放"
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
        If Button1.ContainsFocus = True Then Return '录制按钮有焦点不录制自身
        Label2.Text = String.Format("光标位置：{0},{1}", MousePosition.X, MousePosition.Y)


        Select Case Control.MouseButtons
            Case MouseButtons.Left

            Case MouseButtons.Middle

            Case MouseButtons.Right
            Case Else
                Exit Sub
        End Select

        Dim Index As Integer = MetroGrid1.Rows.Add()
        MetroGrid1.Rows（Index）.Cells（0）.Value = Index + 1
        MetroGrid1.Rows（Index）.Cells（1）.Value = String.Format("{0},{1}", MousePosition.X, MousePosition.Y)
        MetroGrid1.Rows(Index).Cells(2）.Value = Control.MouseButtons
        MetroGrid1.Rows(Index).Cells（3）.Value = NumericUpDown1.Value

        'addnum(DataGridView1.RowCount)

        'DataGridView1.Rows(0).Add(2, String.Format("{0},{1}", MousePosition.X, MousePosition.Y))

        MetroGrid1.Sort(MetroGrid1.Columns（0）, ListSortDirection.Descending)

        'DataGridView1.Rows(0).Cells(1).Value = Label2.Text
        '  DataGridView1.Rows.Item.AppendText(String.Format（"坐标 X{0},Y{1} 在{2}时操作左键单击{3}", MousePosition.X, MousePosition.Y, DateTime.Now.ToLongTimeString, vbNewLine))

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MetroGrid1.Rows.Clear()
        Initia_()
    End Sub

    Public Sub Initia_()
        If BackgroundWorker1.WorkerSupportsCancellation = True Then BackgroundWorker1.CancelAsync()
        Me.Button1.Tag = 0
        Me.Button2.Tag = 0
        Me.Button2.Enabled = False
        'DataGridView1.TopLeftHeaderCell.Value = "序号"
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        MetroLabel1.Text = "状态：初始化完成"
        ' CheckBox1.Enabled = False '功能开发中
        CheckBox1.CheckState = CheckState.Unchecked
        Me.Button1.Text = "录制动作"
        Me.Button2.Text = "动作回放"
        MyHook.UnHook()
        Label4.Visible = False
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MyHook.MouseHookInvalid = False Then MyHook.UnHook()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.fesugar.com/")
    End Sub


    Private Sub Bt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyHook.KeyDown
        '   If (e.KeyCode = Keys.V And e.Control) Then  全局下 组合按键不行了

        If e.KeyCode = Keys.F8 Then Me.Button2.PerformClick()

        '  If e.Control And e.KeyCode = Keys.V Then e.SuppressKeyPress = False '允许Ctrl+V

    End Sub

    '删除条事件
    Private Sub MetroGrid1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles MetroGrid1.UserDeletedRow
        '解决删除后序号不连续问题
        Addnum(MetroGrid1.Rows.Count)
    End Sub

End Class
