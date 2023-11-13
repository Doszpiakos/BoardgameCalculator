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
    public partial class BonusPage : ContentPage
    {
        BonusPageViewModel bonusViewModel;
        public BonusPage(BonusPageViewModel bonusViewModel)
        {
            this.bonusViewModel = bonusViewModel;
            BindingContext = bonusViewModel;
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            bonusViewModel.UpdateData();
            base.OnDisappearing();
        }
    }
}