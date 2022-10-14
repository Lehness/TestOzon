using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiEmail.Models;
using apiEmail.Services;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace apiEmail.Controllers
{
    [Route("v1/api/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {

        private readonly IOptions<SettingsModel> _config;

        private ApContext _db;
        public EmailsController(ApContext context, IOptions<SettingsModel> config)
        {
            this._config = config;
            _db = context;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            return JsonSerializer.Serialize(_db.DbEmails.ToList());//серелиализация списка объектов базы данных
        }


        [HttpPost]
        public string Post([FromBody] Email email_body)
        {
            
                SmtpService smtpserv = new SmtpService(_config);
                string result = smtpserv.SendEmail(email_body.Recipient, email_body.Carbon_copy_recipients, email_body.Subject, email_body.Text); //отправка сообщения электронной почты
                DbService dbserv = new DbService(_db);
                dbserv.DbInsertMail(email_body, result);
                return result;
        }

    }
}
