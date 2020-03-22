using DataGridProject.ViewModels;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace DataGridProject.Models
{
    public class Data_WorksetGroup : BindableBase
    {
        //Create properties for observable collection of all Workset and its elements
        private ObservableCollection<Data_Element> _items;

        public ObservableCollection<Data_Element> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        private bool _isExpanded;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }

        public Data_WorksetGroup(ObservableCollection<Data_Element> items)
        {
            Items = items;
        }
    }
}