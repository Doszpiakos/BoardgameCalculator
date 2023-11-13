using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketToRide.Model;
using TicketToRide.ViewModel;
using Xamarin.Forms;

namespace TicketToRide
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel viewmodel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new MainPageViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetSortedList();
            SortDataBySum();
            SortDataByActive();

            listView.ItemsSource = viewmodel.SortedList;
        }

        void GetSortedList()
        {
            
            for (int i = 0; i < 5; i++)
            {
                viewmodel.SortedList[i].Name = viewmodel.DataList[i].Name;
                viewmodel.SortedList[i].Color = viewmodel.DataList[i].Color;
                viewmodel.SortedList[i].Active = viewmodel.DataList[i].Active;
                viewmodel.SortedList[i].Longest = viewmodel.DataList[i].Longest;
                viewmodel.SortedList[i].BonusPoints = viewmodel.DataList[i].BonusPoints;
                viewmodel.SortedList[i].StationPoints = viewmodel.DataList[i].StationPoints;
                viewmodel.SortedList[i].RoutePoints = viewmodel.DataList[i].RoutePoints;
                viewmodel.SortedList[i].SuccessfulTicketList = viewmodel.DataList[i].SuccessfulTicketList;
                viewmodel.SortedList[i].FailedTicketList = viewmodel.DataList[i].FailedTicketList;
            }
            
        }

        void SortDataByActive()
        {
            int i = 0;
            int j = 0;
            while (i < 3)
            {
                j = i + 1;
                Player temp = viewmodel.SortedList[i];
                while (!temp.Active && j < 5)
                {
                    if (viewmodel.SortedList[j].Active)
                    {
                        temp = viewmodel.SortedList[j];
                        viewmodel.SortedList[j] = viewmodel.SortedList[i];
                        viewmodel.SortedList[i] = temp;
                    }
                    j++;
                }
                i++;
            }
        }

        void SortDataBySum()
        {
            int i = 0;
            int index;
            int j;
            while (i < 5)
            {
                Player highest = viewmodel.SortedList[i];
                index = i;
                j = i + 1;
                while (j < 5)
                {
                    if (highest.Sum < viewmodel.SortedList[j].Sum)
                    {
                        highest = viewmodel.SortedList[j];
                        index = j;
                    }
                    j++;
                }
                viewmodel.SortedList[index] = viewmodel.SortedList[i];
                viewmodel.SortedList[i] = highest;
                i++;
            }
        }
    }
}
