using System;
using System.Collections.Generic;
using System.Text;

namespace Meta_repo
{
    class Repo
    {
        private readonly SQLite.SQLiteConnection db;
        public Repo(string dbFile)
        {
            db = new SQLite.SQLiteConnection(dbFile);
            db.CreateTable<FileMeta>();
        }

        public FileMeta GetFileMeta(int Id)
        {
           return db.Get<FileMeta>(Id);
        }

        public IEnumerable<int> AllIds()
        {
            return db.Query<int>("SELECT ID FROM FileMeta");
        } 

        public void PutFileMeta(FileMeta meta)
        {
            db.Insert(meta);
        }

        // TODO(merlin): add GetFileMetaByName
        // TODO(merlin): add DeleteFileMetaByID
    }
}
