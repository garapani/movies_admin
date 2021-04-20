using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.CustomAttributes.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.Movie
{
    public class EditMovieViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title", Prompt = "Enter Movie title")]
        public string Title { get; set; }

        [Display(Name = "Local Title", Prompt = "Enter Movie local title")]
        public string LocalTitle { get; set; }

        [Required]
        [Display(Name = "Overview", Prompt = "Enter overview")]
        public string Overview { get; set; }

        [Display(Name = "Release Date", Prompt = "Enter release date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Run time", Prompt = "Enter run time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? RunTime { get; set; }

        [Display(Name = "Tagline", Prompt = "Enter tagline")]
        public string Tagline { get; set; }

        //[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png",".jfif" })]
        public IFormFile Photo { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Video url")]
        public string VideoUrl { get; set; }

        [Display(Name = "Language")]
        public string Language { get; set; }
    }
}
