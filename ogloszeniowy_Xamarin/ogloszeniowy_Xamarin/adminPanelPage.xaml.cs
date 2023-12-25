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

        }

        private async void categoryAdd_Button_Clicked(object sender, EventArgs e)
        {
            Announcement_category category = new Announcement_category()
            {
                Name = categoryName_Entry.Text
            };

            categoryName_Entry.Text = "";
            await App.Database.InsertCategory(category);
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
            Company company = new Company()
            {
                Name = companyName_Entry.Text
            };

            companyName_Entry.Text = "";
            await App.Database.InsertCompany(company);
        }

        private void companyAdd_Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}