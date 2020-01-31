using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Response
{
    public class LoginResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Token { get; set; }
    }
}
