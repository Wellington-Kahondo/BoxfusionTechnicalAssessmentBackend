using System.ComponentModel.DataAnnotations;

namespace Boxfusion.TechnicalAssessment.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}