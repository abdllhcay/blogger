using Blogger.Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Core.Models.Category
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxStringLength)]
        [Display(Name = "Başlık")]
        public string Name { get; set; }
    }
}
