using apiEmail.Models;
using Microsoft.Extensions.Options;

namespace apiEmail.Services
{
    public class DbService
    {

        private ApContext db;

        public DbService(ApContext context)
        {
            db = context;
        }
        public void DbInsertMail(Email email_body, string result)
        {
            DbEmail dbEmail = new DbEmail(email_body, result);
            db.DbEmails.Add(dbEmail);
            db.SaveChanges();
        }
    }
}
