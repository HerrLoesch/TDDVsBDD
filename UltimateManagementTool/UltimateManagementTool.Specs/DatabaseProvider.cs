namespace UltimateManagementTool.Specs
{
    using System.Transactions;

    using DynamicSpecs.Core.WorkflowExtensions;

    using UltimateManagementTool.Data;

    public class DatabaseProvider : IExtend<INeedDataBaseContext>
    {
        private TransactionScope transactionScope;

        public void Extend(INeedDataBaseContext target, WorkflowPosition currentPosition)
        {
            switch (currentPosition)
            {
                case WorkflowPosition.Given:
                    this.CreateContext(target);
                    break;
                case WorkflowPosition.Then:
                    this.Cleanup();
                    break;
            }
        }

        private void Cleanup()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }

            if (this.transactionScope != null)
            {
                this.transactionScope.Dispose();
            }
        }

        private void CreateContext(INeedDataBaseContext target)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TransactionManager.MaximumTimeout;
            this.transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);

            target.Context = this.Context = new PersonContext();
        }

        public PersonContext Context { get; set; }
    }
}