namespace PortfolioWebsite.Models
{
    public class PortfolioData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;
        public string BackgroundImageUrl { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public string Resume { get; set; } = string.Empty;
        public List<string> GalleryImages { get; set; } = new List<string>();
        public List<Project> Projects { get; set; } = new List<Project>();
        public ContactInfo? Contact { get; set; }
        public MusicPlayer MusicPlayer { get; set; } = new MusicPlayer();
    }

    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Technologies { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
    }

    public class ContactInfo
    {
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string GitHub { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }

    public class MusicPlayer
    {
        public string SongTitle { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string AudioUrl { get; set; } = string.Empty;
        public int Duration { get; set; }
        public bool IsPlaying { get; set; }
    }
}
