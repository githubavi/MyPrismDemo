using MyPrismDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Application.Current.DispatcherUnhandledException+=Current_DispatcherUnhandledException;

            WeakEventManager<Application, DispatcherUnhandledExceptionEventArgs>.
                AddHandler(Application.Current, "DispatcherUnhandledException", Current_DispatcherUnhandledException);

            //display some Splash screen
            MyPrismDemoBootStrapper bs = new MyPrismDemoBootStrapper();
            bs.Run();
            //close the splash screen

            ViewRouter.NavigatetoView(Views.ModuleAView);
        }

        void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    }
