namespace MyBackup
{
    public class Schedule
    {
        private string ext;

        private string time;

        private string interval;

        public Schedule(string ext, string time, string interval)
        {
            this.ext = ext;
            this.time = time;
            this.interval = interval;
        }

        public string Ext
        {
            get { return this.ext; }
        }

        public string Time
        {
            get { return this.time; }
        }

        public string Interval
        {
            get { return this.interval; }
        }
    }
}