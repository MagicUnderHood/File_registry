using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace File_manager
{
    public class Manager<TF> where TF : IFormattable
    {
        private readonly string _extension;
        private readonly string _workingDir;
        private readonly IMetaInfoFetcher<TF> _metaInfoFetcher;
        public Manager(string workingDir, IMetaInfoFetcher<TF> metaInfoFetcher, string extension = ".txt")
        {
            if (!Directory.Exists(workingDir))
            {
                throw new ArgumentException("Directory path doesn't exist: " + workingDir);
            }

            _metaInfoFetcher = metaInfoFetcher;
            _extension = extension;
            _workingDir = workingDir;
        }

        public (TF, FileStream) GetFile(string fileId)
        {
            var fileName = fileId + _extension;
            var filePath = Path.Combine(_workingDir, fileName);
            var content = File.OpenRead(filePath);
            return (_metaInfoFetcher.FetchMetaInfo(content), content);
        }

        public void PutFile(string fileId, FileStream content)
        {
            var fileName = fileId + _extension;
            if (File.Exists(Path.Combine(_workingDir, fileName)))
            {
                throw new FileLoadException("File "+ fileName + " already exist");
            }

            var output = File.OpenWrite(Path.Combine(_workingDir, fileName));
            content.CopyTo(output);
        }
    }
}
