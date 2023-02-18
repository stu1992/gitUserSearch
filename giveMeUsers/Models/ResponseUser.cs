namespace giveMeUsers.Models
{
    public class ResponseUser
    {
        public string name { get; set; }
        public string login { get; set; }
        public string company { get; set; }
        public int number_of_followers { get; set; }
        public int number_of_public_repos { get; set; }
        public float average_followers_per_repo { get; set; }
    }
    public class UserOrdering : IComparer<ResponseUser>
    {
        public int Compare(ResponseUser x, ResponseUser y)
        {
            if (x.name != null)
            {
                return x.name.CompareTo(y.name);
            }
            else
            {
                // I arbitrarily want null names to be last
                return 1;
            }
        }
    }
}
