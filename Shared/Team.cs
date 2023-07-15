using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Team Code")]
        [Column("Code")]
        public string Code { get; set; }

        public string TeamName { get; set; }

        public string TeamImgUrl { get; set; }

        public string TeamPrimaryColor { get; set; }
        public string TeamSecondaryColor { get; set; }
        public string TeamTextColor { get; set; }

        public bool IncludeShirtSize { get; set; } = false;

        public bool Active { get; set; }

        public int? Region { get; set; }
    }
}
