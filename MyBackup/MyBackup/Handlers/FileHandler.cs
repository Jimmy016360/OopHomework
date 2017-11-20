using System;
using System.IO;
using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// File handler.
    /// </summary>
    public class FileHandler : AbstractHandler
    {
        /// <summary>
        /// Perform the specified candidate and target.
        /// </summary>
        /// <returns>The perform.</returns>
        /// <param name="candidate">Candidate.</param>
        /// <param name="target">Target.</param>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = target;
            base.Perform(candidate, target);
            if (target == null)
            {
                result = this.ConvertFileToByteArray(candidate);
            }
            else
            {
                this.ConvertByteArrayToFile(candidate, target);
            }
            return result;
        }

        /// <summary>
        /// Converts the byte array to file.
        /// </summary>
        /// <param name="candidate">Candidate.</param>
        /// <param name="target">Target.</param>
        private void ConvertByteArrayToFile(Candidate candidate, byte[] target)
        {
            try
            {
                using (var fs = new FileStream(candidate.Name, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(target, 0, target.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
            }
        }

        /// <summary>
        /// Converts the file to byte array.
        /// </summary>
        /// <returns>The file to byte array.</returns>
        /// <param name="candidate">Candidate.</param>
        private byte[] ConvertFileToByteArray(Candidate candidate)
        {
            if (File.Exists(candidate.ProcessName) == false) {
                throw new FileNotFoundException();
            }

            return File.ReadAllBytes(candidate.ProcessName);

        }
    }
}
