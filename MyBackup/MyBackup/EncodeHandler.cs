using System;
namespace MyBackup
{
    /// <summary>
    /// Encode handler.
    /// </summary>
    public class EncodeHandler : AbstractHandler
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
                result = this.EncodeData(candidate, target);
            }
            return result;
        }

        /// <summary>
        /// Encodes the data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="candidate">Candidate.</param>
        /// <param name="target">Target.</param>
        private byte[] EncodeData(Candidate candidate, byte[] target)
        {
            throw new NotImplementedException();
        }
    }
}
