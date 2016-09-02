using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyPrismDemo.Infrastructure.Interfaces
{
    public interface IShellViewModel
    {
        IShellView View { get; set; }    
    }

    public interface IShellView
    {
        IShellViewModel ViewModel { get; set; }
    }

    public interface IView
    {
        object DataContext { get; set; }
    }

    public abstract class ViewModelBaseLight : INotifyPropertyChanged, IDisposable, INotifyDataErrorInfo
    {
        private ConcurrentDictionary<string, List<string>> _errors = new ConcurrentDictionary<string, List<string>>();
        
        public ViewModelBaseLight() { }

        public void Dispose()
        {
            Dispose(true);
        }

        ~ViewModelBaseLight()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected bool IsDisposed { get; private set; }

        private void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    try
                    {
                        //cleanup managed resource
                        OnDispose();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            IsDisposed = true;
        }

        protected virtual void OnDispose()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propname, bool validateproperty = false)
        {
            PropertyChangedEventHandler evtHandler = PropertyChanged;
            if (evtHandler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
            if (validateproperty)
                ValidateAsync();
        }

        private readonly object _lock = new object();
        protected async Task<bool> ValidateAsync()
        {
            return await Task<bool>.Run(() => Validate());
        }

        private bool Validate()
        {
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, validationContext, validationResults, true);

                foreach (var kv in _errors.ToList())
                {
                    if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                    {
                        List<string> outLi;
                        _errors.TryRemove(kv.Key, out outLi);
                        OnErrorsChanged(kv.Key);
                    }
                }

                var q = from r in validationResults
                        from m in r.MemberNames
                        group r by m into g
                        select g;

                foreach (var prop in q)
                {
                    var messages = prop.Select(r => r.ErrorMessage).ToList();

                    if (_errors.ContainsKey(prop.Key))
                    {
                        List<string> outLi;
                        _errors.TryRemove(prop.Key, out outLi);
                    }
                    _errors.TryAdd(prop.Key, messages);
                    OnErrorsChanged(prop.Key);
                }
            }
            return true;
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void OnErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            if (handler != null)
                handler(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            List<string> errorsForName;
            _errors.TryGetValue(propertyName, out errorsForName);
            return errorsForName;

        }

        public bool HasErrors
        {
            get { return _errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
        }
    }

    public abstract class ViewModelBase : ViewModelBaseLight
    {
        public virtual IView View { get; set; }
        
        public void RegisterCommands() 
        {
            if (!this.commandregistered)
            {
                this.commandregistered = true;
                this.EnumerateCommands((com, c) => com.RegisterCommand(c));
            }
        }

        protected void UnRegisterCommands() 
        {
            if (this.commandregistered)
            {
                this.commandregistered = false;
                this.EnumerateCommands((com, c) => com.UnregisterCommand(c));
            }
        }

        protected virtual void EnumerateCommands(Action<CompositeCommand, ICommand> returnCommand)
        {
        }

        private bool commandregistered;

        public ViewModelBase()
        {
            
        }
    }

    public interface ITreeModel
    {
        string Name { get; set; }
        string Status { get; set; }
        bool IsSelected { get; set; }
        bool IsExpanded { get; set; }
        ObservableCollection<ITreeModel> Children { get;}
        ITreeModel Parent { get; set; }
    }

    public abstract class TreeModelBase : ViewModelBaseLight,  ITreeModel
    {
        public abstract string Name { get; set; }
        public abstract string Status { get; set; }
        public bool IsSelected { get; set; }
        public bool IsExpanded { get; set; }

        private ObservableCollection<ITreeModel> children;
        public ObservableCollection<ITreeModel> Children
        {
            get
            {
                if (children != null) return children;
                children = new ObservableCollection<ITreeModel>();
                children.CollectionChanged += children_CollectionChanged;
                return children;
            }
        }

        void children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems.OfType<TreeModelBase>())
                    {
                        item.Parent = this;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems.OfType<TreeModelBase>())
                    {
                        item.Parent = null;
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    foreach (var item in e.OldItems.OfType<TreeModelBase>())
                    {
                        item.Parent = null;
                    }
                    foreach (var item in e.NewItems.OfType<TreeModelBase>())
                    {
                        item.Parent = this;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (var item in (sender as ObservableCollection<ITreeModel>).OfType<TreeModelBase>())
                    {
                        item.Parent = null;
                    }
                    break;
                default:
                    break;
            }
        }

        private ITreeModel parent;
        public ITreeModel Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (parent != value)
                {
                    parent = value;
                    RaisePropertyChanged("Parent");
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
