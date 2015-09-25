namespace UltimateManagementTool.Specs
{
    using System.Collections.Generic;

    using DynamicSpecs.Core;

    using FakeItEasy;

    using Tynamix.ObjectFiller;

    using UltimateManagementTool.Interfaces;

    public class WithPersons : ISupport
    {
        public IEnumerable<Person> AvailablePersons { get; private set; }

        public void Support(ISpecify specification)
        {
            var filler = new Filler<Person>();
            this.AvailablePersons = filler.Create(2);

            var repository = specification.GetInstance<IRepository>();

            A.CallTo(() => repository.GetPersons()).Returns(this.AvailablePersons);
        }
    }
}