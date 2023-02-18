namespace giveMeUsers.Models
{
    public record Plan
    {
        public string name { get; set; }
        public int space { get; set; }
        public int collaborators { get; set; }
        public int private_repos { get; set; }
    }
}
