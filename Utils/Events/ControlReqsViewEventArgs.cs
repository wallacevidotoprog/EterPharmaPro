using System;
using System.Data;

namespace EterPharmaPro.Utils.Events
{
	public class ControlReqsViewEventArgs : EventArgs
	{
		public DataTable dataTable { get; private set; }

        public ControlReqsViewEventArgs(DataTable dataTable)
        {
			this.dataTable = dataTable;

		}
    }
}
