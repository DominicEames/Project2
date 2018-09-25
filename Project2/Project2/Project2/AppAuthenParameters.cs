using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    public class AppAuthenParameters
    {
        public static string AppName = "Project2";

        public static string AndroidClientId = "570271425109-6jail7euh9sh2h2i2kba73b29msfsvlv.apps.googleusercontent.com";

        public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
        public static string AuthorizeUrl = "https://www.accounts.google.com/oauth2/auth";
        public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

        public static string AndroidRedirectUrl = "com.googleusercontent.apps.570271425109-6jail7euh9sh2h2i2kba73b29msfsvlv:/oauth2redirect";
    }
}
