using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.Shared.Enums;

namespace UserDataStoreApp.Shared.Services
{
    public interface ILogger
    {
        void TraceError(string title, string message, SeverityLevel severityLevel);
    }
}
