using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using LargeXlsx;
using DbScript.Database.Views;

namespace DbScript.Excel
{
    public class ExcelWriter
    {
        public string startColumn {  get; set; }
        public int rowIndex { get; set; }
        public int columnIndex {  get; set; }
        public string lastColumn { get; set; }
        public string currentColumn { get; set; }
        public DateTime startInterval { get; set; }
        public DateTime endInterval { get; set; }



    }
}
