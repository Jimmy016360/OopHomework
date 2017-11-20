using System;
using System.Collections.Generic;
using MyBackupCandidate;

namespace MyBackup
{
    public class AbstractTask : ITask
    {
        protected IFileFinder fileFinder;

        public virtual void Execute(Config config, Schedule schedule)  
        {
            this.fileFinder = FileFinderFactory.Create("file", config);
        }

        protected void BroadcastToHandlers(Candidate candidate)
        {
            List<IHandler> handlers = this.FindHandlers(candidate);
            byte[] target = null;
            foreach (IHandler handler in handlers)
            {
                target = handler.Perform(candidate, target);
            }
        }

        private List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handlers = new List<IHandler>
            {
                HandlerFactory.Create("file")
            };

            foreach (string handler in candidate.Config.Handlers)
            {
                handlers.Add(HandlerFactory.Create(handler));
            }

            handlers.Add(HandlerFactory.Create(candidate.Config.Destination));
            return handlers;
        }
    }
}
