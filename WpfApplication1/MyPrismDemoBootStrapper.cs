using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MyPrismDemo.Infrastructure.Interfaces;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Events;
using MyPrismDemo.Infrastructure;

namespace WpfApplication1
{
    public class MyPrismDemoBootStrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<IShellViewModel>().View as DependencyObject;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            //Container.RegisterInstance<IEventAggregator>(new ConcurrentEventAggregator());
            base.ConfigureContainer();
            base.ConfigureServiceLocator();
            Container.RegisterType<IShellViewModel, ShellViewModel>();
            Container.RegisterType<IShellView, Shell>();
        }

        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
