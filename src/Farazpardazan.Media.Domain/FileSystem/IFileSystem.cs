using System.IO;
using System.Threading.Tasks;

namespace Farazpardazan.Media
{
    public interface IFileSystem
    {
        Task<Stream> ReadFile(string path);
        Task<FileInfo> GetInfo(string path);
        Task WriteFile(string path, Stream input, bool overwrite = false);
        Task WriteFile(string path, byte[] input, bool overwrite = false);
        Task<Stream> OpenWrite(string path, bool overwrite = false);
    }
}