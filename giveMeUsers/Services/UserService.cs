using giveMeUsers.Controllers;
using giveMeUsers.HTTPClients;
using giveMeUsers.Models;
using System.ComponentModel;

namespace giveMeUsers.Services
{
    public class UserService : IUserService
    {
        private readonly IHTTPClient client;
        public UserService(IHTTPClient HTTPClient)
        {
            client = HTTPClient;
        }

        public async Task<List<ResponseUser>> getUser(string[] users)
        {
            List<ResponseUser> response = new List<ResponseUser>();
            var toBequeried = users.Distinct();
            foreach (var userId in toBequeried)
            {
                try
                {
                    var fromGit = await client.getUser(userId);

                    //TODO make sure this is a non blocking call
                    var newUser = new ResponseUser
                    {
                        name = fromGit.name,
                        login = fromGit.login,
                        company = fromGit.company,
                        number_of_followers = fromGit.followers,
                        number_of_public_repos = fromGit.public_repos,
                        average_followers_per_repo = fromGit.followers / (fromGit.public_repos == 0 ? 1 : fromGit.public_repos)
                    };
                    //TODO maybe create mapper for this complex object

                    // the API i'm using provides a success response to garbage non existing user data
                    if (newUser.login != null)
                    {
                        response.Add(newUser);
                    }
                    else
                    {
                        throw new Exception("Unable to look up user");
                    }
                    
                }
                catch (Exception e)
                {
                // do nothing on exception
                }
            }
            IComparer<ResponseUser> comparer = new UserOrdering();
            response.Sort(comparer);
            return response;
        }
    }
}
