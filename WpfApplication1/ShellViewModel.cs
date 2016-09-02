using Microsoft.Practices.Unity;
using MyPrismDemo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class ShellViewModel: IShellViewModel
    {
        public ShellViewModel(IShellView view)
        {
            this.View = view;
        }

        public IShellView View { get; set; }
    }
}
