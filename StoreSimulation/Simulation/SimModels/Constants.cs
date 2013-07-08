using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSimulation.SimModels
{
    public enum ConfigsList
    {

        INITIAL_SERVICE_POINTS, TICKS_PER_ITEM, FRAME_TIME, ITEM_PROCESS_TIME, PAY_TIME, MAX_QUEUE_SIZE, MAX_SERVICE_POINTS, MIN_SERVICE_POINTS,
        MAX_CLIENTS_PER_CASH, SUPERVISOR_CHECK_INTERVAL, SERVICE_ARRIVAL_RATE_THRESHOLD_CLOSE, SERVICE_ARRIVAL_RATE_THRESHOLD_OPEN, SERVICE_MONITOR_INTERVAL,
        SERVICE_IDLE_TIME_CLOSE, CLIENT_CHANGE_QUEUE_INTERVAL
    }

    public static class Configs
    {
        public static int INITIAL_SERVICE_POINTS = 2;
        public static int TICKS_PER_ITEM = 120;
        public static int FRAME_TIME = 0; //in milliseconds
        public static int ITEM_PROCESS_TIME = 10;
        public static int PAY_TIME = 60;
        public static int MAX_QUEUE_SIZE = 10;           //  <======== this will ideally be an input from the setup fed to the system, this is just used for now for the strategy
        public static int MAX_SERVICE_POINTS = 7;
        public static int MIN_SERVICE_POINTS = 3;
        public static int MAX_CLIENTS_PER_CASH = 3;
        public static int SUPERVISOR_CHECK_INTERVAL = 1; // <======== to be configurable in the GUI?
        public static float SERVICE_ARRIVAL_RATE_THRESHOLD_CLOSE = 0.001f; //per 60 ticks
        public static float SERVICE_ARRIVAL_RATE_THRESHOLD_OPEN = 0.5f; // per 60 ticks
        public static int SERVICE_MONITOR_INTERVAL = 20;
        public static int SERVICE_IDLE_TIME_CLOSE = 120;
        public static int CLIENT_CHANGE_QUEUE_INTERVAL = 45;
        public static int MAX_SP_ITEMS = 1000;
        public static int MAX_ITEMS_PER_CLIENT = 1000;

    }
}
