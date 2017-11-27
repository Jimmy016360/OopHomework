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
    public class DBLogHandler : AbstractDBHandler
    {
        private static string dbPath = @".\log.sqlite";
        private static string cnStr = "data source=" + dbPath;

        protected override void InitSQLiteDb()
        {
            if (File.Exists(dbPath)) return;
            using (var cn = new SQLiteConnection(cnStr))
            {
                cn.Execute(@"
                    CREATE TABLE Log (
                        Id INTEGER,
                        MetaData VARCHAR(500),
                        CreateTime DATETIME,
                        CONSTRAINT Player_PK PRIMARY KEY (Id)
                    )");
            }
        }

        protected override void InsertDate(Candidate candidate, byte[] target)
        {
            using (var cn = new SQLiteConnection(cnStr))
            {
                var inserData = new
                {
                    Id = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    MetaData = candidate.Name,
                    CreateTime = DateTime.Now
                };
                
                var insertScript =
                    "INSERT INTO Log VALUES (@Id, @MetaData, @CreateTime)";
                cn.Execute(insertScript, inserData);
            }
        }
    }
}
