using Gobi.Test.Jr.Domain.Interfaces.Generics;

namespace Gobi.Test.Jr.Domain.Interfaces
{
    public interface ITodoItemRepository : InterfaceGeneric<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetAll();              
        Task Add(TodoItem entity);
        Task Update(TodoItem entity);
        Task Delete(TodoItem entity);
    }
}
