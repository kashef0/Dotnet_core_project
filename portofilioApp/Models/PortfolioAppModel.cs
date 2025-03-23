using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Models 
{
    public class UserProfileModel 
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Namn")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Biografi")]
        public string? Biog { get; set; }

        [Display(Name = "Bild")]
        public string? Image { get; set; }

        [Display(Name = "Skapad den")]
        public DateTime? CreatedAt { get; set; }
    }

    public class ServiceModel  
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tjänst")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }

        [Display(Name = "Skapad den")]
        public DateTime? CreatedAt { get; set; }
    }

    public class SkillsModel  
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Färdighet")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Ikon")]
        public string? Icon { get; set; }

        [Range(0, 10)]
        [Display(Name = "Nivå")]
        public int Level { get; set; }

        [Display(Name = "Skapad den")]
        public DateTime? CreatedAt { get; set; }
    }

    public class ExperienceModel  
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Företag")]
        public string Company { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Roll")]
        public string Role { get; set; } = string.Empty;

        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }

        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Slutdatum")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Skapad den")]
        public DateTime? CreatedAt { get; set; }
    }

    public class ProjectModel  
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }

        [Display(Name = "Bild")]
        public string? Image { get; set; }

        [Display(Name = "Github")]
        public string? GitHubLink { get; set; }

        [Display(Name = "Demo-länk")]
        public string? DemoLink { get; set; }
        
        [Display(Name = "Skapad den")]
        public DateTime? CreatedAt { get; set; }
    }

    public class SocialLinkModel  
    {
        public int Id { get; set; }

        [Display(Name = "Plattform")]
        public string? Platform { get; set; }

        [Required]
        [Display(Name = "URL")]
        public string Url { get; set; } = string.Empty;

        [Display(Name = "Användaren's social media konto")]
        public string UserAccoutn { get; set; } = string.Empty;

        [Display(Name = "Skapad den")]
        public DateTime? CreatedAt { get; set; }
    }

    public class ContactInfoModel  
    {
        public int Id { get; set; }

        [Display(Name = "Telefonnummer")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Adress")]
        public string? Adress { get; set; }

        [Display(Name = "Postnummer")]
        public string? Postkod { get; set; }

        [Display(Name = "Stad")]
        public string? City { get; set; }

        [EmailAddress]
        [Display(Name = "E-post")]
        public string? Email { get; set; }
    }

    public class ContactModel  
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Namn")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "E-post")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(300, ErrorMessage = "Meddelandet får inte vara längre än 300 tecken.", MinimumLength = 5)]
        [Display(Name = "Meddelande")]
        public string? Message { get; set; }

        [Display(Name = "Skapad den")]
        public DateTime? CreatedAt { get; set; }
    }

    public class AboutMeModel {
         public int Id { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Om Mig")]
        public string About { get; set; } = string.Empty;

        [Display(Name = "ImageUrl")]
        public string? Url { get; set; }
    }

    public class HomeViewModel 
    {
        public List<UserProfileModel> UserProfile { get; set; } = new();
        public List<SkillsModel> Skills { get; set; } = new();
        public List<ServiceModel> Services { get; set; } = new();
        public List<ProjectModel> Projects { get; set; } = new();
        public List<ExperienceModel> Experiences { get; set; } = new();
        public List<ContactInfoModel> ContactInfo { get; set; } = new();
        public List<SocialLinkModel> SocialLinks { get; set; } = new();
        public List<AboutMeModel> About { get; set; } = new();
        public List<ContactModel> Contacts { get; set; } = new();
    }
}
