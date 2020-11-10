public interface ICommandFactory
{
    ICommand Create<T>(object[] args) where T : ICommand;
    ICommand Create<T>(object arg) where T : ICommand;
}
