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
    public partial class adminPanelPage : ContentPage
    {
        User user;
        public adminPanelPage(User user)
        {
            InitializeComponent();
            this.user = user;
            UploadAnnoucementData();
        }

        public async void UploadAnnoucementData()
        {
            company_Picker.ItemsSource = await App.Database.GetCompany();
            category_Picker.ItemsSource = await App.Database.GetCategory();
        }

        private async void categoryAdd_Button_Clicked(object sender, EventArgs e)
        {
            Announcement_category category = new Announcement_category()
            {
                Name = categoryName_Entry.Text
            };

            categoryName_Entry.Text = "";
            await App.Database.InsertCategory(category);
            UploadAnnoucementData();
        }

        private async void roleAdd_Button_Clicked(object sender, EventArgs e)
        {
            User_role userRole = new User_role()
            {
                Name = roleName_Entry.Text
            };

            roleName_Entry.Text = "";
            await App.Database.InsertRole(userRole);
        }

        private async void announcementAdd_Button_Clicked(object sender, EventArgs e)
        {
            Announcement announcement = new Announcement()
            {
                Company_id = ((Company)company_Picker.SelectedItem).Company_id,
                Category_id = ((Announcement_category)category_Picker.SelectedItem).AnnouncementCategory_id,
                Position_name = occupationName_Entry.Text,
                Position_level = (string)positionLevel_Picker.SelectedItem,
                Contract_type = (string)contractType_Picker.SelectedItem,
                Working_time = (string)workingTime_Picker.SelectedItem,
                Work_type = (string)workType_Picker.SelectedItem,
                End_date = endDate_DatePicker.Date,
                Responsibilities = responsibilities_Editor.Text,
                Requirements = requirements_Editor.Text,
                Benefits = benefits_Editor.Text
            };

            await App.Database.InsertAnnouncement(announcement);
        }

        private async void companyAdd_Button_Clicked(object sender, EventArgs e)
        {
            Company company = new Company()
            {
                Name = companyName_Entry.Text
            };

            companyName_Entry.Text = "";
            await App.Database.InsertCompany(company);
            UploadAnnoucementData();
        }
    }
}