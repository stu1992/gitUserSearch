using giveMeUsers.Models;

namespace giveMeUsers.HTTPClients
{
    public interface IHTTPClient
    {
        public Task<GitUser> getUser(string user);
    }
}
