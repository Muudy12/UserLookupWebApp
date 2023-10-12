namespace UserLookupWebApp.Models
{
    public class UserData
    {
        public static List<UserModel> Users { get; set; }
        public static List<UserModel> GetUsers()
        {
            Users = new List<UserModel>();

            Users.Add(new UserModel()
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 18
            });
            Users.Add(new UserModel()
            {
                FirstName = "Minnie",
                LastName = "John",
                Age = 17
            });
            Users.Add(new UserModel()
            {
                FirstName = "Carl",
                LastName = "Lou",
                Age = 16
            });
            Users.Add(new UserModel()
            {
                FirstName = "Happy",
                LastName = "Doe",
                Age = 22
            });
            Users.Add(new UserModel()
            {
                FirstName = "Ken",
                LastName = "Smith",
                Age = 21
            });

            return Users;
        }
    }
}
