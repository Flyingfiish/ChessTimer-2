using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Models
{
    public class ChessTimer
    {
        public string Player1;
        public string Player2;

        public SingleTimer Timer1;
        public SingleTimer Timer2;

        public delegate void OnWinHandeler(string name);
        public event OnWinHandeler OnWin;

        public ChessTimer(int timeValue, string name1 = "Player1", string name2 = "Player2")
        {
            Player1 = name1;
            Player2 = name2;
            Initialize(timeValue);
        }

        public void ElapsedTimer(string name)
        {
            if (name != Player1)
                OnWin(Player1);
            else
                OnWin(Player2);
        }

        public void Initialize(int timerValue)
        {
            Timer1 = new SingleTimer(timerValue, Player1);
            Timer2 = new SingleTimer(timerValue, Player2);
            Timer1.Elapsed += ElapsedTimer;
            Timer2.Elapsed += ElapsedTimer;
        }

        public void Start()
        {
            Timer1.Start();
        }

        public void Stop()
        {
            Timer1.Stop();
            Timer2.Stop();
        }

        public void Switch()
        {
            if (Timer1.IsEnabled() == true)
            {
                Timer1.Stop();
                Timer2.Start();
            }
            else
            {
                Timer2.Stop();
                Timer1.Start();
            }
        }
    }
}
