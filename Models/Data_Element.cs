namespace DataGridProject.ViewModels
{
    public class Data_Element
	{
		private string _id;

		public string Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _uniqueId;

		public string UniqueId
		{
			get { return _uniqueId; }
			set { _uniqueId = value; }
		}

		private string _worksetId;

		public string WorksetId
		{
			get { return _worksetId; }
			set { _worksetId = value; }
		}

		private string _elementType;

		public string ElementType
		{
			get { return _elementType; }
			set { _elementType = value; }
		}

		private bool _isSelected;

		public bool IsSelected
		{
			get { return _isSelected; }
			set { _isSelected = value; }
		}

		private string _category;

		public string Category
		{
			get { return _category; }
			set { _category = value; }
		}


	}
}
