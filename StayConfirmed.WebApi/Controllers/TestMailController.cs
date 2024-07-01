using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StayConfirmed.DataAccess.Entities;
using System.Runtime;

namespace StayConfirmed.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestMailController : ControllerBase
    {

        [HttpPost("sendMail")]
        public IActionResult ReservationEmailSend()
        {
            try
            {
                var _From = new Mailer.MailAddress() { Email = "check@stayconfirmed.com" };
                //var _Tos = Data.To
                //    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                //    .ToList().
                //    ConvertAll(m => new Mailer.MailAddress() { Email = m })
                //    .ToArray();

                //var _CCs = new Mailer.MailAddress[0];
                //if (!string.IsNullOrEmpty(Data.CC))
                //    _CCs =
                //    Data.CC
                //    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                //    .ToList().ConvertAll(m => new Mailer.MailAddress() { Email = m }).ToArray();

                //var _Att = new List<Mailer.Attachment>();
                //if (Data.Files != null)
                //{
                //    foreach (var file in Data.Files)
                //    {
                //        using var memoryStream = new MemoryStream();
                //        file.CopyTo(memoryStream);
                //        _Att.Add(new Mailer.Attachment() { ContentType = file.ContentType, Filename = file.FileName, Content = memoryStream.ToArray() });
                //    }
                //}

                List<string> list = new List<string>
                {
                    "sergi.lomtadze@gmail.com",
                };
                
                var to = list.ConvertAll(m => new Mailer.MailAddress() { Email = m })
                    .ToArray();
                var _Mail = new Mailer.Mail()
                {
                    From = _From,
                    To = to,
                    //Cc = l,
                    Subject = "test mail from stayconfirmed",
                    Body = "some body for sending",
                    isBodyHtml = true,
                    Smtp = "15",
                    //Attachments = _Att.ToArray()
                };
                var _X = new Mailer.MailerClient();

                var t = _X.SendMailAsync(_Mail).Result;

                return Ok();
            }
            catch (Exception ex)
            {
                //var error = $"ships/list error:";
                //_Logger.LogError(ex, error + ex.Message);
                //return StatusCode(500, new M3HttpResponse<object>
                //{
                //    Exception = ex.Message
                //});
                return BadRequest();
            }
        }

    }
}
