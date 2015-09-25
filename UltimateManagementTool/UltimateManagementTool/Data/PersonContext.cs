namespace UltimateManagementTool.Data
{
    using System.Data.Entity;
    using UltimateManagementTool.Interfaces;
    
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
