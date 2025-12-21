using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using CafePOS.Models;

namespace CafePOS.Services
{
    public class SalesLogService
    {
        private readonly string _logFolder = "SalesLogs";

        public SalesLogService()
        {
            // Ensure the folder exists so the app doesn't crash when saving
            if (!Directory.Exists(_logFolder))
            {
                Directory.CreateDirectory(_logFolder);
            }
        }

        public void LogSale(SaleTransaction transaction)
        {
            // Create a filename based on today's date
            string fileName = Path.Combine(_logFolder, $"{DateTime.Now:yyyy-MM-dd}.json");
            
            List<SalesLogEntry> entries;

            // Load existing sales if the file exists
            if (File.Exists(fileName))
            {
                string existingJson = File.ReadAllText(fileName);
                entries = JsonSerializer.Deserialize<List<SalesLogEntry>>(existingJson) ?? new List<SalesLogEntry>();
            }
            else
            {
                entries = new List<SalesLogEntry>();
            }

            // Add the new sale
            entries.Add(new SalesLogEntry 
            { 
                Timestamp = transaction.Timestamp, 
                Receipt = transaction.GetReceipt() 
            });

            // Save back to the file
            string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
    }
}