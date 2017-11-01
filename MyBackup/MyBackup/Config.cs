namespace MyBackup
{
    public class Config
    {
        private string ext;

        private string location;

        private bool subDirectory;

        private string unit;

        private bool remove;

        private string[] handlers;

        private string destination;

        private string dir;

        private string connectionString;

        public Config(string ext, string location, bool subDirectory, string unit, bool remove, string[] handlers, string destination, string dir, string connectionString)
        {
            this.ext = ext;
            this.location = location;
            this.subDirectory = subDirectory;
            this.unit = unit;
            this.remove = remove;
            this.handlers = handlers;
            this.destination = destination;
            this.dir = dir;
            this.connectionString = connectionString;
        }

        public string Ext
        {
            get { return this.ext; }
        }

        public string Location
        {
            get { return this.location; }
        }

        public bool SubDirectory
        {
            get { return this.subDirectory; }
        }

        public string Unit
        {
            get { return this.unit; }
        }

        public bool Remove
        {
            get { return this.remove; }
        }

        public string[] Handlers
        {
            get { return this.handlers; }
        }

        public string Destination
        {
            get { return this.destination; }
        }

        public string Dir
        {
            get { return this.dir; }
        }

        public string ConnectionString
        {
            get { return this.connectionString; }
        }
    }
}