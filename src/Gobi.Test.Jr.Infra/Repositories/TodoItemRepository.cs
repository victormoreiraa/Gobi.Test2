using Gobi.Test.Jr.Domain;
using Gobi.Test.Jr.Domain.Interfaces;
using Gobi.Test.Jr.Infra.Data;
using Gobi.Test.Jr.Infra.Repositories.Generics;

namespace Gobi.Test.Jr.Infra.Repositories
{
    public class TodoItemRepository : RepositoryGeneric<TodoItem>, ITodoItemRepository
    {      
        private readonly Microsoft.EntityFrameworkCore.DbSet<TodoItem> _todoItems;
        private readonly Context _context;
        public TodoItemRepository(Context context) : base(context) 
        {
            _context = context;
           _todoItems = _context.Set<TodoItem>();
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {

            var result = _todoItems.ToList();
            return result;

        }

       
    }
}
