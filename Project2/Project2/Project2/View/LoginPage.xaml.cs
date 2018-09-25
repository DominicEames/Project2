using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Project2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project2.ViewModel;

namespace Project2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            Init();
		}

        void Init()
        {
            BackgroundColor = Constants.AppBackgrooundColour;
            Lbl_Username.TextColor = Constants.TextColour;
            Lbl_Password.TextColor = Constants.TextColour;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }
        void SignInProcedure (object sender, EventArgs e)

        {
            Login user = new Login(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("login", "Login Sucess", "OK");
                App.UserDatabase.SaveUser(user);

            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, Empty", "OK");
            }
        }
	}
}