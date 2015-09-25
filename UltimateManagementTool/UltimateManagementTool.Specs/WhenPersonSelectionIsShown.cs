using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateManagementTool.Specs
{
    using DynamicSpecs.NUnit;

    using NUnit.Framework;

    using UltimateManagementTool.Interfaces;
    using UltimateManagementTool.ViewModels;

    public class WhenPersonSelectionIsShown : Specifies<PersonSelectionViewModel>
    {
        public override void Given()
        {

            this.AvailablePersons = this.Given<WithPersons>().AvailablePersons;
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
    }
}
