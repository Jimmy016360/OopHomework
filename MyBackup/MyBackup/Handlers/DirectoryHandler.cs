﻿using System;
using System.IO;

namespace MyBackup
{
    /// <summary>
    /// Directory handler.
    /// </summary>
    public class DirectoryHandler : AbstractHandler
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
                result = this.CopyToDirectory(candidate, target);
            }
            return result;
        }

        /// <summary>
        /// Copies to directory.
        /// </summary>
        /// <returns>The to directory.</returns>
        /// <param name="candidate">Candidate.</param>
        /// <param name="target">Target.</param>
        private byte[] CopyToDirectory(Candidate candidate, byte[] target)
        {
            if (Directory.Exists( candidate.Config.Dir) == false ) {
                throw new DirectoryNotFoundException();
            }

            string targetPath = Path.Combine(candidate.Config.Dir, candidate.Name);
            using (var fs = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(target, 0, target.Length);
            }

            return target;
        }
    }
}