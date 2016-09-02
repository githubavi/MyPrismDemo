using MyPrismDemo.Infrastructure.Interfaces;
using MyPrismDemo.ModuleB.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyPrismDemo.ModuleB.ViewModel
{
    public class ModuleBViewModel : ViewModelBase
    {
        public ModuleBViewModel(IView view)
        {
            this.View = view;
            view.DataContext = this;
            this.ValidateAsync();
        }

        private ObservableCollection<ItemTreeModel> data = new ObservableCollection<ItemTreeModel>();
        public ObservableCollection<ItemTreeModel> TreeViewData
        {
            get
            {
                if (data.Count == 0)
                {
                    this.data.Add(new ItemTreeModel { Name = "Item1", Status = "1" });
                    this.data.Add(new ItemTreeModel { Name = "Item2", Status = "2" });
                }
                return data;
            }
        }

        string txtDummyData = string.Empty;
        string txtDummyData2 = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string TextDummyData
        {
            get { return txtDummyData; }
            set
            {
                txtDummyData = value;
                RaisePropertyChanged("TextDummyData", true);
            }
        }

        //[Required]
        [EmailAddress(ErrorMessage="Email address is invalid")]
        public string TextDummyData2
        {
            get { return txtDummyData2; }
            set
            {
                txtDummyData2 = value;
                RaisePropertyChanged("TextDummyData2", true);
            }
        }

        TreeModelBase selItem;
        public TreeModelBase SelectedItem
        {
            get { return selItem ?? this.TreeViewData.First(); }
            set { 
                selItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        protected override void OnDispose()
        {
            UnRegisterCommands();
            base.OnDispose();
        }
    }
}
