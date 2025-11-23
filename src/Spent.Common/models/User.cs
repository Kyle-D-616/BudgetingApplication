using System;
using System.Collections.Generic;
using System.Text;

namespace Spent.Common.models
{
    public class User
    {
        public GuId Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public sting FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastLogInAt { get; set; }

    }
}
