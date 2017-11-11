using System;
using System.IO;
using System.IO.Compression;

namespace MyBackup
{
    /// <summary>
    /// Zip handler.
    /// </summary>
    public class ZipHandler : AbstractHandler
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
            if (target != null)
            {
                result = this.ZipData(candidate, target);
            }
            return result;
        }

        /// <summary>
        /// Zips the data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="candidate">Candidate.</param>
        /// <param name="target">Target.</param>
        private byte[] ZipData(Candidate candidate, byte[] target)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(target, 0, target.Length);
            }
            return output.ToArray();
        }
    }
}
