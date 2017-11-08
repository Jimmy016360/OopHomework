using System.IO;

namespace MyBackup
{
    public class LocalFileFinder : AbstractFileFinder
    {
        public LocalFileFinder()
        {
        }

        public LocalFileFinder(Config config) : base(config)
        {
            if (config.SubDirectory)
                this.files = this.GetSubDirectoryFiles(config);
            else
                this.files = Directory.GetFiles(config.Location, "*." + config.Ext);
        }

        protected override Candidate CreateCandidate(string fileName)
        {
            // TODO:
        }

        private string[] GetSubDirectoryFiles(Config config)
        {
            // TODO:
        }
    }
}