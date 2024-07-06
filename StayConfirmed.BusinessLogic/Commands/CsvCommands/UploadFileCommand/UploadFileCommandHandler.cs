using ExcelDataReader;
using StayConfirmed.BusinessLogic.CommandExecutor;
using System.Data;
using System.Text;

namespace StayConfirmed.BusinessLogic.Commands.CsvCommands.UploadFileCommand;

public class UploadFileCommandHandler
    : ICommandHandler<UploadFileCommandRequest, UploadFileCommandResponse>
{
    public async Task<UploadFileCommandResponse> Handle(UploadFileCommandRequest command)
    {
        try
        {
            var people = new List<Person>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = new MemoryStream())
            {
                await command.File.CopyToAsync(stream);
                stream.Position = 0;

                using var reader = ExcelReaderFactory.CreateReader(stream);
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = false
                    }
                });

                var dataTable = result.Tables[0];

                foreach (DataRow row in dataTable.Rows)
                {
                    if (!int.TryParse(row[2].ToString(), out int age))
                    {
                        return new UploadFileCommandResponse
                        {
                            Status = false,
                            Message = $"Invalid age value at row {row.Table.Rows.IndexOf(row) + 1}"
                        };
                    }

                    var person = new Person
                    {
                        FirstName = row[0].ToString(),
                        LastName = row[1].ToString(),
                        Age = age
                    };
                    people.Add(person);
                }
            }
        
            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName},{person.LastName},{person.Age}");
            }

            return new UploadFileCommandResponse
            {
                Status = true,
                Message = "Information uploaded successfully"
            };
        }
        catch (Exception ex)
        {
            return new UploadFileCommandResponse
            {
                Status = false,
                Message = ex.Message
            };
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
