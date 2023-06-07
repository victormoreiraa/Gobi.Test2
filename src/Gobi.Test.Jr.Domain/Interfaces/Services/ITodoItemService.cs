using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobi.Test.Jr.Domain.Interfaces.Services
{
    public interface  ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetAll();
        Task<TodoItem> GetById(int id);
        Task Add(TodoItem item);
        Task Delete(TodoItem item);
        Task Update (TodoItem item);



    }
}
