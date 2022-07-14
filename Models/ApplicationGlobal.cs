namespace CraftMake.Models
{
    public class ApplicationGlobal
    {
        public static bool LoggedIn { get; set; }
        public static string userName { get; set; }
        public ApplicationGlobal()
        {
            LoggedIn = false;
            userName = "";
        }
    }
}
