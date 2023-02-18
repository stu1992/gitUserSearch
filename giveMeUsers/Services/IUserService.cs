using giveMeUsers.Models;

namespace giveMeUsers.Services
{
    public interface IUserService
    {
        public Task<List<ResponseUser>> getUser(string[] users);
    }
}
