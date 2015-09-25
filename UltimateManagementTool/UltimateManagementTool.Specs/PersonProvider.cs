namespace UltimateManagementTool.Specs
{
    using DynamicSpecs.Core.WorkflowExtensions;

    using FakeItEasy;

    using Tynamix.ObjectFiller;

    using UltimateManagementTool.Interfaces;

    public class PersonProvider : IExtend<INeedPersons>
    {
        public void Extend(INeedPersons target, WorkflowPosition currentPosition)
        {
            var filler = new Filler<Person>();
            target.AvailablePersons = filler.Create(2);

            var repository = target.GetInstance<IRepository>();

            A.CallTo(() => repository.GetPersons()).Returns(target.AvailablePersons);
        }
    }
}