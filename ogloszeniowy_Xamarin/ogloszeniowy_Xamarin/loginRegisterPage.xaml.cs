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
            StartingContent();
        }

        public async void StartingContent()
        {
            var roles = await App.Database.GetRoles();
            if (roles == null || roles.Count() == 0)
            {
                User_role user_Role = new User_role()
                {
                    Name = "admin"
                };
                await App.Database.InsertRole(user_Role);
                user_Role = new User_role()
                {
                    Name = "user"
                };
                await App.Database.InsertRole(user_Role);
            }

            var users = await App.Database.GetUsers();
            if (users == null || users.Count() == 0)
            {
                User admin = new User()
                {
                    Role_id = 1,
                    Login = "admin@gmail.com",
                    Password = "sigma"
                };
                await App.Database.InsertUser(admin);
                User user = new User()
                {
                    Role_id = 2,
                    Login = "user@gmail.com",
                    Password = "sigma"
                };
                await App.Database.InsertUser(user);
            }
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
            //login_Entry.Text = "admin@gmail.com";
            //password_Entry.Text = "sigma";
            //login_Entry.Text = "user@gmail.com";
            //password_Entry.Text = "sigma";
            var users = await App.Database.GetUsers(login_Entry.Text, password_Entry.Text);
            if (users.Count() == 0)
            {
                DisplayAlert("Informacja", "Wprowadzone dane sa nieprawidlowe", "OK");
                return;
            }

            var user = users.ElementAt(0);

            Navigation.PushAsync(new TabbedPage1(user));
        }
    }
}