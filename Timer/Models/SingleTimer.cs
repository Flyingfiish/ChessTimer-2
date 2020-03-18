using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Timer.Models
{
    public class SingleTimer
    {

        //          TODO:
        // Convert TIME to DOUBLE!!!!!!!!!!!!!

        public string Name;

        public DispatcherTimer timer;
        public int TimeValue;

        public int Hours => seconds / 3600;
        public int Minutes => (seconds / 60) - Hours * 60;
        public int Seconds => seconds % 60;
        public (int, int, int)? TimeValueFormatted => (TimeValue / 3600, (TimeValue / 60) - TimeValue / 60, TimeValue % 60);

        private int seconds;

        public delegate void ElapsedHandeler(string name);
        public event ElapsedHandeler Elapsed;

        public delegate void TimerTickHandler(int hours, int minutes, int seconds, int fullseconds);
        public event TimerTickHandler TimerTick;

        public SingleTimer(int timeValue, string name)
        {
            Name = name;
            TimeValue = timeValue;
            seconds = 0;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(Tick);
        }

        public void Start() => timer.Start();
        public void Stop() => timer.Stop();
        public bool IsEnabled() => timer.IsEnabled;

        private void Tick(object sender, EventArgs e)
        {
            if (seconds >= TimeValue) Elapsed(Name);
            seconds += 1;
            TimerTick(Hours, Minutes, Seconds, seconds);
        }
    
    }
}
