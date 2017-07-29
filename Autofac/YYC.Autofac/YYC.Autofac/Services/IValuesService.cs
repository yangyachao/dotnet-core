using System.Collections.Generic;

namespace YYC.Autofac.Services
{
    public interface IValuesService
    {
        IEnumerable<string> FindAll();

        string Find(int id);
    }
}