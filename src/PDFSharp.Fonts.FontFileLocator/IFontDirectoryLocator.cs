using System.Collections.Generic;
using System.IO;

namespace PDFSharp.Fonts
{
    public interface IFontDirectoryLocator
    {
        IEnumerable<DirectoryInfo> FindDirectories();
    }
}
