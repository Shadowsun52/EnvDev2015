using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrigoApp.Model
{
    public class User
    {
        public String id { get; set; }

        [JsonProperty(PropertyName = "login")]
        public String Login { get; set; }

        [JsonProperty(PropertyName = "password")]
        public String Password { get; set; }

        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }

        public User()
        {

        }

        public User(String login, String password, String email)
        {
            Login = login;
            Password = password;
            Email = email;
        }

        public override String ToString()
        {
            return Login;
        }
    }
}
