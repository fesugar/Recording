using System;
using System.Windows.Forms;

namespace MouseRec_CSharp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (System.Threading.Mutex mu = new System.Threading.Mutex(true, Application.ProductName, out bool create))
            {
                if (create)
                {
                    Application.Run(new Form_Main());
                }
            }
            //Application.Run(new Form_Main());
        }
    }
}
