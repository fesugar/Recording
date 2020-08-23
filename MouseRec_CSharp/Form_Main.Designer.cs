namespace MouseRec_CSharp
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.MetrotipAll = new MetroFramework.Components.MetroToolTip();
            this.MetrolblState = new MetroFramework.Controls.MetroLabel();
            this.ToolStripMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.MetrocmsRec = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MetropnlState = new MetroFramework.Controls.MetroPanel();
            this.dgvRec = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mousebutton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doubleclick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHotkey = new MetroFramework.Controls.MetroLabel();
            this.llbExplain = new System.Windows.Forms.LinkLabel();
            this.bgwRun = new System.ComponentModel.BackgroundWorker();
            this.btnPlayback = new MetroFramework.Controls.MetroButton();
            this.lblLog = new MetroFramework.Controls.MetroLabel();
            this.btnRecording = new MetroFramework.Controls.MetroButton();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.btnReset = new MetroFramework.Controls.MetroButton();
            this.chkLoop = new MetroFramework.Controls.MetroCheckBox();
            this.nudSecond = new System.Windows.Forms.NumericUpDown();
            this.lblInterval = new MetroFramework.Controls.MetroLabel();
            this.lblCursorPosition = new MetroFramework.Controls.MetroLabel();
            this.grpExplain = new System.Windows.Forms.GroupBox();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.chkTopmost = new MetroFramework.Controls.MetroCheckBox();
            this.metroLink_about = new MetroFramework.Controls.MetroLink();
            this.pl_about = new System.Windows.Forms.Panel();
            this.lbl_prpe = new System.Windows.Forms.Label();
            this.grp_donate = new System.Windows.Forms.GroupBox();
            this.lbl_WeChat = new System.Windows.Forms.Label();
            this.lbl_Alipay = new System.Windows.Forms.Label();
            this.pic_WeChat = new System.Windows.Forms.PictureBox();
            this.pic_Alipay = new System.Windows.Forms.PictureBox();
            this.lbl_author = new System.Windows.Forms.Label();
            this.lbl_buildtime = new System.Windows.Forms.Label();
            this.MetrocmsRec.SuspendLayout();
            this.MetropnlState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).BeginInit();
            this.grpExplain.SuspendLayout();
            this.grpPreview.SuspendLayout();
            this.pl_about.SuspendLayout();
            this.grp_donate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_WeChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Alipay)).BeginInit();
            this.SuspendLayout();
            // 
            // MetrotipAll
            // 
            this.MetrotipAll.Style = MetroFramework.MetroColorStyle.Default;
            this.MetrotipAll.StyleManager = null;
            this.MetrotipAll.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // MetrolblState
            // 
            this.MetrolblState.AutoSize = true;
            this.MetrolblState.Location = new System.Drawing.Point(3, 6);
            this.MetrolblState.Name = "MetrolblState";
            this.MetrolblState.Size = new System.Drawing.Size(84, 20);
            this.MetrolblState.TabIndex = 2;
            this.MetrolblState.Text = "MetroLabel1";
            // 
            // ToolStripMenuItemExport
            // 
            this.ToolStripMenuItemExport.Name = "ToolStripMenuItemExport";
            this.ToolStripMenuItemExport.Size = new System.Drawing.Size(128, 24);
            this.ToolStripMenuItemExport.Text = "保存记录";
            this.ToolStripMenuItemExport.Click += new System.EventHandler(this.ToolStripMenuItemExport_Click);
            // 
            // ToolStripMenuItemImport
            // 
            this.ToolStripMenuItemImport.Name = "ToolStripMenuItemImport";
            this.ToolStripMenuItemImport.Size = new System.Drawing.Size(128, 24);
            this.ToolStripMenuItemImport.Text = "载入记录";
            this.ToolStripMenuItemImport.Click += new System.EventHandler(this.ToolStripMenuItemImport_Click);
            // 
            // MetrocmsRec
            // 
            this.MetrocmsRec.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MetrocmsRec.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemImport,
            this.ToolStripMenuItemExport,
            this.toolStripSeparator1,
            this.toolStripMenuItemDelete});
            this.MetrocmsRec.Name = "MetroContextMenu1";
            this.MetrocmsRec.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MetrocmsRec.ShowImageMargin = false;
            this.MetrocmsRec.Size = new System.Drawing.Size(129, 82);
            this.MetrocmsRec.Opening += new System.ComponentModel.CancelEventHandler(this.MetrocmsRec_Opening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(128, 24);
            this.toolStripMenuItemDelete.Text = "删除选中行";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // MetropnlState
            // 
            this.MetropnlState.Controls.Add(this.MetrolblState);
            this.MetropnlState.HorizontalScrollbarBarColor = true;
            this.MetropnlState.HorizontalScrollbarHighlightOnWheel = false;
            this.MetropnlState.HorizontalScrollbarSize = 10;
            this.MetropnlState.Location = new System.Drawing.Point(1, 463);
            this.MetropnlState.Name = "MetropnlState";
            this.MetropnlState.Size = new System.Drawing.Size(426, 32);
            this.MetropnlState.TabIndex = 3;
            this.MetropnlState.VerticalScrollbarBarColor = true;
            this.MetropnlState.VerticalScrollbarHighlightOnWheel = false;
            this.MetropnlState.VerticalScrollbarSize = 10;
            // 
            // dgvRec
            // 
            this.dgvRec.AllowUserToAddRows = false;
            this.dgvRec.AllowUserToResizeRows = false;
            this.dgvRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRec.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvRec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRec.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.position,
            this.mousebutton,
            this.doubleclick,
            this.interval});
            this.dgvRec.ContextMenuStrip = this.MetrocmsRec;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRec.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRec.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvRec.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvRec.Location = new System.Drawing.Point(12, 312);
            this.dgvRec.MultiSelect = false;
            this.dgvRec.Name = "dgvRec";
            this.dgvRec.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRec.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRec.RowHeadersWidth = 51;
            this.dgvRec.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRec.RowTemplate.Height = 27;
            this.dgvRec.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRec.Size = new System.Drawing.Size(401, 147);
            this.dgvRec.TabIndex = 4;
            this.dgvRec.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvRec_UserDeletedRow);
            // 
            // id
            // 
            this.id.HeaderText = "序号";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 62;
            // 
            // position
            // 
            this.position.HeaderText = "坐标";
            this.position.MinimumWidth = 6;
            this.position.Name = "position";
            this.position.ReadOnly = true;
            this.position.Width = 62;
            // 
            // mousebutton
            // 
            this.mousebutton.HeaderText = "按键";
            this.mousebutton.MinimumWidth = 6;
            this.mousebutton.Name = "mousebutton";
            this.mousebutton.ReadOnly = true;
            this.mousebutton.Width = 62;
            // 
            // doubleclick
            // 
            this.doubleclick.HeaderText = "双击";
            this.doubleclick.MinimumWidth = 6;
            this.doubleclick.Name = "doubleclick";
            this.doubleclick.ReadOnly = true;
            this.doubleclick.Width = 62;
            // 
            // interval
            // 
            this.interval.HeaderText = "间隔 ( /10s )";
            this.interval.MinimumWidth = 6;
            this.interval.Name = "interval";
            this.interval.ReadOnly = true;
            this.interval.Width = 101;
            // 
            // lblHotkey
            // 
            this.lblHotkey.AutoSize = true;
            this.lblHotkey.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblHotkey.Location = new System.Drawing.Point(232, 126);
            this.lblHotkey.Name = "lblHotkey";
            this.lblHotkey.Size = new System.Drawing.Size(24, 20);
            this.lblHotkey.TabIndex = 5;
            this.lblHotkey.Text = "F8";
            this.lblHotkey.Visible = false;
            // 
            // llbExplain
            // 
            this.llbExplain.LinkArea = new System.Windows.Forms.LinkArea(19, 30);
            this.llbExplain.Location = new System.Drawing.Point(6, 21);
            this.llbExplain.Name = "llbExplain";
            this.llbExplain.Size = new System.Drawing.Size(134, 53);
            this.llbExplain.TabIndex = 0;
            this.llbExplain.TabStop = true;
            this.llbExplain.Text = "录制鼠标动作进行回放   - by  fesugar.com";
            this.llbExplain.UseCompatibleTextRendering = true;
            this.llbExplain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlbExplain_LinkClicked);
            // 
            // bgwRun
            // 
            this.bgwRun.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwRun_DoWork);
            this.bgwRun.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgwRun_ProgressChanged);
            this.bgwRun.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwRun_RunWorkerCompleted);
            // 
            // btnPlayback
            // 
            this.btnPlayback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayback.Location = new System.Drawing.Point(12, 126);
            this.btnPlayback.Name = "btnPlayback";
            this.btnPlayback.Size = new System.Drawing.Size(214, 31);
            this.btnPlayback.TabIndex = 6;
            this.btnPlayback.Text = "动作回放";
            this.btnPlayback.UseSelectable = true;
            this.btnPlayback.Click += new System.EventHandler(this.BtnPlayback_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(12, 287);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(69, 20);
            this.lblLog.TabIndex = 7;
            this.lblLog.Text = "操作日志";
            // 
            // btnRecording
            // 
            this.btnRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecording.Location = new System.Drawing.Point(12, 83);
            this.btnRecording.Name = "btnRecording";
            this.btnRecording.Size = new System.Drawing.Size(214, 30);
            this.btnRecording.TabIndex = 8;
            this.btnRecording.Text = "录制动作";
            this.btnRecording.UseSelectable = true;
            this.btnRecording.Click += new System.EventHandler(this.BtnRecording_Click);
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.BackColor = System.Drawing.Color.Transparent;
            this.lblCountdown.Font = new System.Drawing.Font("宋体", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCountdown.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCountdown.Location = new System.Drawing.Point(125, 0);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(109, 117);
            this.lblCountdown.TabIndex = 0;
            this.lblCountdown.Text = "3";
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Location = new System.Drawing.Point(310, 20);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 29);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重置";
            this.btnReset.UseSelectable = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Location = new System.Drawing.Point(220, 61);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(136, 17);
            this.chkLoop.Style = MetroFramework.MetroColorStyle.Orange;
            this.chkLoop.TabIndex = 2;
            this.chkLoop.Text = "已停用循环回放";
            this.chkLoop.UseSelectable = true;
            this.chkLoop.CheckStateChanged += new System.EventHandler(this.ChkLoop_CheckStateChanged);
            // 
            // nudSecond
            // 
            this.nudSecond.Cursor = System.Windows.Forms.Cursors.Default;
            this.nudSecond.Location = new System.Drawing.Point(16, 82);
            this.nudSecond.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.nudSecond.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudSecond.Name = "nudSecond";
            this.nudSecond.Size = new System.Drawing.Size(109, 25);
            this.nudSecond.TabIndex = 3;
            this.nudSecond.TabStop = false;
            this.nudSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSecond.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudSecond.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(11, 54);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(136, 20);
            this.lblInterval.TabIndex = 4;
            this.lblInterval.Text = "间隔时间（t/10秒）";
            // 
            // lblCursorPosition
            // 
            this.lblCursorPosition.AutoSize = true;
            this.lblCursorPosition.Location = new System.Drawing.Point(11, 25);
            this.lblCursorPosition.Name = "lblCursorPosition";
            this.lblCursorPosition.Size = new System.Drawing.Size(84, 20);
            this.lblCursorPosition.TabIndex = 5;
            this.lblCursorPosition.Text = "光标位置：";
            // 
            // grpExplain
            // 
            this.grpExplain.Controls.Add(this.llbExplain);
            this.grpExplain.Location = new System.Drawing.Point(267, 83);
            this.grpExplain.Name = "grpExplain";
            this.grpExplain.Size = new System.Drawing.Size(146, 79);
            this.grpExplain.TabIndex = 9;
            this.grpExplain.TabStop = false;
            this.grpExplain.Text = "说明";
            // 
            // grpPreview
            // 
            this.grpPreview.Controls.Add(this.lblCountdown);
            this.grpPreview.Controls.Add(this.btnReset);
            this.grpPreview.Controls.Add(this.chkLoop);
            this.grpPreview.Controls.Add(this.nudSecond);
            this.grpPreview.Controls.Add(this.lblInterval);
            this.grpPreview.Controls.Add(this.lblCursorPosition);
            this.grpPreview.Controls.Add(this.chkTopmost);
            this.grpPreview.Location = new System.Drawing.Point(12, 168);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Size = new System.Drawing.Size(401, 115);
            this.grpPreview.TabIndex = 10;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "预览";
            // 
            // chkTopmost
            // 
            this.chkTopmost.AutoSize = true;
            this.chkTopmost.Checked = true;
            this.chkTopmost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTopmost.Location = new System.Drawing.Point(220, 84);
            this.chkTopmost.Name = "chkTopmost";
            this.chkTopmost.Size = new System.Drawing.Size(136, 17);
            this.chkTopmost.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkTopmost.TabIndex = 6;
            this.chkTopmost.Text = "窗体总是在最前";
            this.chkTopmost.UseSelectable = true;
            this.chkTopmost.CheckStateChanged += new System.EventHandler(this.chkTopmost_CheckStateChanged);
            // 
            // metroLink_about
            // 
            this.metroLink_about.AutoSize = true;
            this.metroLink_about.Location = new System.Drawing.Point(267, 33);
            this.metroLink_about.Name = "metroLink_about";
            this.metroLink_about.Size = new System.Drawing.Size(57, 25);
            this.metroLink_about.TabIndex = 2;
            this.metroLink_about.Text = "About";
            this.metroLink_about.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLink_about.UseSelectable = true;
            this.metroLink_about.MouseEnter += new System.EventHandler(this.metroLink_about_MouseEnter);
            this.metroLink_about.MouseLeave += new System.EventHandler(this.metroLink_about_MouseLeave);
            // 
            // pl_about
            // 
            this.pl_about.BackColor = System.Drawing.Color.Silver;
            this.pl_about.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_about.Controls.Add(this.lbl_prpe);
            this.pl_about.Controls.Add(this.grp_donate);
            this.pl_about.Controls.Add(this.lbl_author);
            this.pl_about.Controls.Add(this.lbl_buildtime);
            this.pl_about.Location = new System.Drawing.Point(60, 74);
            this.pl_about.Name = "pl_about";
            this.pl_about.Size = new System.Drawing.Size(307, 348);
            this.pl_about.TabIndex = 1;
            this.pl_about.Visible = false;
            // 
            // lbl_prpe
            // 
            this.lbl_prpe.Location = new System.Drawing.Point(10, 71);
            this.lbl_prpe.Name = "lbl_prpe";
            this.lbl_prpe.Size = new System.Drawing.Size(290, 53);
            this.lbl_prpe.TabIndex = 0;
            this.lbl_prpe.Text = "Project    : ";
            // 
            // grp_donate
            // 
            this.grp_donate.Controls.Add(this.lbl_WeChat);
            this.grp_donate.Controls.Add(this.lbl_Alipay);
            this.grp_donate.Controls.Add(this.pic_WeChat);
            this.grp_donate.Controls.Add(this.pic_Alipay);
            this.grp_donate.Location = new System.Drawing.Point(7, 128);
            this.grp_donate.Name = "grp_donate";
            this.grp_donate.Size = new System.Drawing.Size(293, 209);
            this.grp_donate.TabIndex = 1;
            this.grp_donate.TabStop = false;
            this.grp_donate.Text = "Donate";
            // 
            // lbl_WeChat
            // 
            this.lbl_WeChat.AutoSize = true;
            this.lbl_WeChat.Location = new System.Drawing.Point(194, 172);
            this.lbl_WeChat.Name = "lbl_WeChat";
            this.lbl_WeChat.Size = new System.Drawing.Size(55, 15);
            this.lbl_WeChat.TabIndex = 0;
            this.lbl_WeChat.Text = "WeChat";
            // 
            // lbl_Alipay
            // 
            this.lbl_Alipay.AutoSize = true;
            this.lbl_Alipay.Location = new System.Drawing.Point(41, 172);
            this.lbl_Alipay.Name = "lbl_Alipay";
            this.lbl_Alipay.Size = new System.Drawing.Size(55, 15);
            this.lbl_Alipay.TabIndex = 1;
            this.lbl_Alipay.Text = "Alipay";
            // 
            // pic_WeChat
            // 
            this.pic_WeChat.Image = ((System.Drawing.Image)(resources.GetObject("pic_WeChat.Image")));
            this.pic_WeChat.Location = new System.Drawing.Point(153, 29);
            this.pic_WeChat.Name = "pic_WeChat";
            this.pic_WeChat.Size = new System.Drawing.Size(133, 133);
            this.pic_WeChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_WeChat.TabIndex = 2;
            this.pic_WeChat.TabStop = false;
            // 
            // pic_Alipay
            // 
            this.pic_Alipay.Image = ((System.Drawing.Image)(resources.GetObject("pic_Alipay.Image")));
            this.pic_Alipay.Location = new System.Drawing.Point(6, 29);
            this.pic_Alipay.Name = "pic_Alipay";
            this.pic_Alipay.Size = new System.Drawing.Size(133, 133);
            this.pic_Alipay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Alipay.TabIndex = 3;
            this.pic_Alipay.TabStop = false;
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Location = new System.Drawing.Point(10, 41);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(111, 15);
            this.lbl_author.TabIndex = 2;
            this.lbl_author.Text = "Author     : ";
            // 
            // lbl_buildtime
            // 
            this.lbl_buildtime.AutoSize = true;
            this.lbl_buildtime.Location = new System.Drawing.Point(10, 14);
            this.lbl_buildtime.Name = "lbl_buildtime";
            this.lbl_buildtime.Size = new System.Drawing.Size(111, 15);
            this.lbl_buildtime.TabIndex = 3;
            this.lbl_buildtime.Text = "Build time : ";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(426, 497);
            this.Controls.Add(this.pl_about);
            this.Controls.Add(this.metroLink_about);
            this.Controls.Add(this.MetropnlState);
            this.Controls.Add(this.dgvRec);
            this.Controls.Add(this.lblHotkey);
            this.Controls.Add(this.btnPlayback);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btnRecording);
            this.Controls.Add(this.grpExplain);
            this.Controls.Add(this.grpPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.Opacity = 0.97D;
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "鼠标动作录制工具";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Shown += new System.EventHandler(this.Form_Main_Shown);
            this.MetrocmsRec.ResumeLayout(false);
            this.MetropnlState.ResumeLayout(false);
            this.MetropnlState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).EndInit();
            this.grpExplain.ResumeLayout(false);
            this.grpPreview.ResumeLayout(false);
            this.grpPreview.PerformLayout();
            this.pl_about.ResumeLayout(false);
            this.pl_about.PerformLayout();
            this.grp_donate.ResumeLayout(false);
            this.grp_donate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_WeChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Alipay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private MetroFramework.Controls.MetroLink metroLink_about;
        private System.Windows.Forms.Panel pl_about;
        private System.Windows.Forms.Label lbl_prpe;
        private System.Windows.Forms.GroupBox grp_donate;
        private System.Windows.Forms.Label lbl_WeChat;
        private System.Windows.Forms.Label lbl_Alipay;
        private System.Windows.Forms.PictureBox pic_WeChat;
        private System.Windows.Forms.PictureBox pic_Alipay;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.Label lbl_buildtime;
        private MetroFramework.Components.MetroToolTip MetrotipAll;
        private MetroFramework.Controls.MetroLabel MetrolblState;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemImport;
        private MetroFramework.Controls.MetroContextMenu MetrocmsRec;
        private MetroFramework.Controls.MetroPanel MetropnlState;
        private System.Windows.Forms.DataGridView dgvRec;
        private MetroFramework.Controls.MetroLabel lblHotkey;
        private System.Windows.Forms.LinkLabel llbExplain;
        private System.ComponentModel.BackgroundWorker bgwRun;
        private MetroFramework.Controls.MetroButton btnPlayback;
        private MetroFramework.Controls.MetroLabel lblLog;
        private MetroFramework.Controls.MetroButton btnRecording;
        private System.Windows.Forms.Label lblCountdown;
        private MetroFramework.Controls.MetroButton btnReset;
        private MetroFramework.Controls.MetroCheckBox chkLoop;
        private System.Windows.Forms.NumericUpDown nudSecond;
        private MetroFramework.Controls.MetroLabel lblInterval;
        private MetroFramework.Controls.MetroLabel lblCursorPosition;
        private System.Windows.Forms.GroupBox grpExplain;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn mousebutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn doubleclick;
        private System.Windows.Forms.DataGridViewTextBoxColumn interval;
        private MetroFramework.Controls.MetroCheckBox chkTopmost;
    }
}

