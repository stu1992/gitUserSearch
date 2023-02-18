using giveMeUsers.HTTPClients;
using giveMeUsers.Models;
using giveMeUsers.Services;

namespace UserTests
{
    // There are better ways to mock out functions but I want to limit the complexity of this
    internal class MockClient : IHTTPClient
    {
        public MockClient()
        {
        }
        Task<GitUser> IHTTPClient.getUser(string user)
        {
            var mockUser = new GitUser
            {
                name = "stu",
                login = "stu",
                company = "CapitalTransport",
                followers = 50,
                public_repos = 2
            };
             
            return Task.FromResult(mockUser);
        }
    }
    internal class MockClientWithDevideByZero : IHTTPClient
    {
        public MockClientWithDevideByZero()
        {
        }
        Task<GitUser> IHTTPClient.getUser(string user)
        {
            var mockUser = new GitUser
            {
                name = "stu",
                login = "stu",
                company = "CapitalTransport",
                followers = 50,
                public_repos = 0
            };

            return Task.FromResult(mockUser);
        }
    }
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CheckBasicService()
        {
            var client = new MockClient();
            var service = new UserService(client);
            string[] users = { "stu" };
            var response = service.getUser(users);
            Assert.AreEqual(response.Result[0].average_followers_per_repo, 25);
            Assert.AreEqual(response.Result[0].name, "stu");
            Assert.AreEqual(response.Result[0].number_of_followers, 50);
            Assert.AreEqual(response.Result[0].number_of_public_repos, 2);
        }

        [TestMethod]
        public void CheckDevideByZero()
        {
            var client = new MockClientWithDevideByZero();
            var service = new UserService(client);
            string[] users = { "stu" };
            var response = service.getUser(users);
            Assert.AreEqual(response.Result[0].average_followers_per_repo, 50);
            Assert.AreEqual(response.Result[0].number_of_public_repos, 0);
        }
    }

}