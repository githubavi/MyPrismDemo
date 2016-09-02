using MyPrismDemo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrismDemo.ModuleB.ViewModel
{
    public class ItemTreeModel : TreeModelBase
    {
        public ItemTreeModel() 
        {
            for (int i = 0; i < 100; i++)
            {
                var item = new SubTreeModel();
                item.Name = "item " + i.ToString();
                item.Status = "Status "+ i.ToString();
                this.Children.Add(item);
            }
        }

        public override string Name { get; set; }
        public override string Status { get; set; }
    }

    public class SubTreeModel : TreeModelBase
    {
        public SubTreeModel()
        {
            for (int i = 0; i <=10; i++)
            {
                var item = new LeafTreeModel();
                item.Name = "item " + i.ToString();
                item.Status = "Status "+ i.ToString();
                this.Children.Add(item);
            }
        }

        public override string Name { get; set; }
        public override string Status { get; set; }
    }

    public class LeafTreeModel : TreeModelBase
    {
        public LeafTreeModel()
        {
           
        }
        public override string Name { get; set; }
        public override string Status { get; set; }
    }


}
