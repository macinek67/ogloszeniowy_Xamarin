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
	public partial class AccountAppliedPage : ContentPage
	{
		User user;
		public AccountAppliedPage (User user)
		{
			InitializeComponent ();
			this.user = user;
			UploadData();
        }

		public async void UploadData()
		{
			var user_applied = await App.Database.GetApps(user.User_id);
			if (user_applied == null || user_applied.Count() == 0) return;

			List<List<string>> announcements = new List<List<string>>();

			foreach (var app in user_applied)
			{
                var announcement = (await App.Database.GetAnnouncementById(app.Announcement_id))[0];

                List<string> announcementData = new List<string>();

                announcementData.Add(announcement.Announcement_id.ToString());
                announcementData.Add(announcement.Position_name.ToString());

                var company = (await App.Database.GetCompanyById(announcement.Company_id))[0];

                announcementData.Add(company.Name);
                announcementData.Add(announcement.Adress);

                announcements.Add(announcementData);
            }

			appliedAnnouncements_ListView.ItemsSource = announcements;
		}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
			//User_application app = new User_application()
			//{
			//	Announcement_id = 1,
			//	User_id = 3
			//};
			//await App.Database.InsertApplication(app);
			var tappedAnnouncement_id = ((List<string>)((Frame)sender).BindingContext)[0];
            DisplayAlert("Kliknieto!", "Wlasnie kliknales ogloszenie o id: " + tappedAnnouncement_id, "OK");
        }
    }
}