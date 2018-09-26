using System;
using System.Collections.Generic;
using System.Text;
using Project2.View;

namespace Project2
{
    public class AppAuthenParameters
    {
        public static string AppName = "Project2";

        public static string AndroidClientId = "570271425109-6jail7euh9sh2h2i2kba73b29msfsvlv.apps.googleusercontent.com";
        public static string IosClientId = "570271425109-a1i2usgu6uspn74c0hkfvu5k4ni8kkav.apps.googleusercontent.com";

        public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
        public static string AuthorizeUrl = "https://www.accounts.google.com/o/oauth2/auth";
        public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

        public static string AndroidRedirectUrl = "com.googleusercontent.apps.570271425109-6jail7euh9sh2h2i2kba73b29msfsvlv:/oauth2redirect";
        public static string IosRedirectUrl = "com.gooogleusercontent.apps.570271425109-a1i2usgu6uspn74c0hkfvu5k4ni8kkav:/oauth2redirect";
    }
}
