using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }

  
        public string Title { get; set; }


        public string Categort { get; set; }


        public string Body { get; set; }


        public int Likes { get; set; }


        public int Share { get; set; }

        [ForeignKey("user")]
        public int User_Id { get; set; }
        //Navigation Properties
        public User user { get; set; }


         
    }
}
