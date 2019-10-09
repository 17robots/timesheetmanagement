using System;
using System.Windows.Input;

namespace FivesBronxTimesheetManagement.Classes
{
	public class WaitCursor : IDisposable
	{
		private Cursor _previousCursor;

		public WaitCursor()
		{
			this._previousCursor = Mouse.OverrideCursor;
			Mouse.OverrideCursor = Cursors.Wait;
		}

		public void Dispose()
		{
			Mouse.OverrideCursor = this._previousCursor;
		}
	}
}