using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSimulation
{
    public static class Timer
    {
        private static long tick = 0;

        public static void increment()
        {
            Timer.tick++;
            //System.Diagnostics.Debug.WriteLine(Timer.tick);
            TimerTicked(null, new TimerEventArgs(Timer.tick));
        }

        public static long getTick()
        {
            return Timer.tick;
        }

        public static void Reset()
        {
            Timer.tick = 0;
        }

        //events definitions
        //event that fires when a client is added to a waiting queue
        public delegate void TimerTickedEventHandler(object sender, TimerEventArgs e);
        public static event TimerTickedEventHandler TimerTicked = delegate { };
    }

    public class TimerEventArgs : EventArgs{
        public long tick;

        public TimerEventArgs(long tick){
            this.tick = tick;
        }
    }
}
