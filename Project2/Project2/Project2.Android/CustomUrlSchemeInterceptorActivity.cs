using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project2.Droid
{
    [Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
[ IntentFilter (
    new[] {Intent.ActionView },
    Categories = new[] {Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataSchemes = new[] { "com.googleusercontent.apps.570271425109-6jail7euh9sh2h2i2kba73b29msfsvlv" },
    DataPath ="/oauth2redirect")]
    public class CustomUrlSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var url = new Uri(Intent.Data.ToString());
            AuthenState.Authenticator.OnPageLoading(url);

            Finish();
        }
    }
}