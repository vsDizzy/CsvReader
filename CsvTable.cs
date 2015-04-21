using System.Collections.Generic;
using System.IO;

namespace HoldingWebJob.Csv
{
	internal class CsvTable
	{
		private readonly IEnumerable<string> _lines;

		public CsvTable(string filename)
		{
			_lines = File.ReadLines(filename);
		}

		public string[] Cols { get; private set; }

		public IEnumerable<CsvRow> Rows
		{
			get
			{
				var le = _lines.GetEnumerator();
				if (le.MoveNext())
				{
					Cols = ReadLine(le.Current);
				}
				while (le.MoveNext())
				{
					yield return new CsvRow(Cols, ReadLine(le.Current));
				}
			}
		}

		private string[] ReadLine(string line)
		{
			return line.Split(',');
		}
	}
}