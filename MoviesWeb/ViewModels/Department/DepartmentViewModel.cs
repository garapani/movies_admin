using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.Department
{
    public class DepartmentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name", Prompt = "Enter Department name")]
        public string Name { get; set; }
    }
}
