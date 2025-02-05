using Autofac;
using Framework.Common.Utils;
using ReactiveUI;
using Serilog;
using Splat;
using System.Reflection;
using System.Windows.Forms;
using WinForms.UI.ViewModel;

namespace WinForms.UI
{

    public class Bootstrapper
    {
        private readonly string configFilePath = "Config\\serilog.json";


        private IContainer _container;
        
        public Bootstrapper()
        {
            ConfigureLogging();
            ConfigureServices();
            ConfigureInteractions();
        }

        public void Run()
        {
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();

            //约定：将ViewModel与View绑定
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

            //启动界面
            using (var scope = _container.BeginLifetimeScope())
            {
                var screen =scope.Resolve<IScreen>();
                var view = ViewLocator.Current.ResolveView(screen);
                view.ViewModel = screen;
                Application.Run((Form)view);
            }
        }
        /// <summary>
        /// 配置日志记录
        /// </summary>
        private void ConfigureLogging()
        {
            LogUtils.ConfigureLogging(configFilePath);

        }

        /// <summary>
        /// 配置服务
        /// </summary>
        private void ConfigureServices()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(Log.Logger).As<Serilog.ILogger>().SingleInstance();

            builder.RegisterType<ShellViewModel>().As<IScreen>().SingleInstance();


            _container = builder.Build();
        }

        /// <summary>
        /// 配置消息
        /// </summary>
        private void ConfigureInteractions()
        {
        }

    }

}
