using DbScript.Database.Views;
using DbScript.DBContext;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Diagnostics;


namespace DbScript
{    
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                using PostgresContext context = new PostgresContext();

                Device[] devices = {
                    new Device("REGUL_SMC306_07.01_AI.CRATE03_AI12.TI0142_4200.PV.DATA_VALUE", "G"),
                    new Device("REGUL_SMC306_07.01_AI.CRATE03_AI12.TI0143_4200.PV.DATA_VALUE", "H"),
                    new Device("REGUL_SMC306_07.01_AI.CRATE01_AI00.GAI1001_4200.PV.DATA_VALUE", "J"),

                };

                string[] availableDevices = devices.Select(device => device.Name).ToArray();
                IEnumerable<Nodehistoryview> devicesData = context.Nodehistoryviews
                    .Where(node => availableDevices.Contains(node.Tagname))
                    .AsNoTracking()
                    .AsEnumerable();

                if (devicesData.Any())
                {
                    FileInfo fileInfo = new FileInfo("test.xlsx");
                    using ExcelPackage excelPackage = new ExcelPackage(fileInfo);
                    var worksheet = excelPackage.Workbook.Worksheets["Kotl"];

                    foreach (Device device in devices)
                    {
                        IEnumerable<Nodehistoryview> history = devicesData.Where(node => node.Tagname.Equals(device.Name)).AsEnumerable();
                        int startRow = 8;

                        if (!history.Any())
                        {
                            continue;
                        }

                        DateTime startTime = (DateTime.Today).AddHours(-2);
                        DateTime endTime = startTime.AddHours(2);

                        for (int k = 0; k < 12; k++)
                        {
                            IEnumerable<double> values = history
                                .Where(node => node.Actualtime >= startTime && node.Actualtime <= endTime)
                                .Select(node => node.Valdouble ?? .0)
                                .AsEnumerable();

                            double average = values.Any() ? values.Average() : .0;

                            Console.WriteLine($"{device.Name} {startTime:HH:mm} - {endTime:HH:mm} avg = {Math.Round(average, 2)}");

                            string cell = $"{device.Column}{startRow++}";

                            worksheet.Cells[cell].Value = average;

                            startTime = startTime.AddHours(2);
                            endTime = endTime.AddHours(2);
                        }
                    }

                    excelPackage.Save();
                }
                else
                {
                    Console.WriteLine("Данные не получены");
                }

                stopwatch.Stop();
                Console.WriteLine($"Время работы программы - {stopwatch.ElapsedMilliseconds} мс");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Источник проблемы: {ex.Source},\nСообщение: {ex.Message}");
            }
        }
    }
}
