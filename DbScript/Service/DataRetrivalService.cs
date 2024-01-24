using DbScript.Database.Views;
using DbScript.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScript.Service
{
    public class DataRetrivalService // : IDataRetrivalService 
    {
        private readonly PostgresContext _context; // приватное свойство для контекста 

        public DataRetrivalService(PostgresContext context) // конструктор 
        { 
            _context = context; 
        }
        public List<Nodehistoryview> GetNodeHistoryData() // метод для получения данных 
        {
            return _context.Nodehistoryviews.ToList();              // возвращаем данные 
        }
    }
}
