using MyPrismDemo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MyPrismDemo.ModuleB.ViewModel
{
    public class UserDataGridViewModel : ViewModelBase
    {
        public UserDataGridViewModel(IView view)
        {
            this.View = view;
            view.DataContext = this;
            this.Items = new ObservableCollection<User>();
            
            //SynchronizationContext.Current.Post(p => AddUsers(), null);

            AddUsers(15);
            //Foo(p => { AddUsers(p); });

            Dispatcher.CurrentDispatcher.Hooks.DispatcherInactive += Hooks_DispatcherInactive;
            Dispatcher.CurrentDispatcher.Invoke(() => AddUsers(10), DispatcherPriority.ApplicationIdle);
        }

        void Hooks_DispatcherInactive(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello");
        }

        private void AddUsers(int i)
        {
            if (!Dispatcher.CurrentDispatcher.CheckAccess())
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                    {
                        this.Items.Add(new User { Name = "Avi", Data = "data 1" });
                        this.Items.Add(new User { Name = "Sam", Data = "data 2" });
                        this.Items.Add(new User { Name = "Lika", Data = "data 3" });
                    }));
            }
            else
            {
                this.Items.Add(new User { Name = "Avi", Data = "data 1" });
                this.Items.Add(new User { Name = "Sam", Data = "data 2" });
                this.Items.Add(new User { Name = "Lika", Data = "data 3" });
            }
        }

        async Task Foo(Action<int> onProgressPercentChanged)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (i % 10 == 0) onProgressPercentChanged(i / 10);
                    // Do something compute-bound...
                }
            });
        }

        public ObservableCollection<User> Items { get; private set; }
    }
}
