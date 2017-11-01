using System;
namespace MyBackup
{
    public abstract class AbstractHandler : IHandler
    {

        public virtual byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}
