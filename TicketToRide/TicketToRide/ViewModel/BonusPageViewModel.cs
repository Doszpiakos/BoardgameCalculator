using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TicketToRide.Model;
using TicketToRide.View;
using Xamarin.Forms;

namespace TicketToRide.ViewModel
{
    public class BonusPageViewModel : INotifyPropertyChanged
    {
        string name;
        int station;
        int bonus;
        string color;
        public string Name { get => name; set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name))); } }
        public int StationPoints { get => station; set { station = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StationPoints))); } }
        public int BonusPoints 
        { 
            get => bonus; 
            set 
            { 
                bonus = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BonusPoints)));
            } 
        }
        public bool CheckBox 
        { 
            get => DataList[playerId].Longest; 
            set 
            { 
                DataList[playerId].Longest = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckBox)));
                if (CheckBox)
                {
                    BonusPoints = 10;
                }
                else
                {
                    BonusPoints = 0;
                }
                UpdateData(); 
            } 
        }
        public string Color { get => DataList[playerId].Color; set { color = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color))); } }
        public Command BackButtonCommand { get; }
        public Command NextPlayerCommand { get; }
        public Command AddStationCommand { get; }
        public Command RemoveStationCommand { get; }
        ObservableCollection<Player> dataList;
        int playerId = 0;
        public ObservableCollection<Player> DataList
        {
            get => dataList;
            set
            {
                dataList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataList)));
            }
        }
        public BonusPageViewModel()
        {
            playerId = 0;
            NextPlayerCommand = new Command(() =>
           {
               UpdateData();
               playerId++;
               PlayerSelector();
           });
            BackButtonCommand = new Command(async () =>
            {
                UpdateData();
                await Application.Current.MainPage.Navigation.PopAsync();
            });
            AddStationCommand = new Command(() =>
            {
                if (DataList[playerId].StationPoints != 12)
                {
                    StationPoints += 4;
                    DataList[playerId].StationPoints += 4;
                    UpdateData();
                }
            });
            RemoveStationCommand = new Command(() =>
            {
                if (DataList[playerId].StationPoints != 0)
                {
                    StationPoints -= 4;
                    DataList[playerId].StationPoints -= 4;
                    UpdateData();
                }
            });
        }

        public void UpdateData()
        {
            DataList[playerId].Name = Name;
            DataList[playerId].BonusPoints = BonusPoints;
            DataList[playerId].StationPoints = StationPoints;
            DataList[playerId].Longest = CheckBox;
        }

        public void PlayerSelector()
        {
            while (playerId < 5 && !DataList[playerId].Active)
            {
                playerId++;
            }
            if (playerId < 5)
            {
                Name = DataList[playerId].Name;
                Color = DataList[playerId].Color;
                BonusPoints = DataList[playerId].BonusPoints;
                StationPoints = DataList[playerId].StationPoints;
                CheckBox = DataList[playerId].Longest;
            }
            else
            {
                playerId = 0;
                PlayerSelector();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
