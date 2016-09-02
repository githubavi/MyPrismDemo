using System;
using System.Windows.Controls;
using System.Windows;
using MyPrismDemo.Infrastructure.Interfaces;


namespace MyPrismDemo.Infrastructure
{
    public class TreeListView : TreeView
    {
        public TreeListView()
        {
           
        }

        public static object GetSelectedItem(DependencyObject obj)
        {
            return (object)obj.GetValue(SelectedItemProperty);
        }

        public static void SetSelectedItem(DependencyObject obj, object value)
        {
            obj.SetValue(SelectedItemProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.RegisterAttached("SelectedItem", typeof(TreeModelBase), typeof(TreeListView), new UIPropertyMetadata(null, SelectionChanged));

        private static void SelectionChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is TreeListView))
                return;
            

            var view = obj as TreeListView;


            //view.SelectedItemChanged -= view_SelectedItemChanged;
            //view.SelectedItemChanged += view_SelectedItemChanged;
            WeakEventManager<TreeListView, RoutedPropertyChangedEventArgs<object>>.AddHandler(view, "SelectedItemChanged", view_SelectedItemChanged);

            //if (!behaviors.ContainsKey(obj))
            //    behaviors.Add(obj, new TreeViewSelectedItemBehavior(obj as TreeListView));

            //TreeViewSelectedItemBehavior view = behaviors[obj];
            //view.ChangeSelectedItem(e.NewValue);
        }

        static void view_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e1)
        {
            SetSelectedItem(sender as TreeListView, e1.NewValue);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }
    }

    public class TreeListViewItem : TreeViewItem
    {
        public TreeListViewItem()
        {
            this.Selected += TreeListViewItem_Selected;
            this.Expanded += TreeListViewItem_Expanded;
        }

        void TreeListViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            if(e.Source is TreeListViewItem)
                ((e.Source as TreeListViewItem).Header as TreeModelBase).IsExpanded = this.IsExpanded;
        }

        void TreeListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            if (e.Source is TreeListViewItem)
                ((e.Source as TreeListViewItem).Header as TreeModelBase).IsSelected = this.IsSelected;
        }

        /// <summary>
        /// Item's hierarchy in the tree
        /// </summary>
        public int Level
        {
            get
            {
                if (_level == -1)
                {
                    TreeListViewItem parent = 
                        ItemsControl.ItemsControlFromItemContainer(this) 
                            as TreeListViewItem;
                    _level = (parent != null) ? parent.Level + 1 : 0;
                }
                return _level;
            }
        }


        protected override DependencyObject 
                           GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }

        private int _level = -1;
    }

}
