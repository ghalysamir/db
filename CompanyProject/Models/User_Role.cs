using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Models
{
    //composite primary key
    [PrimaryKey("User_Id", "Role_Id")]
    public class User_Role
    {
        [ForeignKey("user")]
        public int User_Id { get; set; }

        [ForeignKey("role")]

        public int Role_Id { get; set; }

        //Navigation Properties

       public User user { get; set; }
       public Role role { get; set; }


    }
}
