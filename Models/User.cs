namespace TwitterClone.Models
{

    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string ProfileImage { get; set; } = "images/default-profile-image.png";

        public ICollection<Tweet> Tweets { get; set; } = new List<Tweet>();
    }
}
