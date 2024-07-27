using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsEventLog
    {
        public static void EventLogger(string errorMessage)
        {
            string SourceName = "VehicleRentalManagmentSystem";

            if (!EventLog.SourceExists(SourceName))
                EventLog.CreateEventSource(SourceName, "Application");

            EventLog.WriteEntry(SourceName, errorMessage, EventLogEntryType.Error);
        }
    }
}
