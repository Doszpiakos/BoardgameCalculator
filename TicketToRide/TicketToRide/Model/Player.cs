using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TicketToRide.Model
{
    public class Player : INotifyPropertyChanged
    {
        string name;
        int route;
        int station;
        int bonus = 10;
        bool active;
        string color;
        int ticketPoints;
        bool longest;
        ObservableCollection<int> failedTicketList;
        ObservableCollection<int> successfulTicketList;
        public ObservableCollection<int> FailedTicketList
        { 
            get => failedTicketList; 
            set 
            { 
                failedTicketList = value; 
                var args = new PropertyChangedEventArgs(nameof(FailedTicketList)); 
            } 
        }
        public ObservableCollection<int> SuccessfulTicketList 
        { 
            get => successfulTicketList; set 
            { 
                successfulTicketList = value;
                OnPropertyChanged(nameof(SuccessfulTicketList)); 
            } 
        }
        public string Color { get => color; set { color = value; OnPropertyChanged(nameof(Color)); } }
        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }
        public bool Active { get => active; set { active = value; OnPropertyChanged(nameof(Active)); } }
        public bool Longest { get => longest; set { longest = value; OnPropertyChanged(nameof(Longest)); } }
        public int TicketPoints 
        {
            get
            {
                int result = 0;
                if (successfulTicketList != null)
                {
                    for (int i = 0; i < successfulTicketList.Count; i++)
                    {
                        result += successfulTicketList[i];
                    }
                }
                if (failedTicketList != null)
                {
                    for (int i = 0; i < failedTicketList.Count; i++)
                    {
                        result -= failedTicketList[i];
                    }
                }
                return result;
            }
            set 
            { 
                ticketPoints = value; OnPropertyChanged(nameof(TicketPoints)); 
            } 
        }
        public int RoutePoints { get => route; set { route = value; OnPropertyChanged(nameof(RoutePoints)); } }
        public int StationPoints { get => station; set { station = value; OnPropertyChanged(nameof(StationPoints)); } }
        public int BonusPoints 
        {
            get
            {
                if (longest)
                    return 10;
                else
                    return 0;
            }
            set 
            { 
                bonus = value; OnPropertyChanged(nameof(BonusPoints)); 
            } 
        }

        int oneCar;
        public int OneCar { get => oneCar; set { oneCar = value; OnPropertyChanged(nameof(OneCar)); } }
        int twoCar;
        public int TwoCar { get => twoCar; set { twoCar = value; OnPropertyChanged(nameof(TwoCar)); } }
        int threecar;
        public int ThreeCar { get => threecar; set { threecar = value; OnPropertyChanged(nameof(ThreeCar)); } }
        int fourCar;
        public int FourCar { get => fourCar; set { fourCar = value; OnPropertyChanged(nameof(FourCar)); } }
        int sixCar;
        public int SixCar { get => sixCar; set { sixCar = value; OnPropertyChanged(nameof(SixCar)); } }
        int eightCar;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int EightCar { get => eightCar; set { eightCar = value; OnPropertyChanged(nameof(EightCar)); } }

        public int Sum
        {
            get 
            {
                return TicketPoints + RoutePoints + StationPoints + BonusPoints;
            }
        }

        int CalculateTicket()
        {
            int result = 0;
            if (successfulTicketList != null)
            {
                for (int i = 0; i < successfulTicketList.Count; i++)
                {
                    result += successfulTicketList[i];
                }
            }
            if (failedTicketList != null)
            {
                for (int i = 0; i < failedTicketList.Count; i++)
                {
                    result -= failedTicketList[i];
                }
            }
            return result;
        }

        public void Update()
        {
            failedTicketList.Add(0);
            failedTicketList.Remove(0);
            successfulTicketList.Add(0);
            successfulTicketList.Remove(0);
            TicketPoints = CalculateTicket();
        }
    }
}
