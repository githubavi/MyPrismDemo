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
    public abstract class ModuleBase : IModule
    {
        private IEventAggregator aggre;
        private IRegionManager regMgr;

        public void Initialize()
        {
            RegisterViewsAndservice();
            RegisterEvents();
        }

        protected abstract void RegisterViewsAndservice();
        protected abstract void RegisterEvents();

        protected IRegionManager RegionManager
        {
            get
            {
                return regMgr ?? (regMgr = ServiceLocator.Current.GetInstance<IRegionManager>());
            }
        }

        protected IEventAggregator EventAggregator
        {
            get
            {
                return aggre ?? (aggre = ServiceLocator.Current.GetInstance<IEventAggregator>());        
            }
        }
    }

    public class ShowViewEventArgs : EventArgs
    {
        public string ViewName {get;set;}
    }

    public class ShowViewEvent : CompositePresentationEvent<ShowViewEventArgs>
    {
    }

    public enum Views
    {
        ModuleAView,
        ModuleBView,
    }
}
