namespace UltimateManagementTool.Specs
{
    using System.Collections.Generic;

    using DynamicSpecs.Core;

    using UltimateManagementTool.Interfaces;

    public interface INeedPersons : ISpecify
    {
        IEnumerable<Person> AvailablePersons { get; set; }
    }
}