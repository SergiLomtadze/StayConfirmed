using ClosedXML.Excel;
using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Queries.CsvQueries.ExportTemplateQuery;

public class ExportTemplateQueryHandler : ICommandHandler<ExportTemplateQueryRequest, ExportTemplateQueryResponse>
{
    public Task<ExportTemplateQueryResponse> Handle(ExportTemplateQueryRequest command)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("ConfirmationInfo");

        var headerRow = worksheet.Row(1);
        headerRow.Style.Font.Bold = true;
        //headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

        worksheet.Cell(1, 1).Value = "Brand Name";
        worksheet.Cell(1, 2).Value = "Customer Reservation Code";
        worksheet.Cell(1, 3).Value = "Booking Date";
        worksheet.Cell(1, 4).Value = "CeckIn Date";
        worksheet.Cell(1, 5).Value = "CheckOut Date";
        worksheet.Cell(1, 6).Value = "Room Name";
        worksheet.Cell(1, 7).Value = "Meal Plan";
        worksheet.Cell(1, 8).Value = "Provider Reservation Code";
        worksheet.Cell(1, 9).Value = "Property Name";
        worksheet.Cell(1, 10).Value = "Property Address";
        worksheet.Cell(1, 11).Value = "Property City";
        worksheet.Cell(1, 12).Value = "Property Country";
        worksheet.Cell(1, 13).Value = "Property Phone";
        worksheet.Cell(1, 14).Value = "Property Email";
        worksheet.Cell(1, 15).Value = "Customer Code For Property";
        worksheet.Cell(1, 16).Value = "Provider Code For Property";
        worksheet.Cell(1, 17).Value = "Giata Code For Property";
        worksheet.Cell(1, 18).Value = "Day Before Check (hour)";
        worksheet.Cell(1, 19).Value = "Priority";
        worksheet.Cell(1, 20).Value = "Contact Email";
        worksheet.Cell(1, 21).Value = "Check or Cancelation";
        worksheet.Cell(1, 22).Value = "Person1 Name";
        worksheet.Cell(1, 23).Value = "Person1 Surname";
        worksheet.Cell(1, 24).Value = "Person1 Gendern";
        worksheet.Cell(1, 25).Value = "Person1 Birth Date";
        worksheet.Cell(1, 26).Value = "Person1 Age";
        worksheet.Cell(1, 27).Value = "Person2 Name";
        worksheet.Cell(1, 28).Value = "Person2 Surname";
        worksheet.Cell(1, 29).Value = "Person2 Gendern";
        worksheet.Cell(1, 30).Value = "Person2 Birth Date";
        worksheet.Cell(1, 31).Value = "Person2 Age";
        worksheet.Cell(1, 32).Value = "Person3 Name";
        worksheet.Cell(1, 33).Value = "Person3 Surname";
        worksheet.Cell(1, 34).Value = "Person3 Gendern";
        worksheet.Cell(1, 35).Value = "Person3 Birth Date";
        worksheet.Cell(1, 36).Value = "Person3 Age";
        worksheet.Cell(1, 37).Value = "Person4 Name";
        worksheet.Cell(1, 38).Value = "Person4 Surname";
        worksheet.Cell(1, 39).Value = "Person4 Gendern";
        worksheet.Cell(1, 40).Value = "Person4 Birth Date";
        worksheet.Cell(1, 41).Value = "Person4 Age";

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return Task.FromResult(new ExportTemplateQueryResponse
        {
            Bytes = stream.ToArray()
        });
    }
}
