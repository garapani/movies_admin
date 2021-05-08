using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.CustomAttributes.Validation;
using MoviesWeb.ViewModels.MovieDirector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.Director
{
    public class DirectorViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Director Name", Prompt = "Enter Director name")]
        public string Name { get; set; }

        [Display(Name = "Director Image", Prompt = "Provide Director Image")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [Display(Name = "Upload Director image")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jfif" })]
        public IFormFile Photo { get; set; }

        [Required]
        [Display(Name = "Description", Prompt = "Enter description")]
        public string Description { get; set; }

        [Display(Name = "Last Modified at")]
        public DateTime LastModifiedAt { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Last Modified by")]
        public string LastModifiedBy { get; set; }

        [Display(Name = "Created by")]
        public string CreatedBy { get; set; }
        public IEnumerable<MovieDirectorViewModel> MovieDirectors { get; set; }
    }
}
