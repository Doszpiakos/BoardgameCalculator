using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using TicketToRide.Model;
using TicketToRide.View;
using Xamarin.Forms;

namespace TicketToRide.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Player> dataList = new ObservableCollection<Player>();
        ObservableCollection<Player> sortedList = new ObservableCollection<Player>();
        public Command AddPlayerCommand { get; }
        public Command BonusPointsCommand { get; }
        public Command RoutePointsCommand { get; }
        public Command TicketPointsCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Player> DataList
        {
            get => dataList;
            set
            {
                if (dataList == value)
                    return;

                dataList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataList)));
            }
        }
        public ObservableCollection<Player> SortedList
        {
            get => sortedList;
            set
            {
                if (sortedList == value)
                    return;

                sortedList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SortedList)));
            }
        }

        void Init()
        {
            DataList.Add(new Player() { Name = "Player1", BonusPoints = 0, RoutePoints = 0, StationPoints = 0, Active = true, Color = "LightGray", SuccessfulTicketList = new ObservableCollection<int>(), FailedTicketList = new ObservableCollection<int>()});
            DataList.Add(new Player() { Name = "Player2", BonusPoints = 0, RoutePoints = 0, StationPoints = 0, Active = true, Color = "Tomato", SuccessfulTicketList = new ObservableCollection<int>(), FailedTicketList = new ObservableCollection<int>() });
            DataList.Add(new Player() { Name = "Player3", BonusPoints = 0, RoutePoints = 0, StationPoints = 0, Active = false, Color = "DeepPink", SuccessfulTicketList = new ObservableCollection<int>(), FailedTicketList = new ObservableCollection<int>() });
            DataList.Add(new Player() { Name = "Player4", BonusPoints = 0, RoutePoints = 0, StationPoints = 0, Active = false, Color = "Sienna", SuccessfulTicketList = new ObservableCollection<int>(), FailedTicketList = new ObservableCollection<int>() });
            DataList.Add(new Player() { Name = "Player5", BonusPoints = 0, RoutePoints = 0, StationPoints = 0, Active = false, Color = "DeepSkyBlue", SuccessfulTicketList = new ObservableCollection<int>(), FailedTicketList = new ObservableCollection<int>() });

            SortedList.Add(new Player());
            SortedList.Add(new Player());
            SortedList.Add(new Player());
            SortedList.Add(new Player());
            SortedList.Add(new Player());
        }

        public MainPageViewModel()
        {
            Init();
            AddPlayerCommand = new Command(async () =>
            {
                var playerViewModel = new PlayerPageViewModel
                {
                    DataList = this.DataList
                };
                await Application.Current.MainPage.Navigation.PushAsync(new PlayerPage(playerViewModel));
            });
            BonusPointsCommand = new Command(async () =>
            {
                if (SortedList[0] != null && SortedList[0].Active)
                {
                    var bonusPageViewModel = new BonusPageViewModel
                    {
                        DataList = this.DataList
                    };
                    bonusPageViewModel.PlayerSelector();
                    await Application.Current.MainPage.Navigation.PushAsync(new BonusPage(bonusPageViewModel));
                }
            });
            RoutePointsCommand = new Command(async () =>
            {
                if (SortedList[0] != null && SortedList[0].Active)
                {
                    var routePageViewModel = new RoutePageViewModel
                    {
                        DataList = this.DataList
                    };
                    routePageViewModel.PlayerSelector();
                    await Application.Current.MainPage.Navigation.PushAsync(new RoutePage(routePageViewModel));
                }
            });

            TicketPointsCommand = new Command(async () =>
            {
                if (SortedList[0] != null && SortedList[0].Active)
                {
                    var ticketPageViewModel = new TicketPageViewModel
                    {
                        DataList = this.DataList
                    };
                    await Application.Current.MainPage.Navigation.PushAsync(new TicketPage(ticketPageViewModel));
                    ticketPageViewModel.PlayerSelector();
                }
            });
        }
    }
}