
using giveMeUsers.Models;
using GiveMeUsers;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace giveMeUsers.HTTPClients
{
    public class GithubClient : IHTTPClient
    {
        RestClient client;
        public GithubClient()
        {
            var options = new RestClientOptions("https://api.github.com")
            {
                ThrowOnAnyError = true,
                Timeout = 5000
            };
            client = new RestClient(options);
        }

        public async Task<GitUser> getUser(string user)
        {
            // API key only has user read permissions
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
                Constants.GitHubAPIKey, "Bearer");
                var response =  await client.GetJsonAsync<GitUser>("/users/"+user);
                return response;
        }
    }
}
