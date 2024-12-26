namespace CompanyProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        //Navigation Properties
        public List<Post> posts { get; set; }
        /////
        public List<User_Role> Roles { get; set; }


    }
}
