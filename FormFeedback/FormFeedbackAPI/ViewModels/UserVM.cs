using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string NIK { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public string PhoneNumber { get; set; }
        public int Count { get; set; }
    }
}
