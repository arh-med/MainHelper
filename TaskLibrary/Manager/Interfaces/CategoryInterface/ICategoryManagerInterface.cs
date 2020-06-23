using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces.ManagerBase;

namespace TaskLibrary.Manager.Interfaces
{
    public interface ICategoryManagerInterface : IManagerBaseInterface<CategoryClass>
    {
        CategoryClass Create(string Name , string Color);
    }
}
