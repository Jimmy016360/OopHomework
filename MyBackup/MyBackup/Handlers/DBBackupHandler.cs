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
    public class DBBackupHandler : AbstractDBHandler
    {
        private static string dbPath = @".\backup.sqlite";
        private static string cnStr = "data source=" + dbPath;

        protected override void InitSQLiteDb()
        {
            if (File.Exists(dbPath)) return;
            using (var cn = new SQLiteConnection(cnStr))
            {
                cn.Execute(@"
                    CREATE TABLE Backup (
                        Id INTEGER,
                        Name VARCHAR(500),
                        ProcessName VARCHAR(500),
                        FileDateTime DATETIME,
                        Size INTEGER,
                        BinData BLOB,
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
                    Name = candidate.Name,
                    ProcessName = candidate.ProcessName,
                    FileDateTime = candidate.FileDateTime,
                    Size = candidate.Size,
                    BinData = target
                };
                
                var insertScript =
                    "INSERT INTO Backup VALUES (@Id, @Name, @ProcessName, @FileDateTime, @Size, @BinData)";
                cn.Execute(insertScript, inserData);
            }
        }
    }
}
