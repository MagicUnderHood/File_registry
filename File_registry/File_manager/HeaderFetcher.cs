using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace File_manager
{
    public class HeaderFetcher: IMetaInfoFetcher<TextFileHeader>
    {
        public TextFileHeader FetchMetaInfo(FileStream reader)
        {
           var line = (new StreamReader(reader)).ReadLine();
           var tokens = line.Split(new string [] {" "}, StringSplitOptions.None);
           var title = tokens.First();
           var tags = tokens.Skip(1).ToArray();
           return new TextFileHeader(title, tags);
        }
    } 

    public class TextFileHeader : IFormattable
    {
        public string Title;
        public string[] Tags;

        public TextFileHeader(string title, string[] tags)
        {
            Title = title;
            Tags = tags;
        }

        public string ToString(string ff, IFormatProvider formatter)
        {
            return Title + ": " + Tags.ToString();
        }
    }
}