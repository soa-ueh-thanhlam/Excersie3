using Microsoft.EntityFrameworkCore;

namespace Excersise_3
{
    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }

}
