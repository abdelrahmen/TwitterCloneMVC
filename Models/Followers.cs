using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Models
{
    public class Followers
    {
        // Composite primary key
        public string FollowerId { get; set; }

        public string FollowingId { get; set; }

        // Navigation properties
        public User Follower { get; set; }
        public User Following { get; set; }
    }

}
