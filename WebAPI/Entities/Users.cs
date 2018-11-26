namespace Entities
{
    public class Users : BaseEntity
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public System.DateTime PasswordExpiry { get; set; }

        public string ContactNo { get; set; }
    }
}
