using Microsoft.EntityFrameworkCore;
using TwitterClone.Models;

namespace TwitterClone.Repositories
{
    public class TweetRepository : ITweetRepository
    {

        public TweetRepository() { }
        public AppDbContext Context { get; }
        public TweetRepository(AppDbContext appDbContext)
        {
            Context = appDbContext;
        }


        public List<Tweet> GetAll()
        {
            return Context.Tweets.Include(o=>o.User).ToList();
        }

        public List<Tweet> Get(int id)
        {
            return Context.Tweets.Where(t=>t.TweetId==id).ToList();
        }

        public void Create(Tweet tweet)
        {
            throw new NotImplementedException();
        }
    }
}
