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
	public partial class searchOffersPage : ContentPage
	{
		User user;
		public searchOffersPage(User user)
		{
			InitializeComponent();
			this.user = user;
		}
	}
}