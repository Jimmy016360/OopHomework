using System.Collections.Generic;
using System.IO;

namespace MyBackup
{
    /// <summary>
    /// 本機檔案處理
    /// </summary>
    public class LocalFileFinder : AbstractFileFinder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LocalFileFinder()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">備份設定</param>
        public LocalFileFinder(Config config) : base(config)
        {
            string searchPattern = "*." + config.Ext;
            if (config.SubDirectory)
                this.files = this.GetSubDirectoryFiles(config.Location, searchPattern).ToArray();
            else
                this.files = Directory.GetFiles(config.Location, searchPattern);
        }

        /// <summary>
        /// 建立 Candidate 物件
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        /// <returns>Candidate 物件</returns>
        protected override Candidate CreateCandidate(string fileName)
        {
            Candidate candidate = new Candidate(this.config);
            candidate.Name = fileName;
            return candidate;
        }

        /// <summary>
        /// 取得子目錄下所有檔案
        /// </summary>
        /// <param name="directory">目錄</param>
        /// <param name="searchPattern">檔案搜尋模式</param>
        /// <returns>檔案名稱清單</returns>
        private List< string> GetSubDirectoryFiles(string directory, string searchPattern)
        {
            List<string> fileNames = new List<string>();
            
            if (Directory.Exists(directory) == false)
            {
                return fileNames;
            }

            fileNames.AddRange(Directory.GetFiles(directory, searchPattern));
            foreach (string dir in Directory.GetDirectories(directory))
            {
                fileNames.AddRange(GetSubDirectoryFiles(dir, searchPattern));
            }

            return fileNames;
        }
    }
}