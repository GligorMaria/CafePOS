using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CafePOS.Models;

namespace CafePOS.Services
{
    public class SalesLogServices
    {
        private readonly string logDir = "SalesLogs";

        public SalesLogServices()
        {
            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
        }

        public async Task LogSaleAsync(SaleTransaction transaction)
        {
            string fileName = Path.Combine(logDir, $"{DateTime.Now:yyyy-MM-dd}.json");
            List<SalesLogEntry> entries = new();
            if (File.Exists(fileName))
            {
                string oldJson = await File.ReadAllTextAsync(fileName);
                entries = JsonSerializer.Deserialize<List<SalesLogEntry>>(oldJson) ?? new List<SalesLogEntry>();
            }

            entries.Add(new SalesLogEntry
            {
                Timestamp = DateTime.Now,
                Receipt = transaction.GetReceipt()
            });

            string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(fileName, json);
        }
    }
}