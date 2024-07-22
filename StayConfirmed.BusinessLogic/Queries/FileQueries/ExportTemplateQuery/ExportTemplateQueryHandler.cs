using ClosedXML.Excel;
using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Queries.CsvQueries.ExportTemplateQuery;

public class ExportTemplateQueryHandler : ICommandHandler<ExportTemplateQueryRequest, ExportTemplateQueryResponse>
{
    public Task<ExportTemplateQueryResponse> Handle(ExportTemplateQueryRequest command)
    {
        using var workbook = new XLWorkbook();

        var confirmationInfoWorksheet = workbook.Worksheets.Add("Confirmation Info");
        var confirmationInfoWorksheetHeaderRow = confirmationInfoWorksheet.Row(1);
        confirmationInfoWorksheetHeaderRow.Style.Font.Bold = true;
        //headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

        confirmationInfoWorksheet.Cell(1, 1).Value = "Brand Name";
        confirmationInfoWorksheet.Cell(1, 2).Value = "Customer Reservation Code";
        confirmationInfoWorksheet.Cell(1, 3).Value = "Booking Date";
        confirmationInfoWorksheet.Cell(1, 4).Value = "CeckIn Date";
        confirmationInfoWorksheet.Cell(1, 5).Value = "CheckOut Date";
        confirmationInfoWorksheet.Cell(1, 6).Value = "Room Name";
        confirmationInfoWorksheet.Cell(1, 7).Value = "Meal Plan";
        confirmationInfoWorksheet.Cell(1, 8).Value = "Provider Reservation Code";
        confirmationInfoWorksheet.Cell(1, 9).Value = "Property Name";
        confirmationInfoWorksheet.Cell(1, 10).Value = "Property Address";
        confirmationInfoWorksheet.Cell(1, 11).Value = "Property City";
        confirmationInfoWorksheet.Cell(1, 12).Value = "Property Country";
        confirmationInfoWorksheet.Cell(1, 13).Value = "ISO Country Code";
        confirmationInfoWorksheet.Cell(1, 14).Value = "Property Phone";
        confirmationInfoWorksheet.Cell(1, 15).Value = "Property Email";
        confirmationInfoWorksheet.Cell(1, 16).Value = "Customer Code For Property";
        confirmationInfoWorksheet.Cell(1, 17).Value = "Provider Code For Property";
        confirmationInfoWorksheet.Cell(1, 18).Value = "Giata Code For Property";
        confirmationInfoWorksheet.Cell(1, 19).Value = "Day Before Check (hour)";
        confirmationInfoWorksheet.Cell(1, 20).Value = "Priority";
        confirmationInfoWorksheet.Cell(1, 21).Value = "Contact Email";
        confirmationInfoWorksheet.Cell(1, 22).Value = "Check or Cancelation";
        confirmationInfoWorksheet.Cell(1, 23).Value = "Total Pax";
        confirmationInfoWorksheet.Cell(1, 24).Value = "Person1 Name";
        confirmationInfoWorksheet.Cell(1, 25).Value = "Person1 Surname";
        confirmationInfoWorksheet.Cell(1, 26).Value = "Person1 Gendern";
        confirmationInfoWorksheet.Cell(1, 27).Value = "Person1 Birth Date";
        confirmationInfoWorksheet.Cell(1, 28).Value = "Person1 Age";
        confirmationInfoWorksheet.Cell(1, 29).Value = "Person2 Name";
        confirmationInfoWorksheet.Cell(1, 30).Value = "Person2 Surname";
        confirmationInfoWorksheet.Cell(1, 31).Value = "Person2 Gendern";
        confirmationInfoWorksheet.Cell(1, 32).Value = "Person2 Birth Date";
        confirmationInfoWorksheet.Cell(1, 33).Value = "Person2 Age";
        confirmationInfoWorksheet.Cell(1, 34).Value = "Person3 Name";
        confirmationInfoWorksheet.Cell(1, 35).Value = "Person3 Surname";
        confirmationInfoWorksheet.Cell(1, 36).Value = "Person3 Gendern";
        confirmationInfoWorksheet.Cell(1, 37).Value = "Person3 Birth Date";
        confirmationInfoWorksheet.Cell(1, 38).Value = "Person3 Age";
        confirmationInfoWorksheet.Cell(1, 39).Value = "Person4 Name";
        confirmationInfoWorksheet.Cell(1, 40).Value = "Person4 Surname";
        confirmationInfoWorksheet.Cell(1, 41).Value = "Person4 Gendern";
        confirmationInfoWorksheet.Cell(1, 42).Value = "Person4 Birth Date";
        confirmationInfoWorksheet.Cell(1, 43).Value = "Person4 Age";

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return Task.FromResult(new ExportTemplateQueryResponse
        {
            Bytes = stream.ToArray()
        });
    }
}
