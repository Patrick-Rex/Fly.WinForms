using Autofac;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.UI.ViewModel;
using WinForms.UI.Views;

namespace WinForms.UI
{

    public class Bootstrapper
    {
        private IContainer _container;

        public Bootstrapper()
        {
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
                var screen =scope.Resolve<IScreen>(); ;
                var view = ViewLocator.Current.ResolveView(screen);
                view.ViewModel = screen;
                Application.Run((Form)view);
            }
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        private void ConfigureServices()
        {
            var builder = new ContainerBuilder();
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
