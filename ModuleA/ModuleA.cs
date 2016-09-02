using Microsoft.Practices.Prism.Events;
using ModuleA.ViewModel;
using MyPrismDemo.Infrastructure;
using MyPrismDemo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    public class ModuleA : ModuleBase
    {
        protected override void RegisterViewsAndservice()
        {
            return;
        }

        protected override void RegisterEvents()
        {
            EventAggregator.GetEvent<ShowViewEvent>().Subscribe(args =>
                {
                    var vm = new ModuleAViewModel(new ModuleAView());
                    vm.RegisterCommands();
                    var rr = RegionManager.Regions[RegionNames.RibbonRegion];
                    rr.Add(vm.View);
                    rr.Activate(vm.View);
                }, ThreadOption.UIThread, true, arg => arg.ViewName == Views.ModuleAView.ToString());
        }
    }
}
