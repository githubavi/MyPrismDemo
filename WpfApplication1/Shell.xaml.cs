using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using MyPrismDemo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window, IShellView
    {
        public Shell()
        {
            InitializeComponent();
        }

        public IShellViewModel ViewModel
        {
            get
            {
                return DataContext as IShellViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var regMgr = ServiceLocator.Current.GetInstance<IRegionManager>();
            foreach (var item in regMgr.Regions)
            {
                foreach (FrameworkElement view in item.Views)
                {
                    if (view.DataContext != null)
                    {
                        var vm = view.DataContext as IDisposable;
                        if(vm != null)
                            vm.Dispose();
                    }

                    var disposview = view as IDisposable;
                    if (disposview != null)
                        disposview.Dispose();
                }
            }
        }
    }
}
