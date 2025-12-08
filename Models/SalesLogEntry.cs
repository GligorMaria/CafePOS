using System;

namespace CafePOS.Models
{
    public class SalesLogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Receipt { get; set; } = "";
    }
}