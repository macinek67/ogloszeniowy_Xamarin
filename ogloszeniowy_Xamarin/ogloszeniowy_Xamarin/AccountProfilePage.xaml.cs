﻿using System;
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
		public AccountProfilePage (User user)
		{
			InitializeComponent ();
			this.user = user;
		}
	}
}