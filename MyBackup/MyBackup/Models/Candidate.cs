using System;
using MyBackup;

namespace MyBackupCandidate
{
    /// <summary>
    /// Candidate.
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// The config.
        /// </summary>
        private readonly Config config;

        /// <summary>
        /// The file data time.
        /// </summary>
        private readonly DateTime fileDataTime;

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The name of the process.
        /// </summary>
        private readonly string processName;

        /// <summary>
        /// The size.
        /// </summary>
        private readonly long size;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">Config.</param>
        internal Candidate(
            Config config, 
            string name, 
            DateTime fileDataTime,
            long size,
            string processName)
        {
            this.config = config;
            this.name = name;
            this.processName = processName;
            this.size = size;
            this.fileDataTime = fileDataTime;
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
        public DateTime FileDateTime
        {
            get => this.fileDataTime;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get => this.name;
        }

        /// <summary>
        /// Gets or sets the name of the process.
        /// </summary>
        /// <value>The name of the process.</value>
        public string ProcessName
        {
            get => this.processName;
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public long Size
        {
            get => this.size;
        }
    }
}
