using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ResxUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== RESX Updater from Excel ===");

            //string excelPath = @"C:\Temp\Localization.xlsx"; // path to Excel
            //string resxFolder = @"C:\Projects\MyApp\Resources"; // path to Resources folder
            string resourceFileName = @"MenuItems";
            string excelPath = @"P:\musicz\Documents\Localization.xlsx"; // path to your Excel
            string resxFolder = @"P:\musicz\WebApp\IndianMusicz\Resources"; // path to your MVC Resources folder

            if (!File.Exists(excelPath))
            {
                Console.WriteLine("Excel file not found!");
                return;
            }

            if (!Directory.Exists(resxFolder))
            {
                Console.WriteLine("RESX folder not found!");
                return;
            }

            try
            {
                MergeExcelToResx(excelPath, resxFolder, resourceFileName);
                Console.WriteLine("All resource files updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void MergeExcelToResx(string excelPath, string resxFolderPath, string resourceFileName)
        {
            var workbook = new XLWorkbook(excelPath);
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RangeUsed().RowsUsed();

            // Read headers (first row)
            var headers = rows.First().Cells().Select(c => c.GetString()).ToList();

            for (int col = 1; col < headers.Count; col++) // skip first column (Key)
            {
                string cultureCode = headers[col]; // en-US, hi-IN, or-IN
                string resxFile; // = Path.Combine(resxFolderPath, $"AppResources.{cultureCode}.resx");
                if (cultureCode == "en")
                {
                    resxFile = Path.Combine(resxFolderPath, $"{resourceFileName}.resx");
                }
                else
                {
                    resxFile = Path.Combine(resxFolderPath, $"{resourceFileName}.{cultureCode}.resx");
                }

                XDocument doc;
                XElement root;

                if (File.Exists(resxFile))
                {
                    doc = XDocument.Load(resxFile);
                    root = doc.Element("root");
                }
                else
                {
                    // Create a new resx with standard headers
                    root = new XElement("root",
                        new XComment("Auto-generated resource file"),
                        new XElement("resheader",
                            new XAttribute("name", "resmimetype"),
                            new XElement("value", "text/microsoft-resx")
                        ),
                        new XElement("resheader",
                            new XAttribute("name", "version"),
                            new XElement("value", "2.0")
                        ),
                        new XElement("resheader",
                            new XAttribute("name", "reader"),
                            new XElement("value", "System.Resources.ResXResourceReader, System.Windows.Forms, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                        ),
                        new XElement("resheader",
                            new XAttribute("name", "writer"),
                            new XElement("value", "System.Resources.ResXResourceWriter, System.Windows.Forms, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                        )
                    );
                    doc = new XDocument(root);
                }

                // Build a dictionary of existing keys
                var existingResources = root.Elements("data")
                                            .Where(e => e.Attribute("name") != null)
                                            .ToDictionary(e => e.Attribute("name").Value, e => e);

                // Merge/update from Excel
                foreach (var row in rows.Skip(1))
                {
                    string key = row.Cell(1).GetString();
                    string value = row.Cell(col + 1).GetString();

                    if (existingResources.ContainsKey(key))
                    {
                        existingResources[key].Element("value").Value = value;
                    }
                    else
                    {
                        var dataElem = new XElement("data",
                            new XAttribute("name", key),
                            new XAttribute(XNamespace.Xml + "space", "preserve"),
                            new XElement("value", value)
                        );
                        root.Add(dataElem);
                    }
                }

                // Save resx
                doc.Save(resxFile);
                Console.WriteLine($"Updated: {resxFile}");
            }
        }

            static void MergeExcelToResx_old(string excelPath, string resxFolderPath, string resourceFileName)
        {
            var workbook = new XLWorkbook(excelPath);
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RangeUsed().RowsUsed();

            // Read headers (first row)
            var headers = rows.First().Cells().Select(c => c.GetString()).ToList();

            for (int col = 1; col < headers.Count; col++) // skip first column (Key)
            {
                string cultureCode = headers[col]; // en-US, hi-IN, or-IN
                string resxFile; // = Path.Combine(resxFolderPath, $"Resources.{cultureCode}.resx");
                if (cultureCode == "en")
                {
                    resxFile = Path.Combine(resxFolderPath, $"{resourceFileName}.resx");
                }
                else
                {
                    resxFile = Path.Combine(resxFolderPath, $"{resourceFileName}.{cultureCode}.resx");
                }

                // Load existing resx
                var doc = File.Exists(resxFile) ? XDocument.Load(resxFile) : new XDocument(new XElement("root"));
                var root = doc.Element("root");

                // Build a dictionary of existing keys
                var existingResources = root.Elements("data")
                                            .Where(e => e.Attribute("name") != null)
                                            .ToDictionary(e => e.Attribute("name").Value, e => e);

                // Merge/update from Excel
                foreach (var row in rows.Skip(1))
                {
                    string key = row.Cell(1).GetString();
                    string value = row.Cell(col + 1).GetString();

                    if (existingResources.ContainsKey(key))
                    {
                        existingResources[key].Element("value").Value = value;
                    }
                    else
                    {
                        var dataElem = new XElement("data",
                            new XAttribute("name", key),
                            new XAttribute(XNamespace.Xml + "space", "preserve"),
                            new XElement("value", value)
                        );
                        root.Add(dataElem);
                    }
                }

                // Save resx
                doc.Save(resxFile);
                Console.WriteLine($"Updated: {resxFile}");
            }
        }
    }
}



