namespace CompanyProject.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<User_Role> Users { get; set; }

    }
}
