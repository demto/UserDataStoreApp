using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.Shared.Enums;
using UserDataStoreApp.Shared.Services;

namespace UserDataStoreApp.Logger
{
    public class GenericLoggerAdapter : ILogger
    {
        public void TraceError(string title, string message, SeverityLevel severityLevel)
        {
            throw new NotImplementedException();
        }
    }
}
