using System;
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
    public partial class TicketPage : ContentPage
    {
        public TicketPage(TicketPageViewModel ticketPageViewModel)
        {
            BindingContext = ticketPageViewModel;
            InitializeComponent();
            ticketPageViewModel.successfulListView = successfulListView;
            ticketPageViewModel.failedListView = failedListView;
            ticketPageViewModel.Entry = Entry;
        }
    }
}