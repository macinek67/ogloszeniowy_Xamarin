using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;
using Xamarin.Forms;

namespace ogloszeniowy_Xamarin
{
    public partial class MainPage : ContentPage
    {
        User user;
        public MainPage(User user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}
