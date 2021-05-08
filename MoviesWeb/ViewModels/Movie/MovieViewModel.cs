using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.CustomAttributes.Validation;
using MoviesWeb.ViewModels.MovieActor;
using MoviesWeb.ViewModels.MovieDirector;
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
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
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
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".jfif" })]
        [Display(Name = "Movie Image", Prompt = "Upload movie image")]
        public IFormFile Photo { get; set; }

        [Display(Name = "Video Url", Prompt ="Please provide video url")]
        public string VideoUrl { get; set; }

        [Display(Name = "Movie Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Movie Language")]
        public string Language { get; set; }

        [Display(Name = "Created Time")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Last Modified Time")]
        public DateTime LastModifiedAt { get; set; }

        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; }

        public IEnumerable<MovieActorViewModel> MovieActors { get; set; }
        public IEnumerable<MovieDirectorViewModel> MovieDirectors { get; set; }
    }
}
