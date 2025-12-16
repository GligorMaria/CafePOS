using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using TheCozyCupPOS.Models;

namespace TheCozyCupPOS.Services
{
    public class DashboardService
    {
        public async Task<Dictionary<int, decimal>> GetHourlySalesAsync(string dateFile)
        {
            if (!File.Exists(dateFile)) return new Disctionary<int, decimal>();
            string json = await File.ReadAllTextAsync(dateFile);
            var entries = JsonSerializer.Deserialize<List<SalesLogEntry>>(json);
            return entries
                .GroupBy(e => e.Timestamp.Hour)
                .ToDictionary(g => g.Key, global => g.Sum(x => ExtractTotalFromReceipt(x.Receipt)));
        }

        private decimal ExtractTotalFromReceipt(string receipt)
        {
            var lines = receipt.Split('\n');
            foreach (var line in lines.Reverse())
                if (line.Contains("Final Total"))
                    return decimal.Parse(line.Split(':')[1].Replace("RON", "").Trim());
            return 0;
        }
    }
}