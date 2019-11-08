using keepr.Interfaces;

namespace keepr.Models
{
    public class Keep : IKeep
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public bool isPrivate { get; set; }
        public int views { get; set; }
    }
}