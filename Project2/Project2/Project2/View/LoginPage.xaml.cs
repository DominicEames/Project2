using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Project2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project2.ViewModel;
using Xamarin.Auth;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Project2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        Account account;
        AccountStore store;
        public LoginPage ()
		{
			InitializeComponent ();
            Init();
            store = AccountStore.Create();
            account = store.FindAccountsForService(AppAuthenParameters.AppName).FirstOrDefault();
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
         async void SignInProcedure (object sender, EventArgs e)

        {
            Login user = new Login(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("login", "Login Sucess", "OK");
                if(Device.OS == TargetPlatform.Android)
                {
                    Application.Current.MainPage = new NavigationPage(new MenuPage());
                }
                else if(Device.OS == TargetPlatform.iOS)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new MenuPage()));
                }
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, Empty", "OK");
            }

        }
        void OnLoginClicked(object sender, EventArgs e)
        {
            string clientId = AppAuthenParameters.AndroidClientId;
            string redirectUri = AppAuthenParameters.AndroidRedirectUrl;

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                AppAuthenParameters.Scope,
                new Uri(AppAuthenParameters.AuthorizeUrl),
                new Uri(redirectUri),
                new Uri(AppAuthenParameters.AccessTokenUrl),
                null,
                true);
            AuthenState.Authenticator = authenticator;
            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }
        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            UserInfo user = null;
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request("GET", new Uri(AppAuthenParameters.UserInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<UserInfo>(userJson);
                }
                if (account != null)
                {
                    store.Delete(account, AppAuthenParameters.AppName);
                }
                await store.SaveAsync(account = e.Account, AppAuthenParameters.AppName);
                await DisplayAlert("Email address", user.Email, "OK");
            }
        }
        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authenticatin Error: " + e.Message);
        }
    }
}
