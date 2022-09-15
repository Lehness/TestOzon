using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiEmail.Models;
using apiEmail.Services;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace apiEmail.Controllers
{
    [Route("v1/api/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {

        private readonly IOptions<SettingsModel> config;

        private ApContext db;
        public EmailsController(ApContext context, IOptions<SettingsModel> config)
        {
            this.config = config;
            db = context;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonSerializer.Serialize(db.DbEmails.ToList());//серелиализация списка объектов базы данных
        }


        [HttpPost]
        public async Task<string> Post([FromBody] Email email_body)
        {
            SmtpService smtpserv = new SmtpService(config);
            Task<string> result = smtpserv.SendEmailAsync(email_body.recipient, email_body.carbon_copy_recipients, email_body.subject, email_body.text); //отправка сообщения электронной почты
            result.Wait();
            DbEmail dbEmail = new DbEmail(email_body, result.Result);
            db.DbEmails.Add(dbEmail);
            await db.SaveChangesAsync();
            return result.Result;
        }

    }
}
