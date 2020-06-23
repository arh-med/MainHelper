using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces.StoreBase;

namespace TaskLibrary.Manager.Interfaces
{
    public interface ICategoryStoreInMemoryInterface : IStoreBaseInterface<CategoryClass>
    {
        CategoryClass Create(string Name, string Color);
    }
}
