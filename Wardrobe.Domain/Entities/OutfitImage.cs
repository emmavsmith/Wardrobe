namespace Wardrobe.Domain.Entities
{
    public class OutfitImage : BaseEntity
    {
        public OutfitImage()
        {
            // Parameterless constructor for EF
        }

        public OutfitImage(byte[] sourceBytes, string contentType)
        {
            SourceBytes = sourceBytes;
            ContentType = contentType;
        }

        public byte[] SourceBytes { get; set; }
        public string ContentType { get; set; }
    }
}