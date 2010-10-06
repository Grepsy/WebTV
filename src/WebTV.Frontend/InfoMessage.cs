using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTV.Frontend {
    public class InfoMessage {
        public enum InfoType {
            Error,
            Notice,
            Information
        }

        public string Message { get; set; }
        public InfoMessage.InfoType Type { get; set;}

        public InfoMessage(string message, InfoType type) {
            Message = message;
            Type = type;
        }
    }
}