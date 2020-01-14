<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits MetroFramework.Forms.MetroForm

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.grpPreview = New System.Windows.Forms.GroupBox()
        Me.lblCountdown = New System.Windows.Forms.Label()
        Me.btnReset = New MetroFramework.Controls.MetroButton()
        Me.chkLoop = New MetroFramework.Controls.MetroCheckBox()
        Me.nudSecond = New System.Windows.Forms.NumericUpDown()
        Me.lblInterval = New MetroFramework.Controls.MetroLabel()
        Me.lblCursorPosition = New MetroFramework.Controls.MetroLabel()
        Me.btnRecording = New MetroFramework.Controls.MetroButton()
        Me.lblLog = New MetroFramework.Controls.MetroLabel()
        Me.btnPlayback = New MetroFramework.Controls.MetroButton()
        Me.bgwRun = New System.ComponentModel.BackgroundWorker()
        Me.grpExplain = New System.Windows.Forms.GroupBox()
        Me.llbExplain = New System.Windows.Forms.LinkLabel()
        Me.lblHotkey = New MetroFramework.Controls.MetroLabel()
        Me.dgvRec = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mousebutton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.interval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MetrocmsRec = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.ToolStripMenuItemImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetrolblState = New MetroFramework.Controls.MetroLabel()
        Me.MetropnlState = New MetroFramework.Controls.MetroPanel()
        Me.MetrotipAll = New MetroFramework.Components.MetroToolTip()
        Me.grpPreview.SuspendLayout()
        CType(Me.nudSecond, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExplain.SuspendLayout()
        CType(Me.dgvRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MetrocmsRec.SuspendLayout()
        Me.MetropnlState.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpPreview
        '
        Me.grpPreview.Controls.Add(Me.lblCountdown)
        Me.grpPreview.Controls.Add(Me.btnReset)
        Me.grpPreview.Controls.Add(Me.chkLoop)
        Me.grpPreview.Controls.Add(Me.nudSecond)
        Me.grpPreview.Controls.Add(Me.lblInterval)
        Me.grpPreview.Controls.Add(Me.lblCursorPosition)
        Me.grpPreview.Location = New System.Drawing.Point(12, 170)
        Me.grpPreview.Name = "grpPreview"
        Me.grpPreview.Size = New System.Drawing.Size(401, 115)
        Me.grpPreview.TabIndex = 0
        Me.grpPreview.TabStop = False
        Me.grpPreview.Text = "预览"
        '
        'lblCountdown
        '
        Me.lblCountdown.AutoSize = True
        Me.lblCountdown.BackColor = System.Drawing.Color.Transparent
        Me.lblCountdown.Font = New System.Drawing.Font("宋体", 70.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblCountdown.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCountdown.Location = New System.Drawing.Point(125, 0)
        Me.lblCountdown.Name = "lblCountdown"
        Me.lblCountdown.Size = New System.Drawing.Size(109, 117)
        Me.lblCountdown.TabIndex = 12
        Me.lblCountdown.Text = "3"
        Me.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReset
        '
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.Location = New System.Drawing.Point(310, 20)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(70, 29)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "重置"
        Me.btnReset.UseSelectable = True
        '
        'chkLoop
        '
        Me.chkLoop.AutoSize = True
        Me.chkLoop.Location = New System.Drawing.Point(220, 82)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(136, 17)
        Me.chkLoop.Style = MetroFramework.MetroColorStyle.Orange
        Me.chkLoop.TabIndex = 7
        Me.chkLoop.Text = "已停用循环回放"
        Me.chkLoop.UseSelectable = True
        '
        'nudSecond
        '
        Me.nudSecond.Location = New System.Drawing.Point(16, 82)
        Me.nudSecond.Maximum = New Decimal(New Integer() {86400, 0, 0, 0})
        Me.nudSecond.Name = "nudSecond"
        Me.nudSecond.Size = New System.Drawing.Size(109, 25)
        Me.nudSecond.TabIndex = 3
        Me.nudSecond.TabStop = False
        Me.nudSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudSecond.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Location = New System.Drawing.Point(11, 54)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(114, 20)
        Me.lblInterval.TabIndex = 1
        Me.lblInterval.Text = "间隔时间（秒）"
        '
        'lblCursorPosition
        '
        Me.lblCursorPosition.AutoSize = True
        Me.lblCursorPosition.Location = New System.Drawing.Point(11, 25)
        Me.lblCursorPosition.Name = "lblCursorPosition"
        Me.lblCursorPosition.Size = New System.Drawing.Size(84, 20)
        Me.lblCursorPosition.TabIndex = 0
        Me.lblCursorPosition.Text = "光标位置："
        '
        'btnRecording
        '
        Me.btnRecording.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecording.Location = New System.Drawing.Point(12, 85)
        Me.btnRecording.Name = "btnRecording"
        Me.btnRecording.Size = New System.Drawing.Size(214, 30)
        Me.btnRecording.TabIndex = 2
        Me.btnRecording.Text = "录制动作"
        Me.btnRecording.UseSelectable = True
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(12, 289)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(69, 20)
        Me.lblLog.TabIndex = 3
        Me.lblLog.Text = "操作日志"
        '
        'btnPlayback
        '
        Me.btnPlayback.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPlayback.Location = New System.Drawing.Point(12, 128)
        Me.btnPlayback.Name = "btnPlayback"
        Me.btnPlayback.Size = New System.Drawing.Size(214, 31)
        Me.btnPlayback.TabIndex = 4
        Me.btnPlayback.Text = "动作回放"
        Me.btnPlayback.UseSelectable = True
        '
        'bgwRun
        '
        '
        'grpExplain
        '
        Me.grpExplain.Controls.Add(Me.llbExplain)
        Me.grpExplain.Location = New System.Drawing.Point(267, 85)
        Me.grpExplain.Name = "grpExplain"
        Me.grpExplain.Size = New System.Drawing.Size(146, 79)
        Me.grpExplain.TabIndex = 7
        Me.grpExplain.TabStop = False
        Me.grpExplain.Text = "说明"
        '
        'llbExplain
        '
        Me.llbExplain.LinkArea = New System.Windows.Forms.LinkArea(19, 30)
        Me.llbExplain.Location = New System.Drawing.Point(6, 21)
        Me.llbExplain.Name = "llbExplain"
        Me.llbExplain.Size = New System.Drawing.Size(134, 53)
        Me.llbExplain.TabIndex = 9
        Me.llbExplain.TabStop = True
        Me.llbExplain.Text = "录制鼠标动作进行回放   - by  fesugar.com"
        Me.llbExplain.UseCompatibleTextRendering = True
        '
        'lblHotkey
        '
        Me.lblHotkey.AutoSize = True
        Me.lblHotkey.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.lblHotkey.Location = New System.Drawing.Point(232, 128)
        Me.lblHotkey.Name = "lblHotkey"
        Me.lblHotkey.Size = New System.Drawing.Size(24, 20)
        Me.lblHotkey.TabIndex = 8
        Me.lblHotkey.Text = "F8"
        Me.lblHotkey.Visible = False
        '
        'dgvRec
        '
        Me.dgvRec.AllowUserToAddRows = False
        Me.dgvRec.AllowUserToResizeRows = False
        Me.dgvRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRec.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvRec.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.position, Me.mousebutton, Me.interval})
        Me.dgvRec.ContextMenuStrip = Me.MetrocmsRec
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRec.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRec.EnableHeadersVisualStyles = False
        Me.dgvRec.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.dgvRec.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvRec.Location = New System.Drawing.Point(12, 312)
        Me.dgvRec.MultiSelect = False
        Me.dgvRec.Name = "dgvRec"
        Me.dgvRec.ReadOnly = True
        Me.dgvRec.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRec.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRec.RowHeadersWidth = 51
        Me.dgvRec.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvRec.RowTemplate.Height = 27
        Me.dgvRec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRec.Size = New System.Drawing.Size(401, 147)
        Me.dgvRec.TabIndex = 9
        '
        'id
        '
        Me.id.HeaderText = "序号"
        Me.id.MinimumWidth = 6
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 61
        '
        'position
        '
        Me.position.HeaderText = "坐标"
        Me.position.MinimumWidth = 6
        Me.position.Name = "position"
        Me.position.ReadOnly = True
        Me.position.Width = 61
        '
        'mousebutton
        '
        Me.mousebutton.HeaderText = "按键"
        Me.mousebutton.MinimumWidth = 6
        Me.mousebutton.Name = "mousebutton"
        Me.mousebutton.ReadOnly = True
        Me.mousebutton.Width = 61
        '
        'interval
        '
        Me.interval.HeaderText = "间隔（秒）"
        Me.interval.MinimumWidth = 6
        Me.interval.Name = "interval"
        Me.interval.ReadOnly = True
        '
        'MetrocmsRec
        '
        Me.MetrocmsRec.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MetrocmsRec.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemImport, Me.ToolStripMenuItemExport})
        Me.MetrocmsRec.Name = "MetroContextMenu1"
        Me.MetrocmsRec.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MetrocmsRec.ShowImageMargin = False
        Me.MetrocmsRec.Size = New System.Drawing.Size(114, 52)
        '
        'ToolStripMenuItemImport
        '
        Me.ToolStripMenuItemImport.Name = "ToolStripMenuItemImport"
        Me.ToolStripMenuItemImport.Size = New System.Drawing.Size(113, 24)
        Me.ToolStripMenuItemImport.Text = "载入记录"
        '
        'ToolStripMenuItemExport
        '
        Me.ToolStripMenuItemExport.Name = "ToolStripMenuItemExport"
        Me.ToolStripMenuItemExport.Size = New System.Drawing.Size(113, 24)
        Me.ToolStripMenuItemExport.Text = "保存记录"
        '
        'MetrolblState
        '
        Me.MetrolblState.AutoSize = True
        Me.MetrolblState.Location = New System.Drawing.Point(3, 6)
        Me.MetrolblState.Name = "MetrolblState"
        Me.MetrolblState.Size = New System.Drawing.Size(84, 20)
        Me.MetrolblState.TabIndex = 10
        Me.MetrolblState.Text = "MetroLabel1"
        '
        'MetropnlState
        '
        Me.MetropnlState.Controls.Add(Me.MetrolblState)
        Me.MetropnlState.HorizontalScrollbarBarColor = True
        Me.MetropnlState.HorizontalScrollbarHighlightOnWheel = False
        Me.MetropnlState.HorizontalScrollbarSize = 10
        Me.MetropnlState.Location = New System.Drawing.Point(1, 465)
        Me.MetropnlState.Name = "MetropnlState"
        Me.MetropnlState.Size = New System.Drawing.Size(426, 32)
        Me.MetropnlState.TabIndex = 11
        Me.MetropnlState.VerticalScrollbarBarColor = True
        Me.MetropnlState.VerticalScrollbarHighlightOnWheel = False
        Me.MetropnlState.VerticalScrollbarSize = 10
        '
        'MetrotipAll
        '
        Me.MetrotipAll.Style = MetroFramework.MetroColorStyle.[Default]
        Me.MetrotipAll.StyleManager = Nothing
        Me.MetrotipAll.Theme = MetroFramework.MetroThemeStyle.Light
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 497)
        Me.Controls.Add(Me.MetropnlState)
        Me.Controls.Add(Me.dgvRec)
        Me.Controls.Add(Me.lblHotkey)
        Me.Controls.Add(Me.grpExplain)
        Me.Controls.Add(Me.btnPlayback)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.btnRecording)
        Me.Controls.Add(Me.grpPreview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.Opacity = 0.97R
        Me.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow
        Me.Style = MetroFramework.MetroColorStyle.Lime
        Me.Text = "鼠标动作录制工具"
        Me.TopMost = True
        Me.grpPreview.ResumeLayout(False)
        Me.grpPreview.PerformLayout()
        CType(Me.nudSecond, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExplain.ResumeLayout(False)
        CType(Me.dgvRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MetrocmsRec.ResumeLayout(False)
        Me.MetropnlState.ResumeLayout(False)
        Me.MetropnlState.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpPreview As GroupBox
    Friend WithEvents nudSecond As NumericUpDown
    Friend WithEvents bgwRun As System.ComponentModel.BackgroundWorker
    Friend WithEvents grpExplain As GroupBox
    Friend WithEvents llbExplain As LinkLabel
    Friend WithEvents btnRecording As MetroFramework.Controls.MetroButton
    Friend WithEvents btnPlayback As MetroFramework.Controls.MetroButton
    Friend WithEvents btnReset As MetroFramework.Controls.MetroButton
    Friend WithEvents chkLoop As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents lblLog As MetroFramework.Controls.MetroLabel
    Friend WithEvents lblCursorPosition As MetroFramework.Controls.MetroLabel
    Friend WithEvents lblInterval As MetroFramework.Controls.MetroLabel
    Friend WithEvents lblHotkey As MetroFramework.Controls.MetroLabel
    Friend WithEvents dgvRec As System.Windows.Forms.DataGridView
    Friend WithEvents MetrolblState As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetropnlState As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetrotipAll As MetroFramework.Components.MetroToolTip
    Friend WithEvents lblCountdown As Label
    Friend WithEvents MetrocmsRec As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents ToolStripMenuItemImport As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemExport As ToolStripMenuItem
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents position As DataGridViewTextBoxColumn
    Friend WithEvents mousebutton As DataGridViewTextBoxColumn
    Friend WithEvents interval As DataGridViewTextBoxColumn
End Class
