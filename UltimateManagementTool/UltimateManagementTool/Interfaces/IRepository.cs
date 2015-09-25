namespace UltimateManagementTool.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;

    using UltimateManagementTool.Data;

    public interface IRepository
    {
        IEnumerable<Person> GetPersons();
    }

    public class Repository : IRepository
    {
        public IEnumerable<Person> GetPersons()
        {
            using (var context = new PersonContext())
            {
               return context.Persons.ToList();
            }
        }
    }
}