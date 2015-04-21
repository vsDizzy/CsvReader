using System;

namespace HoldingWebJob.Csv
{
	internal class CsvRow
	{
		private readonly string[] _cols;
		private readonly string[] _data;

		public CsvRow(string[] cols, string[] data)
		{
			_cols = cols;
			_data = data;
		}

		public string this[int index]
		{
			get { return _data[index].Trim('"'); }
		}

		public string this[string column]
		{
			get
			{
				var index = Array.IndexOf(_cols, column);
				return this[index];
			}
		}
	}
}