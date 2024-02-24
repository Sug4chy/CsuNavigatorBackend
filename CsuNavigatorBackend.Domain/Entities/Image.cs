namespace CsuNavigatorBackend.Domain.Entities;

public class Image : Entity
{
    public string Name { get; set; }
    public string ContentType { get; set; }
    public ImageType ApplicationImageType { get; set; }
    public Profile? Profile { get; set; }
    public Map? Map { get; set; }
    public string FileName { get; set; }
}
public enum ImageType
{
    Avatar,
    Map
}