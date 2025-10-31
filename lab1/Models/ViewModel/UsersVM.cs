namespace lab1.Models.ViewModel
{
    public class UsersVM
    {
        public string Id { get; set; }
        public string Email{ get; set; }
        public string UserName{ get; set; }

        public IList<string> Roles { get; set; }
    }
}
