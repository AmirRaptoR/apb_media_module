using System.IO;
using System.Threading.Tasks;

namespace Farazpardazan.Media
{
    public class PhysicalFileSystem : IFileSystem
    {
        public Task<Stream> ReadFile(string path)
        {
            return Task.FromResult<Stream>(File.OpenRead(path));
        }

        public Task<FileInfo> GetInfo(string path)
        {
            return Task.FromResult(new FileInfo(path));
        }

        public async Task WriteFile(string path, Stream input, bool overwrite = false)
        {
            if (overwrite && File.Exists(path))
            {
                File.Delete(path);
            }

            var fileStream = File.OpenWrite(path);
            await input.CopyToAsync(fileStream);
        }

        public async Task WriteFile(string path, byte[] input, bool overwrite = false)
        {
            if (overwrite && File.Exists(path))
            {
                File.Delete(path);
            }

            using var outputFile = File.OpenWrite(path);
            await outputFile.WriteAsync(input, 0, input.Length);
        }

        public Task<Stream> OpenWrite(string path, bool overwrite = false)
        {
            if (overwrite && File.Exists(path))
            {
                File.Delete(path);
            }

            return Task.FromResult<Stream>(File.OpenWrite(path));
        }
    }
}