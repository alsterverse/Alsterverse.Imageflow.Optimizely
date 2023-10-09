using EPiServer.Core;
using Imazen.Common.Storage;

namespace Alsterverse.Imageflow.Optimizely
{
    public class OptimizelyBlobData : IBlobData
    {
        private readonly IBinaryStorable content;

        public OptimizelyBlobData(IBinaryStorable content)
        {
            this.content = content;
        }

        public bool? Exists => content != null && content.BinaryData != null;
        public DateTime? LastModifiedDateUtc => content is IChangeTrackable trackable ? trackable.Changed.ToUniversalTime() : null;

        public void Dispose()
        {

        }

        public Stream OpenRead()
        {
            return content.BinaryData.OpenRead();
        }
    }
}
