using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.CustomAttributes.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.Actor
{
    public class ActorViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Actor Name", Prompt = "Enter Actor name")]
        public string Name { get; set; }

        [Display(Name = "Actor Image", Prompt = "Provide actor Image")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [Display(Name = "Upload actor image")]
        [AllowedExtensions(new string[] { ".jpg",".jpeg", ".png", ".jfif" })]
        public IFormFile Photo { get; set; }

        [Required]
        [Display(Name ="Description", Prompt = "Enter description")]
        public string Description { get; set; }

        [Display(Name = "Created Time")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }


        [Display(Name = "Last Modified Time")]
        public DateTime LastModifiedAt { get; set; }

        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; }

        public string Gender { get; set; }

    }
}
