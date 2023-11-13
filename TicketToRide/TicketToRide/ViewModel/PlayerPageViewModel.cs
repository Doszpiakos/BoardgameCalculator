using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TicketToRide.Model;
using Xamarin.Forms;

namespace TicketToRide.ViewModel
{
    public class PlayerPageViewModel : INotifyPropertyChanged
    {
        public bool Check1 { get => DataList[0].Active; set { DataList[0].Active = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Check1))); } }
        public bool Check2 { get => DataList[1].Active; set { DataList[1].Active = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Check2))); } }
        public bool Check3 { get => DataList[2].Active; set { DataList[2].Active = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Check3))); } }
        public bool Check4 { get => DataList[3].Active; set { DataList[3].Active = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Check4))); } }
        public bool Check5 { get => DataList[4].Active; set { DataList[4].Active = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Check5))); } }
        public string Entry1 { get => DataList[0].Name; set { DataList[0].Name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entry1))); } }
        public string Entry2 { get => DataList[1].Name; set { DataList[1].Name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entry2))); } }
        public string Entry3 { get => DataList[2].Name; set { DataList[2].Name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entry3))); } }
        public string Entry4 { get => DataList[3].Name; set { DataList[3].Name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entry4))); } }
        public string Entry5 { get => DataList[4].Name; set { DataList[4].Name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entry5))); } }
        public Command BackButtonCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Player> dataList;
        public ObservableCollection<Player> DataList
        {
            get => dataList;
            set
            {
                dataList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataList)));
            }
        }

        public PlayerPageViewModel()
        {
            BackButtonCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopAsync());
        }
                
    }
}
