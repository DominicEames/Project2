using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Project2.ViewModel;

namespace Project2.Model
{
    public class Login
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Login() { }
        public Login(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public bool CheckInformation()
        {
            if (this.Username != null && this.Password != null)
                return true;
            else
                return false;
        }
    }
}
