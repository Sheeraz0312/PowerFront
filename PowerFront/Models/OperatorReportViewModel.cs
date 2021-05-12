using System;
using System.Linq;
using System.Web;

namespace PowerFront.Models
{
    public class OperatorReportViewModel
    {
        public int ID { get; set; }
        public string Name { get; set;}
        public string ProactiveSent { get; set; }
        public string ProactiveAnswered { get; set; }
        public string ProactiveResponseRate { get; set; }
        public string ReactiveReceived { get; set; }
        public string ReactiveAnswered { get; set; }
        public string ReactiveResponseRate { get; set; }
        public string TotalChatLength { get; set; }
        public string AverageChatLength { get; set; }
    }
}