using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Meta_repo
{
    class FileMeta
    {
            [PrimaryKey, AutoIncrement]
            public int Id { get; }
            [Indexed]
            public string Name { get; set; }
            [Indexed]
            public DateTime Created { get; set; }
            [Indexed]
            public string Filename { get; set; }
            public string[] Args { get; set; }


           override public string ToString()
           { 
                return Name + ": " + Args;
           }
    }
}
