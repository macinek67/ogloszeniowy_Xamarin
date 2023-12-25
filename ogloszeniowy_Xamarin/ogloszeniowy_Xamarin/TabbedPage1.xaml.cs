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
    public partial class TabbedPage1 : TabbedPage
    {
        User user;
        public TabbedPage1(User user)
        {
            InitializeComponent();
            this.user = user;

            this.Children.Add(new MainPage(user));
            this.Children[0].Title = "Strona glowna";
            this.Children[0].Icon = "mainPageIcon.png";

            this.Children.Add(new searchOffersPage(user));
            this.Children[1].Title = "Oferty";
            this.Children[1].Icon = "offerIcon.png";

            if (user.Role_id != 1)
            {
                this.Children.Add(new AccountTabbedPage(user));
                this.Children[2].Title = "Konto";
                this.Children[2].Icon = "accountIcon.png";
            }

            if (user.Role_id == 1)
            {
                this.Children.Add(new adminPanelPage(user));
                this.Children[2].Title = "Admin panel";
                this.Children[2].Icon = "adminPanelIcon.png";
            }
        }
    }
}