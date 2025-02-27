﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions;
using apiEmail.Models;
using Microsoft.Extensions.Options;

namespace apiEmail.Services
{
    public class SmtpService
    {
        private readonly IOptions<SettingsModel> config;

        public SmtpService(IOptions<SettingsModel> config)
        {
            this.config = config;
        }
        public string SendEmail(string email, List<string> copies, string subject, string message)
        {

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("MPEI PIRS", config.Value.Address));
            emailMessage.To.Add(new MailboxAddress("", email));
            if (copies.Count != 0)
            {
                foreach (string copy in copies)
                    emailMessage.Cc.Add(new MailboxAddress("", copy));
            }
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect(config.Value.SmtpServer, config.Value.SmtpPort, false);
                client.Authenticate(config.Value.SmtpLogin, config.Value.SmtpPass);
                string res = client.Send(emailMessage);
                client.Disconnect(true);
                return res;
            }
        }
    }
}
