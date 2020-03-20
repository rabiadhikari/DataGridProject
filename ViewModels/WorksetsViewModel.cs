using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace DataGridProject.ViewModels
{
    public class WorksetsViewModel
    {
        private ObservableCollection<Data_Element> _objectsCollection;

        public ObservableCollection<Data_Element> ObjectsCollection
        {
            get { return _objectsCollection; }
            set { _objectsCollection = value; }
        }

        public IList<string> _worksets;

        public IList<string> Worksets
        {
            get { return _worksets; }
            set { _worksets = value; }
        }

        public WorksetsViewModel()
        {
            Worksets = new List<string> { "Workset1", "Shared Levels & Grids", "Interior", "Exterior", "Structural" };
            //Generate the Data that we need for data grid.
            ObjectsCollection = ReadCSVFile();
        }

        public static ObservableCollection<Data_Element> ReadCSVFile()
        {
            using (var reader = new StreamReader(@"C:\Users\radhikari\OneDrive - RO\Documents\GitHub\DataGridProject\DataDataGrid.txt"))
            {
                ObservableCollection<Data_Element> ObjectsCollection = new ObservableCollection<Data_Element>();

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

                    ObjectsCollection.Add(tempData);
                }
                return ObjectsCollection;
            }
        }
    }
}