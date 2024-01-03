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
    public partial class AnnouncementPage : ContentPage
    {
        User user;
        Announcement announcement;
        public AnnouncementPage(User user, Announcement announcement)
        {
            InitializeComponent();
            this.user = user;
            this.announcement = announcement;
            UploadData();
        }

        public async void UploadData()
        {
            positionName_Label.Text = announcement.Position_name;
            Company company = (await App.Database.GetCompanyById(announcement.Company_id))[0];
            company_Label.Text = company.Name;
            adress_Label.Text = "• Lokalizacja: " + announcement.Adress;
            positionLevel_Label.Text = "• Poziom stanowiska: " + announcement.Position_level;
            contractType_Label.Text = "• Typ umowy: " + announcement.Contract_type;
            workTime_Label.Text = "• Wymiar pracy: " + announcement.Working_time;
            workType_Label.Text = "• Tryb pracy: " + announcement.Work_type;
            string[] responsibilities = announcement.Requirements.Split(';');
            foreach (string responsibility in responsibilities)
            {
                Label label = new Label()
                {
                    Text = "•" + responsibility,
                    TextColor = Color.DarkViolet,
                    FontAttributes = FontAttributes.Bold,
                    Margin = new Thickness(0,0,0,5)
                };
                Responsibilities_StackLayout.Children.Add(label);
            }
            string[] requirements = announcement.Requirements.Split(';');
            foreach (string requirement in requirements)
            {
                Label label = new Label()
                {
                    Text = "•" + requirement,
                    TextColor = Color.Red,
                    FontAttributes = FontAttributes.Bold,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                Requirements_StackLayout.Children.Add(label);
            }
            string[] benefits = announcement.Requirements.Split(';');
            foreach (string benefit in benefits)
            {
                Label label = new Label()
                {
                    Text = "•" + benefit,
                    TextColor = Color.Green,
                    FontAttributes = FontAttributes.Bold,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                Benefits_StackLayout.Children.Add(label);
            }

            if (user.Role_id == 1)
            {
                apply_Button.IsEnabled = false;
                save_Button.IsEnabled = false;
            }
        }

        private async void apply_Button_Clicked(object sender, EventArgs e)
        {
            User_application user_Application = new User_application()
            {
                User_id = user.User_id,
                Announcement_id = announcement.Announcement_id,
            };
            await App.Database.InsertApplication(user_Application);
        }

        private async void save_Button_Clicked(object sender, EventArgs e)
        {
            User_saved user_Saved = new User_saved()
            {
                User_id = user.User_id,
                Announcement_id = announcement.Announcement_id
            };
            await App.Database.InsertSaved(user_Saved);
        }
    }
}