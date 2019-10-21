using keepr.Interfaces;

namespace keepr.Models
{
    public class Vault : IVault
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}