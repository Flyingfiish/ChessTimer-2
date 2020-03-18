using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Timer.Models;

namespace Timer.ViewModels
{
    public class ChessTimerViewModel : INotifyPropertyChanged
    {
        ChessTimer Timer;
        string player1 = "Player1";
        string player2 = "Player2";
        int initMinutes = 60;

        int seconds1;
        int seconds2;
        int minutes1;
        int minutes2;
        int hours1;
        int hours2;

        double secondsAngle1 = -90;
        double secondsAngle2 = -90;
        double minutesAngle1 = -90;
        double minutesAngle2 = -90;
        double hoursAngle1 = -90;
        double hoursAngle2 = -90;

        string winMessage = "Кто же выиграет???";

        public string Player1
        {
            get { return player1; }
            set
            {
                player1 = value;
                OnPropertyChanged();
            }
        }
        public string Player2
        {
            get { return player2; }
            set
            {
                player2 = value;
                OnPropertyChanged();
            }
        }
        public int InitMinutes
        {
            get => initMinutes;
            set
            {
                initMinutes = value;
                OnPropertyChanged();
            }
        }

        public int Seconds1
        {
            get => seconds1;
            set
            {
                seconds1 = value;
                OnPropertyChanged();
            }
        }
        public int Seconds2
        {
            get => seconds2;
            set
            {
                seconds2 = value;
                OnPropertyChanged();
            }
        }

        public int Minutes1
        {
            get => minutes1;
            set
            {
                minutes1 = value;
                OnPropertyChanged();
            }
        }
        public int Minutes2
        {
            get => minutes2;
            set
            {
                minutes2 = value;
                OnPropertyChanged();
            }
        }

        public int Hours1
        {
            get => hours1;
            set
            {
                hours1 = value;
                OnPropertyChanged();
            }
        }
        public int Hours2
        {
            get => hours2;
            set
            {
                hours2 = value;
                OnPropertyChanged();
            }
        }

        public double SecondsAngle1
        {
            get => secondsAngle1;
            set
            {
                secondsAngle1 = value;
                OnPropertyChanged();
            }
        }
        public double SecondsAngle2
        {
            get => secondsAngle2;
            set
            {
                secondsAngle2 = value;
                OnPropertyChanged();
            }
        }

        public double MinutesAngle1
        {
            get => minutesAngle1;
            set
            {
                minutesAngle1 = value;
                OnPropertyChanged();
            }
        }
        public double MinutesAngle2
        {
            get => minutesAngle2;
            set
            {
                minutesAngle2 = value;
                OnPropertyChanged();
            }
        }

        public double HoursAngle1
        {
            get => hoursAngle1;
            set
            {
                hoursAngle1 = value;
                OnPropertyChanged();
            }
        }
        public double HoursAngle2
        {
            get => hoursAngle2;
            set
            {
                hoursAngle2 = value;
                OnPropertyChanged();
            }
        }

        public string WinMessage
        {
            get => winMessage;
            set
            {
                winMessage = value;
                OnPropertyChanged();
            }
        }

        void onWin(string name)
        {
            WinMessage = "Победил - " + name;
            Timer.Stop();
        }

        public ChessTimerViewModel()
        {
            //Timer = new ChessTimer(3600, "lol1", "lol2"); ///    ONLY      TESTING
            //Timer.Timer1.TimerTick += timer_tick_1;
            //Timer.Timer2.TimerTick += timer_tick_2;
        }

        

        public void timer_tick_1(int hours, int minutes, int seconds, int fullsecnds)
        {
            Hours1 = hours - Timer.TimeValueFormatted1.Value.Item1;
            Minutes1 = minutes - Timer.TimeValueFormatted1.Value.Item2;
            Seconds1 = seconds - Timer.TimeValueFormatted1.Value.Item3;
            var data = AngleCalculator.GetAngles(Hours1, Minutes1, Seconds1);
            HoursAngle1 = data.Item1 - 90;
            MinutesAngle1 = data.Item2 - 90;
            SecondsAngle1 = data.Item3 - 90;
        }

        public void timer_tick_2(int hours, int minutes, int seconds, int fullseconds)
        {
            Hours2 = hours;
            Minutes2 = minutes;
            Seconds2 = seconds;
            var data = AngleCalculator.GetAngles(hours, minutes, seconds);
            HoursAngle2 = data.Item1 - 90;
            MinutesAngle2 = data.Item2 - 90;
            SecondsAngle2 = data.Item3 - 90;
        }

        public ICommand Start
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (Timer == null)
                        InitTimer();
                    Timer.Start();
                });
            }
        }

        public ICommand Switch
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    Timer?.Switch();
                });
            }
        }

        public void InitTimer()
        {
            Timer = new ChessTimer(InitMinutes * 60, Player1, Player2);
            Timer.Timer1.TimerTick += timer_tick_1;
            Timer.Timer2.TimerTick += timer_tick_2;
            Timer.OnWin += onWin;

        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
