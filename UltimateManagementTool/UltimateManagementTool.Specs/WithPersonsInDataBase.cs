namespace UltimateManagementTool.Specs
{
    using System;
    using System.Collections.Generic;

    using DynamicSpecs.Core;

    using Tynamix.ObjectFiller;

    using UltimateManagementTool.Interfaces;

    public class WithPersonsInDataBase : ISupport
    {
        public IEnumerable<Person> AvailablePersons { get; set; }

        public void Support(ISpecify specification)
        {
            var databaseSpecification = specification as INeedDataBaseContext;
            if (databaseSpecification == null)
            {
                throw new InvalidOperationException("Specification must implement INeedDataBaseContext to get access to a data base.");
            }

            var context = databaseSpecification.Context;

            var filler = new Filler<Person>();
            filler.Setup().OnProperty(x => x.Id).IgnoreIt();

            this.AvailablePersons = filler.Create(2);
            context.Persons.AddRange(this.AvailablePersons);
            context.SaveChanges();
        }
    }
}