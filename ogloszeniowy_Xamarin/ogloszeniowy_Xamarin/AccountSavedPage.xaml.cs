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
	public partial class AccountSavedPage : ContentPage
	{
		User user;
		public AccountSavedPage (User user)
		{
			InitializeComponent ();
			this.user = user;
            UploadData();
        }

        public async void UploadData()
        {
            var user_saved = await App.Database.GetSaved(user.User_id);
            if (user_saved == null || user_saved.Count() == 0)
            {
                savedAnnouncements_ListView.ItemsSource = null;
                return;
            }

            List<List<string>> announcements = new List<List<string>>();

            foreach (var app in user_saved)
            {
                var announcement = (await App.Database.GetAnnouncementById(app.Announcement_id))[0];

                List<string> announcementData = new List<string>();

                announcementData.Add(announcement.Announcement_id.ToString());
                announcementData.Add(announcement.Position_name.ToString());

                var company = (await App.Database.GetCompanyById(announcement.Company_id))[0];

                announcementData.Add(company.Name);
                announcementData.Add(announcement.Adress);
                announcementData.Add(app.Saved_id.ToString());

                announcements.Add(announcementData);
            }

            savedAnnouncements_ListView.ItemsSource = announcements;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var tappedAnnouncement_id = ((List<string>)((Frame)sender).BindingContext)[0];
            DisplayAlert("Kliknieto!", "Wlasnie kliknales ogloszenie o id: " + tappedAnnouncement_id, "OK");
        }

        private async void deleteSavedButton_Clicked(object sender, EventArgs e)
        {
            var tappedSaved_id = int.Parse(((Button)sender).BindingContext.ToString());
            var saved = (await App.Database.GetSavedById(tappedSaved_id))[0];
            await App.Database.DeleteSaved(saved);

            UploadData();
        }
    }
}