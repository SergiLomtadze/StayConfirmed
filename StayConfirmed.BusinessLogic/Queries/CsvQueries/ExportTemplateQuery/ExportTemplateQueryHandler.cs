using ClosedXML.Excel;
using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Queries.CsvQueries.ExportTemplateQuery;

public class ExportTemplateQueryHandler : ICommandHandler<ExportTemplateQueryRequest, ExportTemplateQueryResponse>
{
    public Task<ExportTemplateQueryResponse> Handle(ExportTemplateQueryRequest command)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Sheet1");

        var headerRow = worksheet.Row(1);
        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

        worksheet.Cell(1, 1).Value = "Header 1";
        worksheet.Cell(1, 2).Value = "Header 2";
        worksheet.Cell(1, 3).Value = "Header 3";

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return Task.FromResult(new ExportTemplateQueryResponse
        {
            Bytes = stream.ToArray()
        });
    }
}
