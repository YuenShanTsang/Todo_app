using Microsoft.EntityFrameworkCore;
using Todo_app.Models;

namespace Todo_app.Data
{
    // DbContext Class
    public class TodoContext: DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options)
			: base(options)
		{}

		public DbSet<Todo> Todos => Set<Todo>();
	}
}

