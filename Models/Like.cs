using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Models
{
    public class Like
    {
        public int LikeId { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }

        [Required]
        public int TweetId { get; set; }
        [Required]
        public Tweet Tweet { get; set; }
    }

}
