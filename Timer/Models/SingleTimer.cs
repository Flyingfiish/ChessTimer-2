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
        public double TimeValue;

        public double Hours => seconds / 3600;
        public double Minutes => (seconds / 60);
        public double Seconds => seconds % 60;
        public (double, double, double)? TimeValueFormatted => (TimeValue / 3600, (TimeValue / 60) - TimeValue / 60, TimeValue % 60);

        private double seconds;

        public delegate void ElapsedHandeler(string name);
        public event ElapsedHandeler Elapsed;

        public delegate void TimerTickHandler(double hours, double minutes, double seconds, double fullseconds);
        public event TimerTickHandler TimerTick;

        public SingleTimer(double timeValue, string name)
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
