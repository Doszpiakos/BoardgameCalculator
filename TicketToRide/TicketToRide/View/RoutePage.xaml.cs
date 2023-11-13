﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketToRide.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketToRide.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoutePage : ContentPage
	{
		public RoutePage (RoutePageViewModel routePageViewModel)
		{
			BindingContext = routePageViewModel;
			InitializeComponent ();
		}
	}
}