namespace UltimateManagementTool.Specs
{
    using UltimateManagementTool.Data;

    public interface INeedDataBaseContext
    {
        PersonContext Context { get; set; }
    }
}