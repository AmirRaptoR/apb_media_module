using Volo.Abp.Domain.Entities.Auditing;

namespace Farazpardazan.Media
{
    public class MediaEntity : CreationAuditedEntity<long>
    {
        public MediaEntity(string fileName, string address, string hash, string uniqueId, string contentType, long size)
        {
            FileName = fileName;
            Address = address;
            Hash = hash;
            UniqueId = uniqueId;
            ContentType = contentType;
            Size = size;
        }

        private MediaEntity()
        {
        }

        public string FileName { get; private set; }
        public string Address { get; private set; }
        public string Hash { get; private set; }
        public string UniqueId { get; private set; }
        public string ContentType { get; private set; }
        public long Size { get; private set; }
    }
}