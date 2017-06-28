using System.Threading.Tasks;
using System.Timers;

namespace HZBitmap
{
    class Genesis
    {
        private static int width = 300;
        private static int height = 300;
        private static int numHuman = 10000;
        private static int numZombie = 3000;
        private static int timeInterval = 400;
        private static World hzWorld;
        public Genesis()
        { }

        public static void _Genesis()
        {
            hzWorld = new World(width, height);
            hzWorld.PlaceCreature(numHuman, numZombie);

            //hzWorld.PrintWorld();
            //bool ans = (Console.ReadLine()) == "y";

            Task newtask = new Task(TimeWorld);
            newtask.Start();


            //Console.ReadLine();
        }

        public static void TimeWorld()
        {
            var myTimer = new Timer(timeInterval);
            myTimer.Elapsed += _TimedWorld;
            myTimer.AutoReset = true;
            myTimer.Enabled = true;
        }
        private static void _TimedWorld(object source, ElapsedEventArgs e)
        {
            hzWorld.Move();

        }
        public static char[,] GetWorld
        {
            get { return hzWorld.getWorld; }
        }
        public static int getWidth
        {
            get { return width; }
        }
        public static int getHeight
        {
            get { return height; }
        }
        public static int getTimeInterval
        {
            get { return timeInterval; }
        }
    }

}

