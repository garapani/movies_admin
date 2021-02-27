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
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jfif" })]
        public IFormFile Photo { get; set; }

        [Required]
        [Display(Name ="Description", Prompt = "Enter description")]
        public string Description { get; set; }

        //[HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset UpdatedAt { get; set; }

        //[HiddenInput(DisplayValue = false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
