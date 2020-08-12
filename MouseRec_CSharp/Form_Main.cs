#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：MouseRec_CSharp
* 项目描述 ：Recording for CSharp
* 类 名 称 ：Form_Main
* 类 描 述 ：主窗体
* 命名空间 ：MouseRec_CSharp
* CLR 版本 ：4.0
* 作    者 ：fesugar
* 邮    箱 ：fesugar@fesugar.com
* 创建时间 ：12:42 2020/3/16
* 更新时间 ：12:42 2020/3/16
* 版 本 号 ：v1.0.0.0
* 参考文献 ：
*******************************************************************
* Copyright @ fesugar.com 2020. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using Gma.System.MouseKeyHook;
using MetroFramework;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace MouseRec_CSharp
{
    /// <summary>
    /// 主窗体类
    /// </summary>
    public partial class Form_Main : MetroFramework.Forms.MetroForm
    {

        /// <summary>
        /// xml 文件路径
        /// </summary>
        private string xml_FilePath;
        /// <summary>
        /// 间隔时间
        /// </summary>
        private double numeric1_Timestamp;
        private double numeric2_Timestamp;
        /// <summary>
        /// 定义委托
        /// </summary>
        /// <param name="data"></param>
        public delegate void Gxdjs(string data);
        /// <summary>
        /// 钩子
        /// </summary>
        private IKeyboardMouseEvents m_GlobalHook;

        public Form_Main()
        {
            // 初始化设计器的代码
            InitializeComponent();
        }
        /// <summary>
        /// 主窗体载入时事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            this.Initia_();
            this.MetrotipAll.SetToolTip(this.btnRecording, "~~录制鼠标点击时坐标和动作~~");
            this.MetrotipAll.SetToolTip(this.btnPlayback, "~~回放录制的鼠标点击动作~~");
            this.MetrotipAll.SetToolTip(this.btnReset, "~~重置当前所有记录~~");
            this.MetrotipAll.SetToolTip(this.lblHotkey, "~~停止快捷热键~~");
            this.MetrotipAll.SetToolTip(this.chkLoop, "~~选中状态下会循环回放录制的动作~~");
            this.MetrotipAll.SetToolTip(this.nudSecond, "~~设置每次鼠标点击动作间隔时间~~\n~~值为-1 时则自动计算间隔的时间~~");
            this.lblCountdown.Text = null;
            this.dgvRec.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvRec.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvRec.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvRec.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        /// <summary>
        /// 录制按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRecording_Click(object sender, EventArgs e)
        {
            // 如已经在回放中状态，退出，不执行
            if (Convert.ToInt16(btnPlayback.Tag) == 1) return;

            // 检测录制按钮未在录制中
            if (Convert.ToInt16(this.btnRecording.Tag) == 0)
            {
                this.btnRecording.Tag = 1;
                this.btnRecording.Text = "录制中-再次点击停止";
                this.MetrolblState.Text = "状态:录制中... ...";
                this.Subscribe(false, true);
                this.btnPlayback.Enabled = false;
            }
            // 检测录制按钮已在录制中
            else if (Convert.ToInt16(this.btnRecording.Tag) == 1)
            {
                this.btnRecording.Tag = 0;
                this.btnRecording.Text = "停止中-再次点击录制";
                this.MetrolblState.Text = "状态:停止录制";
                this.Unsubscribe(true, true);
                this.btnPlayback.Enabled = true;
            }


            if (this.bgwRun.WorkerSupportsCancellation)
            {
                this.bgwRun.CancelAsync();
            }
            else
            {
                this.btnPlayback.Text = "录制回放";
            }
        }
        /// <summary>
        /// 回放按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlayback_Click(object sender, EventArgs e)
        {
            // 记录数据不为空的清空下继续执行
            if (this.dgvRec.Rows.GetRowCount(DataGridViewElementStates.None) != 0)
            {
                // 检测回放按钮未在回放中
                if (Convert.ToInt16(this.btnPlayback.Tag) == 0)
                {
                    // 检测复选框未选中状态下
                    if (this.chkLoop.CheckState != CheckState.Checked)
                    {
                        // 复选框按钮设置不可用
                        this.chkLoop.Enabled = false;
                    }
                    this.MetrolblState.Text = "状态:回放中... ...";
                    if (!this.bgwRun.IsBusy)
                    {
                        this.bgwRun.RunWorkerAsync();
                        this.btnPlayback.Tag = 1;
                        this.btnPlayback.Text = "回放中-再次点击停止";
                        this.Subscribe(true, false);
                        this.lblHotkey.Visible = true;
                    }
                }
                // 检测回放按钮未在回放中
                else if (Convert.ToInt16(this.btnPlayback.Tag) == 1)
                {
                    //  检测复选框未选中状态下
                    if (this.chkLoop.CheckState != CheckState.Checked)
                    {
                        // 复选框按钮设置不可用
                        this.chkLoop.Enabled = false;
                    }
                    if (this.bgwRun.WorkerSupportsCancellation)
                    {
                        this.bgwRun.CancelAsync();
                        this.btnPlayback.Tag = 0;
                        this.btnPlayback.Text = "停止中-再次点击回放";
                        this.Unsubscribe();
                        this.lblHotkey.Visible = false;
                    }
                }
            }
        }
        /// <summary>
        /// 重置按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // 重置初始化控件数设置
            this.Initia_();

        }
        /// <summary>
        /// 初始化控件设置
        /// </summary>
        public void Initia_()
        {

            // 检测是否设置了取消 bgwRun 任务
            if (this.bgwRun.WorkerSupportsCancellation)
            {
                // 取消 bgwRun 工作
                this.bgwRun.CancelAsync();
            }
            // 录制按钮启用
            this.btnRecording.Enabled = true;
            // 录制按钮状态标识 关闭
            this.btnRecording.Tag = 0;
            // 回放按钮状态标识 关闭
            this.btnPlayback.Tag = 0;
            // 回放按钮停用
            this.btnPlayback.Enabled = false;

            this.bgwRun.WorkerReportsProgress = true;
            this.bgwRun.WorkerSupportsCancellation = true;
            this.MetrolblState.Text = "状态:初始化完成";
            // 循环勾选框置于未选中状态
            this.chkLoop.CheckState = CheckState.Unchecked;

            this.btnRecording.Text = "录制动作";
            this.btnPlayback.Text = "动作回放";
            // 卸载鼠标监控钩子
            if (m_GlobalHook != null) this.Unsubscribe();
            // 热键提示文本标签可见状态设置为隐藏
            this.lblHotkey.Visible = false;
            // xml 文件路径设置为空
            xml_FilePath = null;
            toolStripMenuItemDelete.Text = "删除选中行";
            // 重设时间
            numeric1_Timestamp = 0;
            numeric2_Timestamp = 0;

            if (bgwRun.IsBusy)
            { //检查到在异步任务，等待刷新，缓解还未停止，数据已清空异常
                System.Threading.Thread.Sleep(100);
            }
            // 清空dgvRec数据
            this.dgvRec.Rows.Clear();
        }
        /// <summary>
        /// 载入记录单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemImport_Click(object sender, EventArgs e)
        {
            try
            {
                // 检测到存在数据弹出提示
                if ((this.dgvRec.Rows.Count <= 0) || (MetroMessageBox.Show(this, "\n发现当前存在数据，确定导入并清空已有数据吗？", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel))
                {
                    OpenFileDialog dialog = new OpenFileDialog
                    {
                        Multiselect = false
                    };
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!this.Xmlvalidate(dialog.FileName))
                        {
                            MetroMessageBox.Show(this, "\n导入的数据格式错误，请选择正确的格式重试。", "格式错误！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {

                            this.Initia_();
                            this.xml_FilePath = dialog.FileName;
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(this.xml_FilePath);
                            XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("MouseRec").ChildNodes;

                            foreach (XmlNode xmlNode in xmlNodeList)
                            {
                                XmlElement xmlElement = (XmlElement)xmlNode;
                                int index = this.dgvRec.Rows.Add();
                                this.dgvRec.Rows[index].Cells[0].Value = xmlElement.ChildNodes.Item(0).InnerText;
                                this.dgvRec.Rows[index].Cells[1].Value = xmlElement.ChildNodes.Item(1).InnerText;
                                this.dgvRec.Rows[index].Cells[2].Value = xmlElement.ChildNodes.Item(2).InnerText;
                                this.dgvRec.Rows[index].Cells[3].Value = xmlElement.ChildNodes.Item(3).InnerText;
                            }

                            this.BtnRecording_Click(this, e);   // 操作录制按钮更改回放按钮状态
                            this.BtnRecording_Click(this, e);   // 停止录制按钮
                            this.btnRecording.Enabled = false; // 禁用录制功能 -排序未解决
                            toolStripMenuItemDelete.Text = "删除选中行（存储）";

                        }
                    }
                }
            }
            catch (System.Xml.XmlException)
            {
                MetroMessageBox.Show(this, "\n打开的数据元错误，请选择正确的数据重试。", "数据错误！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.TargetSite.ToString(), "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 保存记录单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvRec.Rows.Count > 0)
                {
                    SaveFileDialog dialog = new SaveFileDialog
                    {
                        // 默认为文档目录路径
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                        Filter = "XML数据 (*.xml)|*.xml|所有文件(*.*)|*>**",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    // 对话框确定且文件路径不为空则处理文件保存
                    if ((dialog.ShowDialog() == DialogResult.OK) & (dialog.FileName.Length > 0))
                    {
                        this.xml_FilePath = dialog.FileName;
                        XmlDocument document = new XmlDocument();
                        XmlElement xmlElement_MouseRec = document.CreateElement("MouseRec");
                        int row = this.dgvRec.Rows.Count - 1;
                        for (int i = 0; i <= row; i++)
                        {
                            XmlElement xmlElement_event = document.CreateElement("event");
                            XmlElement xmlElement_id = document.CreateElement("id");
                            xmlElement_id.InnerText = this.dgvRec.Rows[i].Cells[0].Value.ToString();
                            xmlElement_event.AppendChild(xmlElement_id);
                            XmlElement xmlElement_position = document.CreateElement("position");
                            xmlElement_position.InnerText = this.dgvRec.Rows[i].Cells[1].Value.ToString();
                            xmlElement_event.AppendChild(xmlElement_position);
                            XmlElement xmlElement_mousebutton = document.CreateElement("mousebutton");
                            xmlElement_mousebutton.InnerText = this.dgvRec.Rows[i].Cells[2].Value.ToString();
                            xmlElement_event.AppendChild(xmlElement_mousebutton);
                            XmlElement xmlElement_interval = document.CreateElement("interval");
                            xmlElement_interval.InnerText = this.dgvRec.Rows[i].Cells[3].Value.ToString();
                            xmlElement_event.AppendChild(xmlElement_interval);
                            xmlElement_MouseRec.AppendChild(xmlElement_event);
                        }
                        document.AppendChild(document.CreateXmlDeclaration("1.0", "utf-8", ""));
                        document.AppendChild(xmlElement_MouseRec);
                        document.Save(this.xml_FilePath);
                        MetroMessageBox.Show(this, "\n文件已存储成功！", "保存文件！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "\n没有可用的数据导出", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.TargetSite.ToString(), "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DoWork 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwRun_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {



                this.Djs("③");
                System.Threading.Thread.Sleep(800);
                this.Djs("②");
                System.Threading.Thread.Sleep(800);
                this.Djs("①");
                System.Threading.Thread.Sleep(800);
                this.Djs(null);

                BackgroundWorker worker = sender as BackgroundWorker;

                Io_Api.Io_hook Io_Api_hook = new Io_Api.Io_hook();

                do
                {

                    for (int i = dgvRec.RowCount - 1; i >= 0; i += -1)
                    {
                        // 监测是否有取消任务
                        if (worker.CancellationPending)
                        {
                            // 如有任务终止任务
                            e.Cancel = true;
                            // 退出 do 区块
                            return;
                        }
                        // 读取 dgvgridview 数据
                        string str1 = (String)dgvRec[1, i].Value;
                        // 分割出X,Y坐标值
                        string[] fengge = Regex.Split(str1, ",", RegexOptions.IgnoreCase);
#if DEBUG
                        Debug.Write(dgvRec.RowCount);
#endif

                        dgvRec.ClearSelection(); //清空选择
                        dgvRec.Rows[i].Selected = true; // 设置被操作的行为选中
                        // this.dgvRec.Rows[i].Cells[1].Value.ToString();

                        // 耗时等待
                        for (int j = 0; j <= Convert.ToInt32(dgvRec[3, i].Value); j++)
                        {
                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(100);
                                int percentComplete = (int)((float)j / (float)Convert.ToInt32(dgvRec[3, i].Value) * 100);
                                worker.ReportProgress(percentComplete);
                            }
                        }

                        // 移动鼠标、点击鼠标
                        Io_Api_hook.Mouse_move(Convert.ToInt32(fengge[0]), Convert.ToInt32(fengge[1]));
                        string obj_value = Convert.ToString(this.dgvRec[2, i].Value);
                        if (obj_value == Convert.ToString(MouseButtons.Left)) Io_Api_hook.Mouse_click();
                        if (obj_value == Convert.ToString(MouseButtons.Right)) Io_Api_hook.Mouse_click("R");
                        if (obj_value == Convert.ToString(MouseButtons.Middle)) Io_Api_hook.Mouse_click("M");


                    }

                }
                // 如选项框选中循环中
                while (chkLoop.CheckState == CheckState.Checked);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.TargetSite.ToString(), "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 终止键盘钩子
                Unsubscribe();
            }

        }
        /// <summary>
        /// WorkerProgressChanged 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwRun_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.grpPreview.Text = "预览 == 操作等待时间百分比" + e.ProgressPercentage.ToString() + "%";
        }
        /// <summary>
        /// WorkerCompleted 完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.MetrolblState.Text = "状态: 已终止回放";
            }
            else if (e.Error != null)
            {
                this.MetrolblState.Text = "状态: " + e.Error.Message;
            }
            else
            {
                this.MetrolblState.Text = "状态: 已完成回放";
            }
            this.btnPlayback.Text = "动作回放";
            this.btnPlayback.Tag = 0;
            this.grpPreview.Text = "预览 ";
            this.chkLoop.Enabled = true;
            this.lblHotkey.Visible = false;
        }
        /// <summary>
        /// dgv 行 删除 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvRec_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.Addnum(this.dgvRec.Rows.Count);
        }
        /// <summary>
        /// 自动添加序号栏目
        /// </summary>
        /// <param name="rn"></param>
        public void Addnum(int rn)
        {
            for (int i = 1; i <= rn; i++)
            {
                this.dgvRec.Rows[i - 1].Cells[0].Value = (rn - i) + 1;
            }
            this.dgvRec.Refresh();
        }
        /// <summary>
        /// 被委托的中间类
        /// </summary>
        /// <param name="n"></param>
        private void Djs(string n)
        {
            base.Invoke(new Gxdjs(this.Cdjs), n);
        }
        /// <summary>
        /// 跨线程操作控件
        /// 这里要和委托定义时的参数保持一致
        /// </summary>
        /// <param name="data"></param>
        private void Cdjs(string data)
        {
            //更新 lblCountdown 控件值
            this.lblCountdown.Text = data;
        }
        /// <summary>
        /// 超链接说明单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LlbExplain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.fesugar.com/");
        }
        /// <summary>
        /// 右键菜单单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetrocmsRec_Opening(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(this.btnRecording.Tag) == 1)
            {
                this.btnRecording.Tag = 0;
                this.btnRecording.Text = "停止中-再次点击录制";
                this.MetrolblState.Text = "状态:停止录制";
                this.Unsubscribe(true, true);
                this.btnPlayback.Enabled = true;
            }
        }
        /// <summary>
        /// 全局鼠标光标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalHookMouseMoveExt(object sender, MouseEventArgs e)
        {
            this.lblCursorPosition.Text = string.Format("光标位置：X={0:0000}, Y={1:0000}", Control.MousePosition.X, Control.MousePosition.Y);
#if DEBUG
            Console.WriteLine(string.Format("x={0:0000}; y={1:0000}", e.X, e.Y));
#endif

        }
        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <param name="InstallKeyboardHook">默认安装键盘钩子</param>
        /// <param name="InstallMouseHook">默认安装鼠标钩子</param>
        public void Subscribe(bool InstallKeyboardHook = true, bool InstallMouseHook = true)
        {

            // 键盘鼠标都安装
            if (InstallKeyboardHook && InstallMouseHook)
            {
                // Note: for the application hook, use the Hook.AppEvents() instead
                m_GlobalHook = Hook.GlobalEvents();

                m_GlobalHook.MouseClick += GlobalHookMouseClick;
                m_GlobalHook.MouseMoveExt += GlobalHookMouseMoveExt;
                m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
                m_GlobalHook.KeyDown += GlobalHookKeyDownExt;
                return;

            }
            // 只安装按键
            if (!InstallMouseHook && InstallKeyboardHook)
            {
                m_GlobalHook = Hook.GlobalEvents();
                m_GlobalHook.KeyDown += GlobalHookKeyDownExt;
                return;
            }
            // 只安装鼠标
            if (!InstallKeyboardHook && InstallMouseHook)
            {
                m_GlobalHook = Hook.GlobalEvents();
                m_GlobalHook.MouseClick += GlobalHookMouseClick;
                m_GlobalHook.MouseMoveExt += GlobalHookMouseMoveExt;
                m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
                return;
            }

        }
        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <param name="UninstallKeyboardHook">键盘钩子 默认卸载</param>
        /// <param name="UninstallMouseHook">鼠标钩子 默认卸载</param>
        public void Unsubscribe(bool UninstallKeyboardHook = true, bool UninstallMouseHook = true)
        {
            // 键盘鼠标都卸载
            if (UninstallMouseHook && UninstallKeyboardHook)
            {
                m_GlobalHook.MouseClick -= GlobalHookMouseClick;
                m_GlobalHook.MouseMoveExt -= GlobalHookMouseMoveExt;
                m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
                m_GlobalHook.KeyDown -= GlobalHookKeyDownExt;

                //It is recommened to dispose it
                m_GlobalHook.Dispose();
                return;
            }

            // 只卸载按键
            if (!UninstallMouseHook && UninstallKeyboardHook)
            {
                m_GlobalHook.KeyDown -= GlobalHookKeyDownExt;
                return;
            }
            // 只卸载鼠标
            if (!UninstallKeyboardHook && UninstallMouseHook)
            {
                m_GlobalHook.MouseClick -= GlobalHookMouseClick;
                m_GlobalHook.MouseMoveExt -= GlobalHookMouseMoveExt;
                m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
                return;
            }

        }
        /// <summary>
        /// 全局键盘事件
        /// 检测热键F8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalHookKeyDownExt(object sender, KeyEventArgs e)
        {
#if DEBUG
            Console.WriteLine("MouseDown: \t{0}", e.KeyCode);
#endif
            if (e.KeyCode == Keys.F8)
            {
                this.btnPlayback.PerformClick();
            }
        }
        /// <summary>
        /// 全局鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalHookMouseClick(object sender, MouseEventArgs e)
        {

            // 判断屏幕坐标在程序窗体中不记录
            if (((MousePosition.X > Location.X) & (MousePosition.X < (Location.X + Width)) & (MousePosition.Y > Location.Y) & (MousePosition.Y < (Location.Y + Height)))) return;

            // 筛选鼠标按键状态
            switch (MouseButtons)
            {
                /*                case MouseButtons.Left:
                                    break;
                                case MouseButtons.Right:
                                    break;
                                case MouseButtons.Middle:
                                    break;*/
                default:
                    {
                        // 开始插入数据
                        int i = this.dgvRec.Rows.Add();
                        this.dgvRec.Rows[i].Cells[0].Value = i + 1;
                        this.dgvRec.Rows[i].Cells[1].Value = string.Format("{0},{1}", Control.MousePosition.X, Control.MousePosition.Y);
                        this.dgvRec.Rows[i].Cells[2].Value = e.Button;
                        if (nudSecond.Value == -1) // -1 则计算机器时间
                        {
                            // n2 为0设置默认值0
                            if (numeric2_Timestamp == 0)
                            {
                                numeric2_Timestamp = numeric1_Timestamp - numeric1_Timestamp;
                            }
                            else
                            {
                                // n2 计算近似两个时间相差的秒
                                numeric2_Timestamp = Math.Round((Convert.ToDouble(numeric1_Timestamp) - Convert.ToDouble(numeric2_Timestamp)) / 100);
                            }
                            // 写入时间
                            this.dgvRec.Rows[i].Cells[3].Value = numeric2_Timestamp;
                            // n2 重新赋值
                            numeric2_Timestamp = numeric1_Timestamp;
                        }
                        else
                        {
                            this.dgvRec.Rows[i].Cells[3].Value = this.nudSecond.Value;
                        }
                        // 依据id列倒序排序
                        this.dgvRec.Sort(this.dgvRec.Columns["id"], ListSortDirection.Descending);
                        break;
                    }
            }

        }
        /// <summary>
        /// XML 文件验证是否符合设计
        /// </summary>
        /// <param name="xmlurl"></param>
        /// <returns></returns>
        private bool Xmlvalidate(string xmlurl)
        {
            string xsdMarkup =
                 @"<?xml version='1.0' encoding='utf-8'?>
                    <xs:schema id='MouseRec' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata'>
	                    <xs:element name='MouseRec' msdata:IsDataSet='true' msdata:Locale='en-US'>
		                    <xs:complexType>
			                    <xs:choice minOccurs='0' maxOccurs='unbounded'>
				                    <xs:element name='event'>
					                    <xs:complexType>
						                    <xs:sequence>
							                    <xs:element name='id' type='xs:string' minOccurs='0'/>
							                    <xs:element name='position' type='xs:string' minOccurs='0'/>
							                    <xs:element name='mousebutton' type='xs:string' minOccurs='0'/>
							                    <xs:element name='interval' type='xs:string' minOccurs='0'/>
						                    </xs:sequence>
					                    </xs:complexType>
				                    </xs:element>
			                    </xs:choice>
		                    </xs:complexType>
	                    </xs:element>
                    </xs:schema>";
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(new StringReader(xsdMarkup)));

            XDocument doc1 = XDocument.Load(xmlurl);
#if DEBUG
            Console.WriteLine("Validating doc1");
#endif
            bool errors = false;
            doc1.Validate(schemas, (o, e) =>
            {
#if DEBUG
                Console.WriteLine("{0}", e.Message);
#endif
                errors = true;
            });
#if DEBUG
            Console.WriteLine("doc1 {0}", errors ? "did not validate" : "validated");
#endif
            return (errors ? false : true);
        }
        /// <summary>
        /// 循环勾选框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkLoop_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.chkLoop.CheckState == CheckState.Checked)
            {
                this.chkLoop.Text = "已启用循环回放";
            }
            else
            {
                this.chkLoop.Text = "已停用循环回放";
            }
        }
        /// <summary>
        /// 窗体关闭中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 如已经实例化，卸载钩子
            if (m_GlobalHook != null) Unsubscribe();
        }
        /// <summary>
        /// 右键菜单删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (dgvRec.Rows.Count == 0) return;
            int index = dgvRec.CurrentRow.Index;
            dgvRec.Rows[index].Selected = true;
            dgvRec.Rows.RemoveAt(index);
            this.Addnum(this.dgvRec.Rows.Count);

            try
            {

                XmlDocument document = new XmlDocument();//新建一个XML“编辑器”
                if (xml_FilePath != null)//如果用户已读入xml文件，我们的任务就是修改这个xml文件了
                {
                    document.Load(xml_FilePath);
                    XmlNode xmlElement_MouseRec = document.SelectSingleNode("MouseRec");//找到<class>作为根节点
                    xmlElement_MouseRec.RemoveAll();//删除旗下所有节点
                    int row = dgvRec.Rows.Count;//得到总行数    
                                                //int cell = dgvRec.Rows[1].Cells.Count;//得到总列数    
                    for (int i = 0; i < row; i++)//遍历这个dataGridView
                    {
                        XmlElement xmlElement_event = document.CreateElement("event");
                        XmlElement xmlElement_id = document.CreateElement("id");
                        xmlElement_id.InnerText = this.dgvRec.Rows[i].Cells[0].Value.ToString();
                        xmlElement_event.AppendChild(xmlElement_id);
                        XmlElement xmlElement_position = document.CreateElement("position");
                        xmlElement_position.InnerText = this.dgvRec.Rows[i].Cells[1].Value.ToString();
                        xmlElement_event.AppendChild(xmlElement_position);
                        XmlElement xmlElement_mousebutton = document.CreateElement("mousebutton");
                        xmlElement_mousebutton.InnerText = this.dgvRec.Rows[i].Cells[2].Value.ToString();
                        xmlElement_event.AppendChild(xmlElement_mousebutton);
                        XmlElement xmlElement_interval = document.CreateElement("interval");
                        xmlElement_interval.InnerText = this.dgvRec.Rows[i].Cells[3].Value.ToString();
                        xmlElement_event.AppendChild(xmlElement_interval);
                        xmlElement_MouseRec.AppendChild(xmlElement_event);
                    }
                    document.Save(xml_FilePath);//保存这个xml

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.TargetSite.ToString(), "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 全局鼠标按键按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
#if DEBUG
            Console.WriteLine("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);
#endif
            numeric1_Timestamp = e.Timestamp;
        }
    }
}
