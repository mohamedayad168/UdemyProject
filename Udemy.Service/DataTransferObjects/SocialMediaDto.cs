namespace Udemy.Service.DataTransferObjects
{
    public class SocialMediaDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }
    public class UpdateSocialMediaDto
    {
        public string Link { get; set; }
    }
    public class UserSocialMediasDto
    {
        public SocialMediaDto LinkedIn { get; set; }
        public SocialMediaDto Facebook { get; set; }
        public SocialMediaDto Instagram { get; set; }
        public SocialMediaDto Twitter { get; set; }
    }
}
