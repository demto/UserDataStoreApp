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

        public TraceMessage(string title, string message, SeverityLevel severity, DateTime dateTime){
            this.Title = title;
            this.MessageText = message;
            this.Severity = severity;
            this.UtcDateTime = dateTime; 
        }
    }
}
