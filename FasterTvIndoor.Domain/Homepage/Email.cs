using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.Homepage
{
    public class Email
    {
        public Email(string subject, string description, string email, string phone, string name)
        {
            this.Subject = subject;
            this.Description = description;
            this.EmailUser = email;
            this.Phone = phone;
            this.Name = name;
        }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string EmailUser { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
    }
}
