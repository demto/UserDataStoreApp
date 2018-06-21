using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataStoreApp.Shared.Enums;

namespace UserDataStoreApp.BusinessLogic.Domain
{
    public class TraceMessage
    {
        public int TraceMessageId { get; set; }
        public string Title { get; set; }
        public string MessageText { get; set; }
        public SeverityLevel Severity { get; set; }
        public DateTime UtcDateTime { get; set; }
    }
}
