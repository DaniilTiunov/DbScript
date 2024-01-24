using DbScript.Database.Views;
using DbScript.DBContext;
using DbScript.Excel;
using DbScript.Service;
using LargeXlsx;
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
                Stopwatch stopwatch = new(); // Инициализируем таймер
                stopwatch.Start(); // Запускаем таймер

                using (var context = new PostgresContext())
                {
                    DateTime dateTime = DateTime.Now;
                    DateTime startDate = new DateTime(2024, 1, 16);
                    DateTime endDate = new DateTime(2024, 1, 17);

                    var dataRetrievalService = new DataRetrivalService(context);

                    var nodeHistoryData = dataRetrievalService.GetNodeHistoryData();

                    double averagePvValue = nodeHistoryData
                        .Where(data => data.Valdouble.HasValue
                        && data.Actualtime >= startDate && data.Actualtime <= endDate)
                        .Average(data => data.Valdouble.Value);

                    var fileInfo = new FileInfo("test.xlsx");

                    //if (fileInfo.Exists)
                    //{
                    //    fileInfo.Delete();
                    //}

                    using (var excelPackage = new ExcelPackage(fileInfo))
                    {
                        var worksheet = excelPackage.Workbook.Worksheets["Kotl"];

                        worksheet.Cells["G8"].Value = averagePvValue;
                        worksheet.Cells["D8"].Value = dateTime;

                        excelPackage.Save();
                    }

                    Console.WriteLine("Данные успешно экспортированы в Excel.");
                }

                stopwatch.Stop(); // Останавливаем таймер 
                Console.WriteLine($"Время работы программы - {stopwatch.ElapsedMilliseconds} мс"); // Выводим время работы программы
            }
            catch (Exception ex) // При возникновении ошибки выводим ее в консоль 
            {
                Console.WriteLine($"Источник проблемы: {ex.Source},\nСообщение: {ex.Message}"); // Выводим источник проблемы и сообщение 
            }
        }
    }
}