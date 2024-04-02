using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApp.Models
{
    public class User (Guid id, string userName, string email,string phone, string password) 
    {
        public Guid Id { get; set; } = id;
        public string UserName { get; set; } = userName;
        public string Phone { get; set; } = phone;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
    }
}
