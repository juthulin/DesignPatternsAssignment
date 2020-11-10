using System;

public class CommandFactory : ICommandFactory
{
    /// <summary>
    /// FactoryPattern: This factory creates commands based on what is requested from the commander
    /// and then sends the created command back to the commander for execution.
    /// </summary>
    /// <param name="args"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public ICommand Create<T>(object[] args = null) where T : ICommand
    {
        return args == null
            ? (ICommand) Activator.CreateInstance(typeof(T))
            : (ICommand) Activator.CreateInstance(typeof(T), args);
    }

    public ICommand Create<T>(object arg) where T : ICommand
    {
        return (ICommand) Activator.CreateInstance(typeof(T), arg);
    }
}