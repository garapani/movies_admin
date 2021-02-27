using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.CustomAttributes.Validation;
using MoviesWeb.ViewModels.MovieCast;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.Movie
{
    public class MovieViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Movie Title", Prompt = "Enter Movie title")]
        public string Title { get; set; }

        [Display(Name = "Movie Local Title", Prompt = "Enter Movie local title")]
        public string LocalTitle { get; set; }

        [Required]
        [Display(Name = "Overview", Prompt = "Enter overview")]
        public string Overview { get; set; }

        [Display(Name = "Release Date", Prompt = "Enter release date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Run time", Prompt = "Enter run time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? RunTime { get; set; }

        //[Display(Name = "Tagline", Prompt = "Enter tagline")]
        //public string Tagline { get; set; }

        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jfif" })]
        [Display(Name = "Movie Image", Prompt = "Upload movie image")]
        public IFormFile Photo { get; set; }

        [Display(Name = "Movie Image")]
        public string ImageUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        public IEnumerable<MovieCastViewModel> Cast { get; set; }
    }
}
