using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.CustomAttributes.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.Actor
{
    public class EditActorViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Actor Name", Prompt = "Enter Actor name")]
        public string Name { get; set; }

        //[Display(Name="Image")]
        //public string ImageId { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jfif" })]
        public IFormFile Photo { get; set; }

        [Required]
        [Display(Name = "Description", Prompt = "Enter description")]
        public string Description { get; set; }

        public string Gender { get; set; }
    }

}
