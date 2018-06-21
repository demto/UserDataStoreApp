using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.BusinessLogic.Domain;
using UserDataStoreApp.DataAccess;
using UserDataStoreApp.Shared.Enums;
using UserDataStoreApp.Shared.Services;

namespace UserDataStoreApp.Logger
{
    public class GenericLoggerAdapter : ILogger
    {
        public void TraceError(string title, string message, SeverityLevel severityLevel)
        {
            using(var context = new UserDataContext()){
                context.TraceMessage.Add(
                    new TraceMessage(title, message, severityLevel, DateTime.UtcNow)
                );
            }
        }
    }
}
