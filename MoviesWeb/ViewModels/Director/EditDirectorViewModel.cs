using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.CustomAttributes.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.Director
{
    public class EditDirectorViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Director Name", Prompt = "Enter Director name")]
        public string Name { get; set; }
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

        [Display(Name="Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Last modified At")]
        public DateTime LastModifiedAt { get; set; }
    }
}
