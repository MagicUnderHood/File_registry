using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace File_manager
{
    public interface IMetaInfoFetcher<F> where F : IFormattable
    {
        
        F FetchMetaInfo(FileStream reader);
    }
}
