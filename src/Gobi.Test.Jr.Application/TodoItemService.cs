using Gobi.Test.Jr.Domain;
using Gobi.Test.Jr.Domain.Interfaces;
using Gobi.Test.Jr.Domain.Interfaces.Services;

namespace Gobi.Test.Jr.Application
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public  Task Add(TodoItem item)
        {
           var result =  _todoItemRepository.Add(item);
            return  result;
        }

        public Task Delete(TodoItem item)
        {
            var result = _todoItemRepository.Delete(item);
            return result;  
        }


        public async Task<IEnumerable<TodoItem>> GetAll()
        {
           var result = await _todoItemRepository.GetAll();
            return result;
        }

        public Task<TodoItem> GetById(int id)
        {
          var result =  _todoItemRepository.GetById(id);
            return  result;
        }

        public  Task  Update(TodoItem item)
        {
           var result = _todoItemRepository.Update(item);
            return result;
        }
    }
}