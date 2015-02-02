namespace Wardrobe.Domain.Entities
{
    public class ItemImage : BaseEntity
    {
        public ItemImage()
        {
            // Parameterless constructor for EF
        }

        public ItemImage(byte[] sourceBytes, string contentType)
        {
            SourceBytes = sourceBytes;
            ContentType = contentType;
        }

        public byte[] SourceBytes { get; set; }
        public string ContentType { get; set; }
    }
}