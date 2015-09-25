namespace UltimateManagementTool.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using DynamicSpecs.Core.WorkflowExtensions;

    using NUnit.Framework;

    using UltimateManagementTool.Data;
    using UltimateManagementTool.Interfaces;

    [SetUpFixture]
    public class Configuration : Extensions
    {
        [SetUp]
        public void Setup()
        {
            this.CreateDatabase();

            Extend<INeedDataBaseContext>().With<DatabaseProvider>().Before(WorkflowPosition.Given | WorkflowPosition.Then);
        }
        
        private void CreateDatabase()
        {
            using (var context = new PersonContext())
            {
                if (!context.Database.Exists())
                {
                    context.Database.Create();
                }
            }
        }
    }
}
