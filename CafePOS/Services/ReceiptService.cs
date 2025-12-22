using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using CafePOS.Models;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CafePOS.Services
{
    public class ReceiptService
    {
        public void GenerateReceipt(ObservableCollection<MenuItem> items, decimal total)
        {
            try
            {
                // Must be first
                QuestPDF.Settings.License = LicenseType.Community;

                // Create a path that DEFINITELY works (Your Documents folder)
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(folderPath, $"CafeReceipt_{DateTime.Now:HHmmss}.pdf");

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A6);
                        page.Margin(1, Unit.Centimetre);
                        page.PageColor(Colors.White);

                        // Use a standard system font to avoid 'Lato' loading errors for now
                        page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Verdana));

                        page.Header().Text("☕ CafePOS").FontSize(20).SemiBold().AlignCenter();

                        page.Content().PaddingVertical(10).Column(col =>
                        {
                            foreach (var item in items)
                            {
                                col.Item().Row(row =>
                                {
                                    row.RelativeItem().Text(item.Name);
                                    row.ConstantItem(50).AlignRight().Text($"{item.Price} RON");
                                });
                            }
                        });

                        page.Footer().PaddingTop(10).Column(col =>
                        {
                            col.Item().LineHorizontal(1);
                            col.Item().PaddingTop(5).Row(row =>
                            {
                                row.RelativeItem().Text("TOTAL").Bold();
                                row.ConstantItem(80).AlignRight().Text($"{total:N2} RON").Bold();
                            });
                        });
                    });
                }).GeneratePdf(filePath);

                // Open the folder so you can see it
                Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            catch (Exception ex)
            {
                // This will tell us EXACTLY why it's failing
                System.Windows.MessageBox.Show("PDF Error: " + ex.Message);
            }
        }
    }
}
