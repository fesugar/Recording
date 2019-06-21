
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Runtime.InteropServices;

using System.Timers;

using System.Windows.Forms; //Keys枚举在这里面

namespace io_apis

{

    //鼠标事件常量

    public enum MouseEventFlag : uint

    {

        Move = 0x0001,

        LeftDown = 0x0002,

        LeftUp = 0x0004,

        RightDown = 0x0008,

        RightUp = 0x0010,

        MiddleDown = 0x0020,

        MiddleUp = 0x0040,

        XDown = 0x0080,

        XUp = 0x0100,

        Wheel = 0x0800,

        VirtualDesk = 0x4000,

        Absolute = 0x8000

    }



    //键盘事件常量

    public enum KeyEventFlag : int

    {

        Down = 0x0000,

        Up = 0x0002,

    }



    public class Io_Api

    {

        //鼠标事件函数

        [DllImport("user32.dll", EntryPoint = "mouse_event")]

        public static extern void mouse_event(MouseEventFlag dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);



        //鼠标移动函数

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]

        private static extern int SetCursorPos(int x, int y);



        //键盘事件函数

        [DllImport("user32.dll", EntryPoint = "keybd_event")]

        public static extern void keybd_event(Byte bVk, Byte bScan, KeyEventFlag dwFlags, Int32 dwExtraInfo);



        //定时器

        private System.Timers.Timer atimer = new System.Timers.Timer();



        //自动释放键值

        private Byte vbk;



        //初始化

        public Io_Api()
        {



            //设置定时器事件

            this.atimer.Elapsed += new ElapsedEventHandler(atimer_Elapsed);

            this.atimer.AutoReset = true;

        }





        //鼠标操作 _dx,_dy 是鼠标距离当前位置的二维移动向量

        public void mouse(MouseEventFlag _dwFlags, int _dx, int _dy)

        {

            mouse_event(_dwFlags, _dx, _dy, 0, 0);

        }



        
        /// <summary>
        /// 鼠标操作
        /// </summary>
        /// <param name="button">字符参数， L 左键 、 R 右键 、M 中间键</param>
        /// <param name="is_double">布尔值， 知否双击，默认FLASE</param>
        public void mouse_click(string button = "L", bool is_double = false)



        {

            switch (button)
            {

                case "L":

                    mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, 0);

                    mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, 0);

                    if (is_double)
                    {

                        mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, 0);

                        mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, 0);

                    }

                    break;

                case "R":

                    mouse_event(MouseEventFlag.RightDown, 0, 0, 0, 0);

                    mouse_event(MouseEventFlag.RightUp, 0, 0, 0, 0);

                    if (is_double)
                    {

                        mouse_event(MouseEventFlag.RightDown, 0, 0, 0, 0);

                        mouse_event(MouseEventFlag.RightUp, 0, 0, 0, 0);

                    }

                    break;

                case "M":

                    mouse_event(MouseEventFlag.MiddleDown, 0, 0, 0, 0);

                    mouse_event(MouseEventFlag.MiddleUp, 0, 0, 0, 0);

                    if (is_double)

                    {

                        mouse_event(MouseEventFlag.MiddleDown, 0, 0, 0, 0);

                        mouse_event(MouseEventFlag.MiddleUp, 0, 0, 0, 0);

                    }

                    break;

            }

        }



        //鼠标移动到 指定位置(_dx,_dy)

        public void mouse_move(int _dx, int _dy)

        {

            SetCursorPos(_dx, _dy);

        }



        //键盘操作

        public void keybd(Byte _bVk, KeyEventFlag _dwFlags)

        {

            keybd_event(_bVk, 0, _dwFlags, 0);

        }



        //键盘操作 带自动释放 dwFlags_time 单位:毫秒

        public void keybd(Byte __bVk, int dwFlags_time = 100)

        {



            this.vbk = __bVk;

            //设置定时器间隔时间

            this.atimer.Interval = dwFlags_time;

            keybd(this.vbk, KeyEventFlag.Down);

            this.atimer.Enabled = true;

        }



        //键盘操作 组合键 带释放

        public void keybd(Byte[] _bVk)

        {

            if (_bVk.Length >= 2)

            {

                //按下所有键

                foreach (Byte __bVk in _bVk)
                {

                    keybd(__bVk, KeyEventFlag.Down);

                }

                //反转按键排序

                _bVk = (Byte[])_bVk.Reverse().ToArray();



                //松开所有键

                foreach (Byte __bVk in _bVk)

                {

                    keybd(__bVk, KeyEventFlag.Up);

                }

            }

        }



        void atimer_Elapsed(object sender, ElapsedEventArgs e)

        {

            this.atimer.Enabled = false;



            //释放按键

            keybd(this.vbk, KeyEventFlag.Up);

        }



        //获取键码 这一部分 就是根据字符串 获取 键码 这里只列出了一部分 可以自己修改

        public Byte getKeys(string key)

        {

            switch (key)
            {

                case "A": return (Byte)Keys.A;

                case "B": return (Byte)Keys.B;

                case "C": return (Byte)Keys.C;

                case "D": return (Byte)Keys.D;

                case "E": return (Byte)Keys.E;

                case "F": return (Byte)Keys.F;

                case "G": return (Byte)Keys.G;

                case "H": return (Byte)Keys.H;

                case "I": return (Byte)Keys.I;

                case "J": return (Byte)Keys.J;

                case "K": return (Byte)Keys.K;

                case "L": return (Byte)Keys.L;

                case "M": return (Byte)Keys.M;

                case "N": return (Byte)Keys.N;

                case "O": return (Byte)Keys.O;

                case "P": return (Byte)Keys.P;

                case "Q": return (Byte)Keys.Q;

                case "R": return (Byte)Keys.R;

                case "S": return (Byte)Keys.S;

                case "T": return (Byte)Keys.T;

                case "U": return (Byte)Keys.U;

                case "V": return (Byte)Keys.V;

                case "W": return (Byte)Keys.W;

                case "X": return (Byte)Keys.X;

                case "Y": return (Byte)Keys.Y;

                case "Z": return (Byte)Keys.Z;

                case "Add": return (Byte)Keys.Add;

                case "Back": return (Byte)Keys.Back;

                case "Cancel": return (Byte)Keys.Cancel;

                case "Capital": return (Byte)Keys.Capital;

                case "CapsLock": return (Byte)Keys.CapsLock;

                case "Clear": return (Byte)Keys.Clear;

                case "Crsel": return (Byte)Keys.Crsel;

                case "ControlKey": return (Byte)Keys.ControlKey;

                case "D0": return (Byte)Keys.D0;

                case "D1": return (Byte)Keys.D1;

                case "D2": return (Byte)Keys.D2;

                case "D3": return (Byte)Keys.D3;

                case "D4": return (Byte)Keys.D4;

                case "D5": return (Byte)Keys.D5;

                case "D6": return (Byte)Keys.D6;

                case "D7": return (Byte)Keys.D7;

                case "D8": return (Byte)Keys.D8;

                case "D9": return (Byte)Keys.D9;

                case "Decimal": return (Byte)Keys.Decimal;

                case "Delete": return (Byte)Keys.Delete;

                case "Divide": return (Byte)Keys.Divide;

                case "Down": return (Byte)Keys.Down;

                case "End": return (Byte)Keys.End;

                case "Enter": return (Byte)Keys.Enter;

                case "Escape": return (Byte)Keys.Escape;

                case "F1": return (Byte)Keys.F1;

                case "F2": return (Byte)Keys.F2;

                case "F3": return (Byte)Keys.F3;

                case "F4": return (Byte)Keys.F4;

                case "F5": return (Byte)Keys.F5;

                case "F6": return (Byte)Keys.F6;

                case "F7": return (Byte)Keys.F7;

                case "F8": return (Byte)Keys.F8;

                case "F9": return (Byte)Keys.F9;

                case "F10": return (Byte)Keys.F10;

                case "F11": return (Byte)Keys.F11;

                case "F12": return (Byte)Keys.F12;

                case "Help": return (Byte)Keys.Help;

                case "Home": return (Byte)Keys.Home;

                case "Insert": return (Byte)Keys.Insert;

                case "LButton": return (Byte)Keys.LButton;

                case "LControl": return (Byte)Keys.LControlKey;

                case "Left": return (Byte)Keys.Left;

                case "LMenu": return (Byte)Keys.LMenu;

                case "LShift": return (Byte)Keys.LShiftKey;

                case "LWin": return (Byte)Keys.LWin;

                case "MButton": return (Byte)Keys.MButton;

                case "Menu": return (Byte)Keys.Menu;

                case "Multiply": return (Byte)Keys.Multiply;

                case "Next": return (Byte)Keys.Next;

                case "NumLock": return (Byte)Keys.NumLock;

                case "NumPad0": return (Byte)Keys.NumPad0;

                case "NumPad1": return (Byte)Keys.NumPad1;

                case "NumPad2": return (Byte)Keys.NumPad2;

                case "NumPad3": return (Byte)Keys.NumPad3;

                case "NumPad4": return (Byte)Keys.NumPad4;

                case "NumPad5": return (Byte)Keys.NumPad5;

                case "NumPad6": return (Byte)Keys.NumPad6;

                case "NumPad7": return (Byte)Keys.NumPad7;

                case "NumPad8": return (Byte)Keys.NumPad8;

                case "NumPad9": return (Byte)Keys.NumPad9;

                case "PageDown": return (Byte)Keys.PageDown;

                case "PageUp": return (Byte)Keys.PageUp;

                case "Process": return (Byte)Keys.ProcessKey;

                case "RButton": return (Byte)Keys.RButton;

                case "Right": return (Byte)Keys.Right;

                case "RControl": return (Byte)Keys.RControlKey;

                case "RMenu": return (Byte)Keys.RMenu;

                case "RShift": return (Byte)Keys.RShiftKey;

                case "Scroll": return (Byte)Keys.Scroll;

                case "Space": return (Byte)Keys.Space;

                case "Tab": return (Byte)Keys.Tab;

                case "Up": return (Byte)Keys.Up;

            }

            return 0;

        }

    }



}
