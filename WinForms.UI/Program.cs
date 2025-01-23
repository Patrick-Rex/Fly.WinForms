using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.UI.Helpers;

namespace WinForms.UI
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 初始化应用程序配置
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RxApp.MainThreadScheduler = Scheduler.CurrentThread;

            AntdUI.Localization.DefaultLanguage = "zh-CN";
            AntdUI.Config.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

            // 设置全局异常处理器
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            RxApp.DefaultExceptionHandler = new CustomObservableExceptionHandler();

            // 创建并配置 Bootstrapper
            var bootstrapper = new Bootstrapper();

            // 使用 Bootstrapper 运行应用程序
            bootstrapper.Run();
        }

        // 导入设置DPI感知所需的Windows API函数。
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        // 捕获UI线程中的未处理异常事件
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
           
        }

        // 捕获非UI线程中的未处理异常事件
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }
    }
}
