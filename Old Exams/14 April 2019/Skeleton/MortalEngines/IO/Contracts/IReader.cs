namespace MortalEngines.IO.Contracts
{    
    using System.Collections.Generic;
    using System.Windows.Input;
    using MortalEngines.Core.Contracts;

    public interface IReader
    {
        IList<ICommand> ReadCommands();
    }
}