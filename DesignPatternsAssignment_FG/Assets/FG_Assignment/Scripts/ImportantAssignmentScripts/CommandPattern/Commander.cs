public class Commander
{
    /// <summary>
    /// CommandPattern: the commander is in charge of ordering commands from the command factory
    /// and then execute the commands.
    /// </summary>
    private ICommandFactory _commandFactory;

    public void Initialize(Dependencies dependencies)
    {
        _commandFactory = dependencies.CommandFactory;
    }

    public void Execute<T>(object[] args) where T : ICommand
    {
        _commandFactory.Create<T>(args).Execute();
    }

    public void Execute<T>(object arg) where T : ICommand
    {
        _commandFactory.Create<T>(arg).Execute();
    }
}