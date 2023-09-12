using TwitterClone.Models;

namespace TwitterClone.Repositories
{
    public interface ITweetRepository
    {
        List<Tweet> GetAll();
        List<Tweet> Get(int id);
        void Create(Tweet tweet);
    }
}