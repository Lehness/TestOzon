using apiEmail.Models;
using Microsoft.Extensions.Options;

namespace apiEmail.Services
{
    public class DbService
    {

        private ApContext _db;

        public DbService(ApContext context)
        {
            _db = context;
        }
        public void DbInsertMail(Email email_body, string result)
        {
            DbEmail dbEmail = new DbEmail(email_body, result);
            _db.DbEmails.Add(dbEmail);
            _db.SaveChanges();
        }
    }
}
