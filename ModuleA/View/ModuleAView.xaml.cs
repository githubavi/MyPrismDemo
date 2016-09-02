using ModuleA.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModuleA
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ModuleAView : UserControl, IView
    {
        public ModuleAView()
        {
            InitializeComponent();
        }

        public ModuleAViewModel ViewModel
        {
            get { return DataContext as ModuleAViewModel; }
            set { DataContext = value; }
        }
    }
}
