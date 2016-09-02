using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrismDemo.Infrastructure
{
    public class ViewRouter
    {
        private IEventAggregator aggre;

        private ViewRouter() { }

        private static readonly Dictionary<string, string> modNamebyViewKeys = new Dictionary<string, string>
        {
            {Views.ModuleAView.ToString(),"ModuleA"},
            {Views.ModuleBView.ToString(),"ModuleB"},
        };

        public static void NavigatetoView(Views view)
        {
            var aggre = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var modmgr = ServiceLocator.Current.GetInstance<IModuleManager>();

            modmgr.LoadModule(modNamebyViewKeys[view.ToString()]);

            aggre.GetEvent<ShowViewEvent>().Publish(new ShowViewEventArgs { ViewName = view.ToString() });
        }
    }
}
