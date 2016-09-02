using Microsoft.Practices.Prism.Events;
using MyPrismDemo.Infrastructure;
using MyPrismDemo.ModuleB.View;
using MyPrismDemo.ModuleB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyPrismDemo.ModuleB
{
    public class ModuleB : ModuleBase
    {
        protected override void RegisterViewsAndservice()
        {
            return;
        }

        protected override void RegisterEvents()
        {
            EventAggregator.GetEvent<ShowViewEvent>().Subscribe(args =>
            {
                //var vm = new ModuleBViewModel(new ModuleBView());
                var vm = new ModuleBViewModel(new ModuleBAnotherView());
                //var vm = new UserDataGridViewModel(new UserDataGrid());
                vm.RegisterCommands();
                var rr = RegionManager.Regions[RegionNames.MainRegion];
                rr.Add(vm.View);
                rr.Activate(vm.View);
            }, ThreadOption.UIThread, true, arg => arg.ViewName == Views.ModuleBView.ToString());

            Uri uri = new Uri("/MyPrismDemo.Infrastructure;Component/config/Common.en-US.xml", UriKind.RelativeOrAbsolute);
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Windows.Application.GetResourceStream(uri).Stream);
        }
    }
}
