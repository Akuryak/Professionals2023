namespace The_guardian_pro_API
{
    public partial class Context
    {
        public static Models.TheGuardianProContext context { get; } = new Models.TheGuardianProContext();

        //Scaffold-DbContext "Server=localhost;Database=the_guardian_pro;User=root;Password=12345" "Pomelo.EntityFrameworkCore.MySql" -outputdir Models -context TheGuardianProContext
    }
}
