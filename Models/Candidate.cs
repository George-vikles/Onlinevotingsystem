using static System.Collections.Specialized.BitVector32;

namespace Onlinevotingsystem.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public int ElectionId { get; set; }
        public Election Election { get; set; }
        public ICollection<Vote> Votes { get; set; }

    }
}
