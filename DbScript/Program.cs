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
                    var dataRetrievalService = new DataRetrivalService(context);
                    var nodeHistoryData = dataRetrievalService.GetNodeHistoryData();

                    var fileInfo = new FileInfo("testFileEnd.xlsx");

                    using (var excelPackage = new ExcelPackage(fileInfo))
                    {
                        var worksheet = excelPackage.Workbook.Worksheets.Add("test");

                        worksheet.Cells.LoadFromCollection(nodeHistoryData, true);

                        worksheet.Cells.AutoFitColumns();

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