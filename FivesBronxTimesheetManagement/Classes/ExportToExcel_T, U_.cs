using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FivesBronxTimesheetManagement.Classes
{
    public class ExportToExcel<T, U>
	where T : class
	where U : List<T>
	{
		public List<T> dataToPrint;

		private Microsoft.Office.Interop.Excel.Application _excelApp;
		private Workbooks _books;
		private _Workbook _book;
		private Sheets _sheets;
		private _Worksheet _sheet;
		private Range _range;
		private Font _font;

		public ExportToExcel()
		{
        }

		private void AddExcelRows(string startRange, int rowCount, int colCount, object values)
		{
            string first = ((char)(Encoding.ASCII.GetBytes(startRange.Substring(0, 1))[0] + colCount - 1)).ToString();
            string last = (Int32.Parse(startRange.Substring(1, 1)) + rowCount - 1).ToString();
            _range = _sheet.get_Range(startRange, string.Concat(first, last));
            _range.Value2 = values;
		}

		private void AutoFitColumns(string startRange, int rowCount, int colCount)
		{
            string first = ((char)(Encoding.ASCII.GetBytes(startRange.Substring(0, 1))[0] + colCount - 1)).ToString();
            string last = (Int32.Parse(startRange.Substring(1, 1)) + rowCount - 1).ToString();
            _range = _sheet.get_Range(startRange, string.Concat(first, last));
			_range.Columns.AutoFit();
		}

		private void CreateExcelRef()
		{
            _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _books = _excelApp.Workbooks;
            _book = _excelApp.Workbooks.Add();
            _sheets = _book.Worksheets;
            _sheet = (_Worksheet)_excelApp.ActiveSheet;
		}

		private object[] CreateHeader()
		{
			PropertyInfo[] properties = typeof(T).GetProperties();
			List<object> objs = new List<object>();
			for (int i = 0; i < (int)properties.Length; i++)
			{
				objs.Add(properties[i].Name);
			}
			object[] array = objs.ToArray();
			AddExcelRows("A1", 1, (int)array.Length, array);
			SetHeaderStyle();
			return array;
		}

		private void FillSheet()
		{
			WriteData(CreateHeader());
		}

		public void GenerateReport()
		{
			try
			{
				try
				{
					if (dataToPrint == null)
					{
						MessageBox.Show("No results found");
					}
					else if (dataToPrint.Count == 0)
					{
						MessageBox.Show("No results found");
					}
					else
					{
						Mouse.SetCursor(Cursors.Wait);
						CreateExcelRef();
						FillSheet();
						OpenReport();
						Mouse.SetCursor(Cursors.Arrow);
					}
				}
				catch (Exception exception)
				{
					MessageBox.Show(string.Concat("Error while generating Excel report", exception.ToString()));
				}
			}
			finally
			{
				ReleaseObject(_sheet);
				ReleaseObject(_sheets);
				ReleaseObject(_book);
				ReleaseObject(_books);
				ReleaseObject(_excelApp);
			}
		}

		private void OpenReport()
		{
			_excelApp.Visible = true;
		}

		private void ReleaseObject(object obj)
		{
			try
			{
				try
				{
					Marshal.ReleaseComObject(obj);
					obj = null;
				}
				catch
				{
					obj = null;
				}
			}
			finally
			{
				GC.Collect();
			}
		}

		private void SetHeaderStyle()
		{
			_font = this._range.Font;
			_font.Bold = true;
		}

		private void WriteData(object[] header)
		{
			object[,] objArray = new object[dataToPrint.Count, (int)header.Length];
			for (int i = 0; i < dataToPrint.Count; i++)
			{
				T item = dataToPrint[i];
				for (int j = 0; j < (int)header.Length; j++)
				{
					object obj = typeof(T).InvokeMember(header[j].ToString(), BindingFlags.GetProperty, null, item, null);
					objArray[i, j] = (obj == null ? "" : obj.ToString());
				}
			}
			AddExcelRows("A2", dataToPrint.Count, (int)header.Length, objArray);
			AutoFitColumns("A1", dataToPrint.Count + 1, (int)header.Length);
		}
	}
}