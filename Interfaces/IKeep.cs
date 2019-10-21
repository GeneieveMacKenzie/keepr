namespace keepr.Interfaces
{
    public interface IKeep
    {
        string userId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Img { get; set; }
        bool isPrivate { get; set; }
    }
}


