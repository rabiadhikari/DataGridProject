using DataGridProject.Models;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace DataGridProject.ViewModels
{
    public class WorksetsViewModel : BindableBase
    {
        private ObservableCollection<Data_WorksetGroup> _objectsCollection;

        public ObservableCollection<Data_WorksetGroup> ObjectsCollection
        {
            get { return _objectsCollection; }
            set { SetProperty(ref _objectsCollection, value); }
        }

        public IList<string> _worksets;

        public IList<string> Worksets
        {
            get { return _worksets; }
            set { SetProperty(ref _worksets, value); }
        }

        public WorksetsViewModel()
        {
            Worksets = new ObservableCollection<string> { "Workset1", "Shared Levels & Grids", "Interior", "Exterior", "Structural" };
            //Generate the Data that we need for data grid.
            //ObjectsCollection = ReadCSVFile();
            ObjectsCollection = new ObservableCollection<Data_WorksetGroup>();

            //var queryWorksetId =
            //        from item in ReadCSVFile()
            //        group item by item.WorksetId into newGroup
            //        select newGroup as ObservableCollection<Data_Element>;

            var queryWorksetId = ReadCSVFile().GroupBy(x => x.WorksetId).Select(x => x).ToList();


            foreach (var group in queryWorksetId)
            {
                Data_WorksetGroup data_WorksetGroup = new Data_WorksetGroup(new ObservableCollection<Data_Element>(group))
                {
                    Name = group.Key,
                    IsSelected = true
                };
                ObjectsCollection.Add(data_WorksetGroup);
            }

        }

        public static ObservableCollection<Data_Element> ReadCSVFile()
        {
            using (var reader = new StreamReader(@"C:\Users\radhikari\OneDrive - RO\Documents\GitHub\DataGridProject\DataDataGrid.txt"))
            {
                ObservableCollection<Data_Element> items = new ObservableCollection<Data_Element>();

                string headerLine = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\t');
                    var tempData = new Data_Element
                    {
                        Id = values[0],
                        Name = values[1],
                        ElementType = values[2],
                        Category = values[3],
                        UniqueId = values[4],
                        WorksetId = values[5],
                        IsSelected = false,
                    };

                    items.Add(tempData);
                }
                return items;
            }
        }
    }
}