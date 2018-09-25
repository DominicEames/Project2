using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project2.Model
{
    public class Token
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Acess_token { get; set; }
        public string Error_description { get; set; }
        public DateTime Expire_date { get; set; }

        public Token () { }
    }
}
