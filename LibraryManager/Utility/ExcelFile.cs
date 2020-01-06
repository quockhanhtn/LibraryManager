using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace LibraryManager.Utility
{
    public class ExcelFile
    {
        /// <summary>
        /// Tạo boder xung quanh cell tại hàng "rowIndex" và cột "colIndex" của shet "ws"
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        public static void FormatCellBorder(ExcelWorksheet ws, int rowIndex, int colIndex)
        {
            var cell = ws.Cells[rowIndex, colIndex];

            //căn chỉnh các border
            var border = cell.Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
        }

        /// <summary>
        /// Mở file Excel có đường dẫn "path"
        /// </summary>
        /// <param name="path"></param>
        public static void OpenFile(string path) 
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbooks workbooks = excelApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook sheet = workbooks.Open(path);
        }
    }
}
