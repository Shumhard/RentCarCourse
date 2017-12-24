using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Client
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string FullName
        {
            get
            {
                var fullName = "";
                fullName += string.IsNullOrEmpty(LastName) ? "" : LastName;
                fullName += string.IsNullOrEmpty(FirstName) ? "" : string.IsNullOrEmpty(fullName) ? FirstName : " " + FirstName;
                fullName += string.IsNullOrEmpty(Patronymic) ? "" : string.IsNullOrEmpty(fullName) ? Patronymic : " " + Patronymic;
                return fullName;
            }
        }
        public string ShortName
        {
            get
            {
                var shortName = "";
                shortName += string.IsNullOrEmpty(LastName) ? "" : LastName;
                shortName += string.IsNullOrEmpty(FirstName) ? "" : string.IsNullOrEmpty(shortName) ? FirstName.Substring(0, 1) + "." : " " + FirstName.Substring(0, 1) + ".";
                shortName += string.IsNullOrEmpty(Patronymic) ? "" : string.IsNullOrEmpty(shortName) ? Patronymic.Substring(0, 1) + "." : " " + Patronymic.Substring(0, 1) + ".";
                return shortName;
            }
        }
        public DateTime? Birthday { get; set; }
        public string Sex { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BankCard { get; set; }
        public string Login { get; set; }
        public string ImagePath { get; set; }
    }
}
