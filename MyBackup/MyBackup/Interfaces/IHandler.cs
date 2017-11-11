using System;
namespace MyBackup
{
    public interface IHandler
    {
        byte[] Perform(Candidate candidate, byte[] target);
    }
}
