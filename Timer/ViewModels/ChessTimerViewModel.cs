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

        (int, int, int) fullTime1;
        (int, int, int) fullTime2;

        string player1 = "Player1";
        string player2 = "Player2";
        string initMinutes1 = "01:45:00";
        string initMinutes2 = "01:00:00";

        double seconds1;
        double seconds2;
        double minutes1;
        double minutes2;
        double hours1;
        double hours2;

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
        public string InitMinutes1
        {
            get => initMinutes1;
            set
            {
                initMinutes1 = value;
                OnPropertyChanged();
            }
        }
        public string InitMinutes2
        {
            get => initMinutes2;
            set
            {
                initMinutes2 = value;
                OnPropertyChanged();
            }
        }

        public double Seconds1
        {
            get => seconds1;
            set
            {
                seconds1 = value;
                OnPropertyChanged();
            }
        }
        public double Seconds2
        {
            get => seconds2;
            set
            {
                seconds2 = value;
                OnPropertyChanged();
            }
        }

        public double Minutes1
        {
            get => minutes1;
            set
            {
                minutes1 = value;
                OnPropertyChanged();
            }
        }
        public double Minutes2
        {
            get => minutes2;
            set
            {
                minutes2 = value;
                OnPropertyChanged();
            }
        }

        public double Hours1
        {
            get => hours1;
            set
            {
                hours1 = value;
                OnPropertyChanged();
            }
        }
        public double Hours2
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



        public void timer_tick_1(double hours, double minutes, double seconds, double fullsecnds)
        {
            Hours1 = hours - (fullTime1.Item1 + (double) fullTime1.Item2 / 60);
            Minutes1 = minutes - fullTime1.Item2;
            Seconds1 = seconds - fullTime1.Item3;
            var data = AngleCalculator.GetAngles(Hours1, Minutes1, Seconds1);
            HoursAngle1 = data.Item1 - 90;
            MinutesAngle1 = data.Item2 - 90;
            SecondsAngle1 = data.Item3 - 90;
        }

        public void timer_tick_2(double hours, double minutes, double seconds, double fullseconds)
        {
            Hours2 = hours - (fullTime2.Item1 + (double)fullTime2.Item2 / 60);
            Minutes2 = minutes - fullTime2.Item2;
            Seconds2 = seconds - fullTime2.Item3;
            var data = AngleCalculator.GetAngles(Hours2, Minutes2, Seconds2);
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
            fullTime1 = parseStringTime(InitMinutes1);
            fullTime2 = parseStringTime(InitMinutes2);
            Timer = new ChessTimer(
                ConvertFullTimeToSeconds(fullTime1), 
                ConvertFullTimeToSeconds(fullTime2), 
                Player1, Player2);
            Timer.Timer1.TimerTick += timer_tick_1;
            Timer.Timer2.TimerTick += timer_tick_2;
            Timer.OnWin += onWin;

            Hours1 = - (fullTime1.Item1 + (double)fullTime1.Item2 / 60);
            Minutes1 = - fullTime1.Item2;
            Seconds1 = - fullTime1.Item3;
            var data = AngleCalculator.GetAngles(Hours1, Minutes1, Seconds1);
            HoursAngle1 = data.Item1 - 90;
            MinutesAngle1 = data.Item2 - 90;
            SecondsAngle1 = data.Item3 - 90;

            Hours2 = - (fullTime2.Item1 + (double)fullTime2.Item2 / 60);
            Minutes2 = - fullTime2.Item2;
            Seconds2 = - fullTime2.Item3;
            data = AngleCalculator.GetAngles(Hours2, Minutes2, Seconds2);
            HoursAngle2 = data.Item1 - 90;
            MinutesAngle2 = data.Item2 - 90;
            SecondsAngle2 = data.Item3 - 90;
        }

        double ConvertFullTimeToSeconds((int, int, int) value) =>
            value.Item1 * 3600 + value.Item2 * 60 + value.Item3;

        (int, int, int) parseStringTime(string str)
        {
            var time = str.Split(' ', ':');
            if (time.Length == 3)
                return (Int32.Parse(time[0]), Int32.Parse(time[1]), Int32.Parse(time[2]));
            else if (time.Length == 2)
                return (Int32.Parse(time[0]), Int32.Parse(time[1]), 0);
            else if (time.Length == 1)
                return (Int32.Parse(time[0]), 1, 0);
            return (1, 0, 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
