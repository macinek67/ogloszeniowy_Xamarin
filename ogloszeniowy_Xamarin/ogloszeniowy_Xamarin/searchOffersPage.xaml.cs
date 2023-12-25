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
	public partial class searchOffersPage : ContentPage
	{
		User user;
        int currentPage = 1;
        double maxPage = 1;
        int annPerPage = 5;
        List<Announcement> gloabalAllAnnoucements = new List<Announcement>();

        public searchOffersPage(User user)
		{
			InitializeComponent();
			this.user = user;
            UploadData();
            onInitalize();
            CalculatePageVariables();
		}

        public async void onInitalize()
        {
            gloabalAllAnnoucements = await App.Database.GetAnnouncements();
            category_Picker.ItemsSource = await App.Database.GetCategory();
        }

        public async void CalculatePageVariables()
        {
            double countAnnoucements = 0;
            if (occupationName_Entry.Text != null ||
                category_Picker.SelectedItem != null ||
                (string)positionLevel_Picker.SelectedItem != null ||
                (string)contractType_Picker.SelectedItem != null ||
                (string)workingTime_Picker.SelectedItem != null ||
                (string)workType_Picker.SelectedItem != null)
            {
                countAnnoucements = gloabalAllAnnoucements.Count();
            }
            else
            {
                gloabalAllAnnoucements = await App.Database.GetAnnouncements();
                countAnnoucements = gloabalAllAnnoucements.Count();
            }
            double howManyPages = countAnnoucements / annPerPage;
            maxPage = Math.Ceiling(howManyPages);
            if (maxPage == 0) maxPage = 1;
        }

        public async void UploadData()
        {
            searchedAnnouncements_ListView.ItemsSource = null;


            var allAnnoucements = await App.Database.GetAnnouncementWithPageFilter(currentPage, annPerPage);
            var annForGlobal = allAnnoucements;

            if (occupationName_Entry.Text != null || 
                category_Picker.SelectedItem != null ||
                (string)positionLevel_Picker.SelectedItem != null ||
                (string)contractType_Picker.SelectedItem != null ||
                (string)workingTime_Picker.SelectedItem != null ||
                (string)workType_Picker.SelectedItem != null)
            {
                //DisplayAlert("Blad wyszukiwania", "Aby wyszukowac konretne oferty, wszystkie pola musza byc uzupelnione", "OK");
                string positionName = occupationName_Entry.Text;
                int category = ((Announcement_category)category_Picker.SelectedItem).AnnouncementCategory_id;
                string positionLevel = (string)positionLevel_Picker.SelectedItem;
                string contractType = (string)contractType_Picker.SelectedItem;
                string workTime = (string)workingTime_Picker.SelectedItem;
                string workType = (string)workType_Picker.SelectedItem;


                var FiltredAnnoucements = await App.Database.GetAnnouncementByFiltres
                (
                    positionName,
                    category,
                    positionLevel,
                    contractType,
                    workTime,
                    workType
                );

                annForGlobal = FiltredAnnoucements;
                allAnnoucements.Clear();
                int offset = ((currentPage * annPerPage) - annPerPage);
                for (int i = offset; i < offset+annPerPage; i++)
                {
                    allAnnoucements.Add(FiltredAnnoucements.ElementAt(i));
                }
            }


            gloabalAllAnnoucements = annForGlobal;

            if (allAnnoucements == null || allAnnoucements.Count() == 0) return;


            List<List<string>> announcementsList = new List<List<string>>();
            foreach (var ann in allAnnoucements)
            {
                var announcement = (await App.Database.GetAnnouncementById(ann.Announcement_id))[0];
                List<string> announcementData = new List<string>();


                announcementData.Add(announcement.Announcement_id.ToString());
                announcementData.Add(announcement.Position_name.ToString());


                var company = (await App.Database.GetCompanyById(announcement.Company_id))[0];


                announcementData.Add(company.Name);
                announcementData.Add(announcement.Adress);

                announcementsList.Add(announcementData);
            }


            searchedAnnouncements_ListView.ItemsSource = announcementsList;
            CalculatePageVariables();
        }

        private void searchOffers_Button_Clicked(object sender, EventArgs e)
        {
            UploadData();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var tappedAnnouncement_id = ((List<string>)((Frame)sender).BindingContext)[0];
            DisplayAlert("Kliknieto!", "Wlasnie kliknales ogloszenie o id: " + tappedAnnouncement_id, "OK");
        }

        private void pageNext_Button_Clicked(object sender, EventArgs e)
        {
            if (currentPage == maxPage) return;
            currentPage++;
            UploadData();
            currentPage_Label.Text = currentPage.ToString();
        }

        private void pagePrevious_Button_Clicked(object sender, EventArgs e)
        {
            if (currentPage == 1) return;
            currentPage--;
            UploadData();
            currentPage_Label.Text = currentPage.ToString();
        }
    }
}