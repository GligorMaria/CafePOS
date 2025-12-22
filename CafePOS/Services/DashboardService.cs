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
using CafePOS.Models;

namespace CafePOS.Services
{
    public class DashboardService
    {
        public async Task<Dictionary<int, decimal>> GetHourlySalesAsync(string dateFile)
        {
            if (!File.Exists(dateFile)) return new Dictionary<int, decimal>();
    
    string json = await File.ReadAllTextAsync(dateFile);
    var entries = JsonSerializer.Deserialize<List<SalesLogEntry>>(json);
    
    if (entries == null) return new Dictionary<int, decimal>();

    return entries
        .GroupBy(e => e.Timestamp.Hour)
        // FIX: Removed 'global =>' and used 'g' correctly
        .ToDictionary(
            g => g.Key, 
            g => g.Sum(x => ExtractTotalFromReceipt(x.Receipt))
        );
}

private decimal ExtractTotalFromReceipt(string receipt)
{
    if (string.IsNullOrWhiteSpace(receipt)) return 0;

    var lines = receipt.Split('\n');
    foreach (var line in lines.Reverse())
    {
        if (line.Contains("Final Total"))
        {
            try 
            {
                return decimal.Parse(line.Split(':')[1].Replace("RON", "").Trim());
            }
            catch 
            {
                return 0;
            }
        }
    }
    return 0;
}
    }
}