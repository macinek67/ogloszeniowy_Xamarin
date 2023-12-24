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
    public partial class AccountTabbedPage : TabbedPage
    {
        User user;
        public AccountTabbedPage (User user)
        {
            InitializeComponent();
            this.user = user;

            this.Children.Add(new AccountProfilePage(user));
            this.Children[0].Title = "Profil";

            this.Children.Add(new AccountAppliedPage(user));
            this.Children[1].Title = "Zaaplikowane";

            this.Children.Add(new AccountSavedPage(user));
            this.Children[2].Title = "Zapisane";
        }
    }
}