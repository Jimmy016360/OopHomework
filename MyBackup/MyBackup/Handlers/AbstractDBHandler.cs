using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBackupCandidate;
using System.IO;
using System.Data.SQLite;
using Dapper;

namespace MyBackup
{
    public abstract class AbstractDBHandler : IDBHandler
    {



        public byte[] Perform(Candidate candidate, byte[] target)
        {
            InitSQLiteDb();
            InsertDate(candidate, target);

            return target;
        }

        protected abstract void InitSQLiteDb();

        protected abstract void InsertDate(Candidate candidate, byte[] target);
    }
}
