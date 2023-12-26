using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ogloszeniowy_Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountProfilePage : ContentPage
	{
		User user;
		User_data userData;
		public AccountProfilePage (User user)
		{
			InitializeComponent ();
			this.user = user;
			UploadData();
        }

		public async void UploadData()
		{
            var temp = (await App.Database.GetUser_data(user.User_id));
            if (temp == null || temp.Count() == 0)
            {
                User_data newUserData = new User_data()
                {
                    User_id = user.User_id
                };
                await App.Database.InsertUser_data(newUserData);
            }

            temp = (await App.Database.GetUser_data(user.User_id));
            userData = temp[0];

			if(userData.Name != null) name_Entry.Text = userData.Name;
			if(userData.Surname != null) surname_Entry.Text = userData.Surname;
			if(userData.Currnent_occupation != null) currentOccupation_entry.Text = userData.Currnent_occupation;
			if(userData.City != null) city_Entry.Text = userData.City;
			if(userData.Birth_date != null) birthDate_Entry.Date = userData.Birth_date;
			if(userData.Telephone_number != null) telephone_Entry.Text = userData.Telephone_number;
			if(userData.Summary != null) occupationSummary_Editor.Text = userData.Summary;
        }

        private async void personalDataSaveButton_Clicked(object sender, EventArgs e)
        {
            userData.Name = name_Entry.Text;
            userData.Surname = surname_Entry.Text;
            userData.Currnent_occupation = currentOccupation_entry.Text;
            userData.City = city_Entry.Text;

            await App.Database.UpdateUser_data(userData);
        }

        private async void contactDataSaveButton_Clicked(object sender, EventArgs e)
        {
            userData.Birth_date = birthDate_Entry.Date;
            userData.Telephone_number = telephone_Entry.Text;

            await App.Database.UpdateUser_data(userData);
        }

        private async void occupationSummarySaveButton_Clicked(object sender, EventArgs e)
        {
            userData.Summary = occupationSummary_Editor.Text;

            await App.Database.UpdateUser_data(userData);
        }
    }
}