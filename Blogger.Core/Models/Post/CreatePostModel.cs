using Blogger.Core.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Core.Models.Post
{
    public class CreatePostModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [MaxLength(50, ErrorMessage = ErrorMessages.MaxStringLength)]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name = "İçerik")]
        public string Content { get; set; }

        public string Summary { get; set; } = String.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name = "Yayınlama Tarihi")]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Display(Name = "Kategori")]
        public string Category { get; set; }
    }
}
