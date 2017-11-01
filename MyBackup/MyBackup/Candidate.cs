using System;
namespace MyBackup
{
    /// <summary>
    /// Candidate.
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// The config.
        /// </summary>
        private Config config;

        /// <summary>
        /// The file data time.
        /// </summary>
        private string fileDataTime;

        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The name of the process.
        /// </summary>
        private string processName;

        /// <summary>
        /// The size.
        /// </summary>
        private string size;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Config.</param>
        public Candidate(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// Gets the config.
        /// </summary>
        /// <value>The config.</value>
        public Config Config 
        {
            get => this.config;
        }

        /// <summary>
        /// Gets or sets the file date time.
        /// </summary>
        /// <value>The file date time.</value>
        public string FileDateTime
        {
            get => this.fileDataTime;
            set => this.fileDataTime = value;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        /// <summary>
        /// Gets or sets the name of the process.
        /// </summary>
        /// <value>The name of the process.</value>
        public string ProcessName
        {
            get => this.processName;
            set => this.processName = value;
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public string Size
        {
            get => this.size;
            set => this.size = value;
        }
    }
}
