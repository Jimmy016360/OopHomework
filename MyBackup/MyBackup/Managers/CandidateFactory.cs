using System;
using MyBackup;

namespace MyBackupCandidate
{
    public static class CandidateFactory
    {
        public static Candidate Create(Config config,
            string name,
            DateTime fileDataTime,
            long size,
            string processName)
        {
            return new Candidate(config, name, fileDataTime, size, processName);
        }
    }
}
