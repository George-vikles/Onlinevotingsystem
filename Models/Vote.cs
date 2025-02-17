namespace Onlinevotingsystem.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.UtcNow;

    }
}
