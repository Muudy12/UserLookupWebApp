namespace UserLookupWebApp.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
