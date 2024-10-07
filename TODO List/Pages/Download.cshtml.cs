using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TODO_List.Models;

namespace TODO_List.Pages
{
    public class DownloadModel : PageModel
    {
        ApplicationContext context;

        public DownloadModel(ApplicationContext db)
        {
            context = db;
        }

        public FileResult OnGet()
        {
            List<Models.Task> tasks = new List<Models.Task>();

            tasks = context.Tasks.ToList();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Tasks");

            worksheet.Cell("A1").Value = "ID";
            worksheet.Cell("B1").Value = "Название";
            worksheet.Cell("C1").Value = "Описание";
            worksheet.Cell("D1").Value = "Дата начала";
            worksheet.Cell("E1").Value = "Дата окончания";
            worksheet.Cell("F1").Value = "Срочность";
            worksheet.Cell("G1").Value = "Завершено?";



            int rowNumber = 2;
            foreach (var item in tasks)
            {
                if (item is null) continue;
                worksheet.Cell("A" + rowNumber).Value = item.Id;
                worksheet.Cell("B" + rowNumber).Value = item.Name ?? "";
                worksheet.Cell("C" + rowNumber).Value = item.Description ?? "";
                worksheet.Cell("D" + rowNumber).Value = item.Fromdate;
                worksheet.Cell("E" + rowNumber).Value = item.Todate;
                worksheet.Cell("F" + rowNumber).Value = item.Urgency ?? "";
                worksheet.Cell("G" + rowNumber).Value = item.Iscompleted ? "Да" : "Нет";
                rowNumber++;
            }

            using (MemoryStream stream = new())
            {
                workbook.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
            }
        }
    }
}
