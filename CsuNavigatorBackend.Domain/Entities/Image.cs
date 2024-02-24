namespace CsuNavigatorBackend.Domain.Entities;

public class Image : Entity
{
    public required string FileName { get; set; }
    public required string ContentType { get; set; }
    public ImageType ApplicationImageType { get; set; }
    public Profile? Profile { get; set; }
    public Map? Map { get; set; }
}
public enum ImageType
{
    Avatar,
    Map
}