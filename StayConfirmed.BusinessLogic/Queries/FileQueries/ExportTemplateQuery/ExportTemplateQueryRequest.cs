using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Queries.CsvQueries.ExportTemplateQuery;

public sealed record ExportTemplateQueryRequest : ICommand<ExportTemplateQueryResponse> { }