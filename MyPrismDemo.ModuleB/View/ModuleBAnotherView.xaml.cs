using MyPrismDemo.Infrastructure.Interfaces;
using MyPrismDemo.ModuleB.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPrismDemo.ModuleB.View
{
    /// <summary>
    /// Interaction logic for ModuleBAnotherView.xaml
    /// </summary>
    public partial class ModuleBAnotherView : UserControl, IView
    {
        public ModuleBAnotherView()
        {
            InitializeComponent();
        }

        public ModuleBViewModel ViewModel
        {
            get { return DataContext as ModuleBViewModel; }
            set { DataContext = value; }
        }
    }
}
