using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.ViewModel
{
    public class PostVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [Length (5, 10, ErrorMessage = "The title must be greater than 5 less than 10 characters.") ]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a category.")]
        [Length(5, 10, ErrorMessage = "The category must be greater than 5 less than 10 characters.")]

        public string Categort { get; set; }

        [Required(ErrorMessage = "Please enter the body text.")]
        public string Body { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Likes must be a positive number")]
        public int Likes { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Likes must be a positive number")]
        public int Share { get; set; }

        //[ForeignKey("user")]
        public int User_Id { get; set; }
    }
}
