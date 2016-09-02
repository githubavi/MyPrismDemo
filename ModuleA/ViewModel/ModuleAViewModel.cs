using Microsoft.Practices.Prism.Commands;
using MyPrismDemo.Infrastructure;
using MyPrismDemo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModuleA.ViewModel
{
    public class ModuleAViewModel : ViewModelBase
    {
        public ModuleAViewModel(ModuleAView view)
        {
            this.View = view;
            view.ViewModel = this;
        }

        private ICommand navCommand;
        public ICommand NavigateCommand 
        {
            get
            {
                return navCommand ?? (navCommand = new RelayCommand(obj =>
                    {
                        ViewRouter.NavigatetoView(Views.ModuleBView);
                    }, obj =>
                    {
                        return true;
                    }));
            }
        }

        protected override void EnumerateCommands(Action<CompositeCommand, System.Windows.Input.ICommand> returnCommand)
        {
            base.EnumerateCommands(returnCommand);
            returnCommand(GlobalCommands.NavigateCommand, this.NavigateCommand);
        }

        protected override void OnDispose()
        {
            UnRegisterCommands();
            base.OnDispose();
        }

        public string Text
        {
            get
            {
                return "Load Main View Module";
            }
        }
    }
}
