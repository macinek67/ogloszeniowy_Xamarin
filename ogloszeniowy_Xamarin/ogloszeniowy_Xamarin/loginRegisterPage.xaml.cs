using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;
using system_ogloszeniowy.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ogloszeniowy_Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class loginRegisterPage : ContentPage
	{
		public loginRegisterPage ()
		{
			InitializeComponent ();
		}

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if (login_Entry.Text.Length < 4 || password_Entry.Text.Length < 4)
            {
                DisplayAlert("Informacja", "Wprowadzone dane maja zbyt malo znakow aby zostaly zaakceptowane", "OK");
                return;
            }

            User newUser = new User()
            {
                Role_id = 2,
                Login = login_Entry.Text,
                Password = password_Entry.Text
            };

            await App.Database.InsertUser(newUser);
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            var users = await App.Database.GetUsers(login_Entry.Text, password_Entry.Text);
            if (login_Entry.Text.Length < 4 || password_Entry.Text.Length < 4 || users.Count() == 0)
            {
                DisplayAlert("Informacja", "Wprowadzone dane sa nieprawidlowe", "OK");
                return;
            }

            var user = users[0];

            Navigation.PushAsync(new TabbedPage1(user));
        }
    }
}