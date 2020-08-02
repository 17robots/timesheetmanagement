using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using Cursors = System.Windows.Input.Cursors;
using MessageBox = System.Windows.Forms.MessageBox;

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
			_range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
			_range.Value2 = values;
		}

		private void AutoFitColumns(string startRange, int rowCount, int colCount)
		{
			string first = ((char)(Encoding.ASCII.GetBytes(startRange.Substring(0, 1))[0] + colCount - 1)).ToString();
			string last = (Int32.Parse(startRange.Substring(1, 1)) + rowCount - 1).ToString();
			_range = _sheet.get_Range(startRange, string.Concat(first, last));
			_range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
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
			var properties = (
				from property in typeof(T).GetProperties()
				where Attribute.IsDefined(property, typeof(OrderAttribute))
				orderby ((OrderAttribute)property.GetCustomAttributes(typeof(OrderAttribute), false).Single()).Order
				select property
			).ToArray();

			List<object> objs = new List<object>();
			List<string> output = new List<string>();

			for (int i = 0; i < properties.Length; i++)
			{
				objs.Add(properties[i].Name);
			}
			object[] array = objs.ToArray();
			return array;
		}

		private object[] CreateHeader(List<string> cols)
		{
			var properties = (
				from property in typeof(T).GetProperties()
				where Attribute.IsDefined(property, typeof(OrderAttribute)) && cols.Contains(property.Name)
				orderby ((OrderAttribute)property.GetCustomAttributes(typeof(OrderAttribute), false).Single()).Order
				select property
			).ToArray();

			List<object> objs = new List<object>();
			List<string> output = new List<string>();

			for (int i = 0; i < properties.Length; i++)
			{
				objs.Add(properties[i].Name);
			}
			object[] array = objs.ToArray();
			return array;
		}

		private void FillSheet()
		{
			WriteData(CreateHeader());
		}

		private void FillSheet(List<string> cols)
		{
			WriteData(CreateHeader(cols));
		}

		private void FillSheet(string separateBy)
		{
			WriteData(CreateHeader(), separateBy);
			if ((_excelApp.ActiveSheet as _Worksheet).Range["A1"].Value2 != null)
			{
				_sheet = _sheets.Add();
				_sheet.Select();
			}
		}

		private void FillSheet(string separateBy, List<string> cols)
		{
			WriteData(CreateHeader(cols), separateBy);
			if ((_excelApp.ActiveSheet as _Worksheet).Range["A1"].Value2 != null)
			{
				_sheet = _sheets.Add();
				_sheet.Select();
			}
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

		public void GenerateReport(List<string> cols)
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
						FillSheet(cols);
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

		public void GenerateReport(List<User> users)
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
						foreach (User user in users)
						{
							FillSheet(user.UserName);
						}
						_sheet.Delete(); // get rid of the last sheet that we dont fill
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

		public void GenerateReport(List<User> users, List<string> cols)
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
						foreach (User user in users)
						{
							FillSheet(user.UserName, cols);
						}
						_sheet.Delete(); // get rid of the last sheet that we dont fill
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
					if (obj != null)
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
			_font = _range.Font;
			_font.Bold = true;
		}

		private void WriteData(object[] header)
		{
			AddExcelRows("A1", 1, header.Length, header);
			SetHeaderStyle();
			object[,] objArray = new object[dataToPrint.Count, header.Length];
			for (int i = 0; i < dataToPrint.Count; i++)
			{
				T item = dataToPrint[i];
				for (int j = 0; j < header.Length; j++)
				{
					object obj = typeof(T).InvokeMember(header[j].ToString(), BindingFlags.GetProperty, null, item, null);
					objArray[i, j] = obj == null ? "" : obj.ToString();
				}
			}
			AddExcelRows("A2", dataToPrint.Count, header.Length, objArray);
			AutoFitColumns("A1", dataToPrint.Count + 1, header.Length);
		}

		private void WriteData(object[] header, string separateBy)
		{
			List<T> filteredList = new List<T>();

			foreach (T t in dataToPrint)
			{
				if ((t as Entry).user_name == separateBy)
				{
					filteredList.Add(t);
				}
			}

			if (filteredList.Count == 0)
			{
				if (_sheets.Count > 1)
				{
					_sheet.Delete();
				}
				return;
			}

			AddExcelRows("A1", 1, header.Length, header);
			SetHeaderStyle();
			object[,] objArray = new object[filteredList.Count, header.Length];
			for (int i = 0; i < filteredList.Count; i++)
			{
				T item = filteredList[i];
				for (int j = 0; j < header.Length; j++)
				{
					object obj = typeof(T).InvokeMember(header[j].ToString(), BindingFlags.GetProperty, null, item, null);
					objArray[i, j] = obj == null ? "" : obj.ToString();
				}
			}
			AddExcelRows("A2", filteredList.Count, header.Length, objArray);
			AutoFitColumns("A1", filteredList.Count + 1, header.Length);
		}
	}
}