using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TicketToRide.Model;
using Xamarin.Forms;

namespace TicketToRide.ViewModel
{
    public class TicketPageViewModel : INotifyPropertyChanged
    {
        string name;
        string color;
        int playerId = 0;
        int ticketPoints = 0;
        public ListView failedListView;
        public ListView successfulListView;
        public Entry Entry;
        ObservableCollection<int> failedTicketList;
        ObservableCollection<int> successfulTicketList;
        public ObservableCollection<int> FailedTicketList { get => failedTicketList; set { failedTicketList = value; var args = new PropertyChangedEventArgs(nameof(FailedTicketList)); } }
        public ObservableCollection<int> SuccessfulTicketList { get => successfulTicketList; set { successfulTicketList = value; var args = new PropertyChangedEventArgs(nameof(SuccessfulTicketList)); } }
        public string Name { get => DataList[playerId].Name; set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name))); } }
        public string Color { get => DataList[playerId].Color; set { color = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color))); } }
        public int TicketPoints { get => DataList[playerId].TicketPoints; set { ticketPoints = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TicketPoints))); } }
        string entryText;
        public string EntryText { get => entryText; set { entryText = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EntryText))); } }

        ObservableCollection<Player> dataList = new ObservableCollection<Player>();
        public Command NextPlayerCommand { get; }
        public Command DeleteMinusListCommand { get; }
        public Command DeletePlusListCommand { get; }
        public Command AddMinusCommand { get; }
        public Command AddPlusCommand { get; }
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
        public event PropertyChangedEventHandler PropertyChanged;
        public TicketPageViewModel()
        {
            NextPlayerCommand = new Command(() =>
            {
                playerId++;
                PlayerSelector();
            });
            DeleteMinusListCommand = new Command(() =>
            {
                DataList[playerId].FailedTicketList.Clear();
                TicketPoints = DataList[playerId].TicketPoints;
            });
            DeletePlusListCommand = new Command(() =>
            {
                DataList[playerId].SuccessfulTicketList.Clear();
                TicketPoints = DataList[playerId].TicketPoints;
            });
            AddMinusCommand = new Command(() =>
            {
                if (EntryText != "")
                {
                    DataList[playerId].FailedTicketList.Add(Convert.ToInt32(EntryText));
                    TicketPoints = DataList[playerId].TicketPoints;
                    EntryText = "";
                    Entry.Focus();
                }
            });
            AddPlusCommand = new Command(() =>
            {
                if (EntryText != "")
                {
                    DataList[playerId].SuccessfulTicketList.Add(Convert.ToInt32(EntryText));
                    TicketPoints = DataList[playerId].TicketPoints;
                    EntryText = "";
                    Entry.Focus();
                }
            });
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
                TicketPoints = DataList[playerId].TicketPoints;
                failedTicketList = DataList[playerId].FailedTicketList;
                successfulTicketList = DataList[playerId].SuccessfulTicketList;

                failedListView.ItemsSource = DataList[playerId].FailedTicketList;
                successfulListView.ItemsSource = DataList[playerId].SuccessfulTicketList;
            }
            else
            {
                playerId = 0;
                PlayerSelector();
            }
        }
    }
}
