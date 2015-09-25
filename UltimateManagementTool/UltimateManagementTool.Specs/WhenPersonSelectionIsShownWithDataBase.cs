namespace UltimateManagementTool.Specs
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.Core;
    using DynamicSpecs.NUnit;

    using NUnit.Framework;

    using UltimateManagementTool.Data;
    using UltimateManagementTool.Interfaces;
    using UltimateManagementTool.ViewModels;

    public class WhenPersonSelectionIsShownWithDataBase : Specifies<PersonSelectionViewModel>, INeedDataBaseContext
    {
        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            typeRegistration.Register<Repository, IRepository>();

            base.RegisterTypes(typeRegistration);
        }

        public override void Given()
        {

            this.AvailablePersons = this.Given<WithPersonsInDataBase>().AvailablePersons;
        }

        public override void When()
        {
            this.SUT.OnShow();
        }

        [Test]
        public void ThenAllAvailablePersonsShown()
        {
            Assert.AreEqual(this.AvailablePersons.Count(), this.SUT.Persons.Count());
        }

        public IEnumerable<Person> AvailablePersons { get; set; }

        public PersonContext Context { get; set; }
    }
}