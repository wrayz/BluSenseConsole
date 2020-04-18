using System.Collections.Generic;

namespace BluSenseConsole.Interfaces
{
    public interface IReader
    {
        List<Dictionary<string, string>> GetDictionaries();
    }
}
