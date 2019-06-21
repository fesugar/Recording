
using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;



using MouseKeyboardLibrary;



namespace SampleApplication

{

    /*

      上面的5个类编译成Dll引用,使用例子

     */

    public partial class HookTestForm : Form

    {



        MouseHook mouseHook = new MouseHook();
        private ListView listView1;
        private ListView listView2;
        private Label curXYLabel;
        KeyboardHook keyboardHook = new KeyboardHook();



        public HookTestForm()

        {

            InitializeComponent();

        }



        private void TestForm_Load(object sender, EventArgs e)

        {



            mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);

            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);

            mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);

            mouseHook.MouseWheel += new MouseEventHandler(mouseHook_MouseWheel);



            keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);

            keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);

            keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);



            mouseHook.Start();

            keyboardHook.Start();



            SetXYLabel(MouseSimulator.X, MouseSimulator.Y);



        }



        void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)

        {



            AddKeyboardEvent(

                "KeyPress",

                "",

                e.KeyChar.ToString(),

                "",

                "",

                ""

                );



        }



        void keyboardHook_KeyUp(object sender, KeyEventArgs e)

        {



            AddKeyboardEvent(

                "KeyUp",

                e.KeyCode.ToString(),

                "",

                e.Shift.ToString(),

                e.Alt.ToString(),

                e.Control.ToString()

                );



        }



        void keyboardHook_KeyDown(object sender, KeyEventArgs e)

        {





            AddKeyboardEvent(

                "KeyDown",

                e.KeyCode.ToString(),

                "",

                e.Shift.ToString(),

                e.Alt.ToString(),

                e.Control.ToString()

                );



        }



        void mouseHook_MouseWheel(object sender, MouseEventArgs e)

        {



            AddMouseEvent(

                "MouseWheel",

                "",

                "",

                "",

                e.Delta.ToString()

                );



        }



        void mouseHook_MouseUp(object sender, MouseEventArgs e)

        {





            AddMouseEvent(

                "MouseUp",

                e.Button.ToString(),

                e.X.ToString(),

                e.Y.ToString(),

                ""

                );



        }



        void mouseHook_MouseDown(object sender, MouseEventArgs e)

        {





            AddMouseEvent(

                "MouseDown",

                e.Button.ToString(),

                e.X.ToString(),

                e.Y.ToString(),

                ""

                );





        }



        void mouseHook_MouseMove(object sender, MouseEventArgs e)

        {



            SetXYLabel(e.X, e.Y);



        }



        void SetXYLabel(int x, int y)

        {



            curXYLabel.Text = String.Format("Current Mouse Point: X={0}, y={1}", x, y);



        }



        void AddMouseEvent(string eventType, string button, string x, string y, string delta)

        {



            listView1.Items.Insert(0,

                new ListViewItem(

                    new string[]{

                        eventType,

                        button,

                        x,

                        y,

                        delta

                    }));



        }



        void AddKeyboardEvent(string eventType, string keyCode, string keyChar, string shift, string alt, string control)

        {



            listView2.Items.Insert(0,

                 new ListViewItem(

                     new string[]{

                        eventType,

                        keyCode,

                        keyChar,

                        shift,

                        alt,

                        control

                }));



        }



        private void TestForm_FormClosed(object sender, FormClosedEventArgs e)

        {



            // Not necessary anymore, will stop when application exits



            //mouseHook.Stop();

            //keyboardHook.Stop();



        }

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.curXYLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 53);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(87, 47);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(91, 161);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(87, 47);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // curXYLabel
            // 
            this.curXYLabel.AutoSize = true;
            this.curXYLabel.Location = new System.Drawing.Point(136, 39);
            this.curXYLabel.Name = "curXYLabel";
            this.curXYLabel.Size = new System.Drawing.Size(55, 15);
            this.curXYLabel.TabIndex = 3;
            this.curXYLabel.Text = "label1";
            // 
            // HookTestForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.curXYLabel);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Name = "HookTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}
