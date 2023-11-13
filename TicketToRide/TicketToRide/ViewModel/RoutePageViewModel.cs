using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TicketToRide.Model;
using Xamarin.Forms;

namespace TicketToRide.ViewModel
{
    public class RoutePageViewModel : INotifyPropertyChanged
    {
        string name;
        string color;
        int playerId = 0;
        int routePoints;
        int unUsedTrains = 45;
        int oneCar = 0;
        int twoCar = 0;
        int threeCar = 0;
        int fourCar = 0;
        int sixCar = 0;
        int eightCar = 0;
        public string Name { get => DataList[playerId].Name; set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name))); } }
        public string Color { get => DataList[playerId].Color; set { color = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color))); } }
        public int UsedTrains { get => oneCar + twoCar * 2 + threeCar * 3 + fourCar * 4 + sixCar * 6 + eightCar * 8; }
        public int UnUsedTrains { get => unUsedTrains - (oneCar + twoCar * 2 + threeCar * 3 + fourCar * 4 + sixCar * 6 + eightCar * 8); }
        public int RoutePoints { get => oneCar + twoCar * 2 + threeCar * 4 + fourCar * 7 + sixCar * 15 + eightCar * 21; set { routePoints = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoutePoints))); } }
        public int OneCar { get => oneCar; set { oneCar = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OneCar))); } }
        public int TwoCar { get => twoCar; set { twoCar = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TwoCar))); } }
        public int ThreeCar { get => threeCar; set { threeCar = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThreeCar))); } }
        public int FourCar { get => fourCar; set { fourCar = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FourCar))); } }
        public int SixCar { get => sixCar; set { sixCar = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SixCar))); } }
        public int EightCar { get => eightCar; set { eightCar = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EightCar))); } }

        public Command OneCarPlusCommand { get; }
        public Command TwoCarPlusCommand { get; }
        public Command ThreeCarPlusCommand { get; }
        public Command FourCarPlusCommand { get; }
        public Command SixCarPlusCommand { get; }
        public Command EightCarPlusCommand { get; }
        public Command OneCarMinusCommand { get; }
        public Command TwoCarMinusCommand { get; }
        public Command ThreeCarMinusCommand { get; }
        public Command FourCarMinusCommand { get; }
        public Command SixCarMinusCommand { get; }
        public Command EightCarMinusCommand { get; }
        public Command NextPlayerCommand { get; }
        ObservableCollection<Player> dataList = new ObservableCollection<Player>();
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

        void Update()
        {
            dataList[playerId].RoutePoints = oneCar + twoCar * 2 + threeCar * 4 + fourCar * 7 + sixCar * 15 + eightCar * 21;
            dataList[playerId].OneCar = oneCar;
            dataList[playerId].TwoCar = twoCar;
            dataList[playerId].ThreeCar = threeCar;
            dataList[playerId].FourCar = fourCar;
            dataList[playerId].SixCar = sixCar;
            dataList[playerId].EightCar = eightCar;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UsedTrains)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UnUsedTrains)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoutePoints)));
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
                RoutePoints = DataList[playerId].RoutePoints;
                OneCar = DataList[playerId].OneCar;
                TwoCar = DataList[playerId].TwoCar;
                ThreeCar = DataList[playerId].ThreeCar;
                FourCar = DataList[playerId].FourCar;
                SixCar = DataList[playerId].SixCar;
                EightCar = DataList[playerId].EightCar;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UsedTrains)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UnUsedTrains)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoutePoints)));
            }
            else
            {
                playerId = 0;
                PlayerSelector();
            }
        }

        public RoutePageViewModel()
        {
            NextPlayerCommand = new Command(() =>
            {
                playerId++;
                PlayerSelector();
            });

            // ONE - EGY - 1
            OneCarPlusCommand = new Command(() =>
            {
                oneCar++;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OneCar)));
                Update();
            });
            OneCarMinusCommand = new Command(() =>
            {
                if (oneCar != 0)
                {
                    oneCar--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OneCar)));
                    Update();
                }
            });

            // TWO - KÉT - 2
            TwoCarPlusCommand = new Command(() =>
            {
                twoCar++;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TwoCar)));
                Update();
            });
            TwoCarMinusCommand = new Command(() =>
            {
                if (twoCar != 0)
                {
                    twoCar--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TwoCar)));
                    Update();
                }
            });

            // THREE - HÁROM - 3
            ThreeCarPlusCommand = new Command(() =>
            {
                threeCar++;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThreeCar)));
                Update();
            });
            ThreeCarMinusCommand = new Command(() =>
            {
                if (threeCar != 0)
                {
                    threeCar--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThreeCar)));
                    Update();
                }
            });

            // FOUR - NÉGY - 4
            FourCarPlusCommand = new Command(() =>
            {
                fourCar++;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FourCar)));
                Update();
            });
            FourCarMinusCommand = new Command(() =>
            {
                if (fourCar != 0)
                {
                    fourCar--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FourCar)));
                    Update();
                }
            });

            // SIX - HAT - 6
            SixCarPlusCommand = new Command(() =>
            {
                sixCar++;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SixCar)));
                Update();
            });
            SixCarMinusCommand = new Command(() =>
            {
                if (sixCar != 0)
                {
                    sixCar--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SixCar)));
                    Update();
                }
            });

            // EIGHT - NYOLC - 8
            EightCarPlusCommand = new Command(() =>
            {
                eightCar++;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EightCar)));
                Update();
            });
            EightCarMinusCommand = new Command(() =>
            {
                if (eightCar != 0)
                {
                    eightCar--;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EightCar)));
                    Update();
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
