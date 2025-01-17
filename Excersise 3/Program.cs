using Microsoft.EntityFrameworkCore;

namespace Excersise_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Thêm DbContext vào DI container và sử dụng cơ sở dữ liệu trong bộ nhớ
            builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            var app = builder.Build();

            // Endpoint để lấy danh sách tất cả các mục Todo
            app.MapGet("/todoitems", async (TodoDb db) =>
                await db.Todos.ToListAsync());

            // Endpoint để lấy danh sách các mục Todo đã hoàn thành
            app.MapGet("/todoitems/complete", async (TodoDb db) =>
                await db.Todos.Where(t => t.IsComplete).ToListAsync());

            // Endpoint để lấy một mục Todo theo ID
            app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
                await db.Todos.FindAsync(id)
                    is Todo todo
                        ? Results.Ok(todo)
                        : Results.NotFound());

            // Endpoint để thêm một mục Todo mới
            app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
            {
                db.Todos.Add(todo);
                await db.SaveChangesAsync();

                return Results.Created($"/todoitems/{todo.Id}", todo);
            });

            // Endpoint để cập nhật một mục Todo theo ID
            app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            {
                var todo = await db.Todos.FindAsync(id);

                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            // Endpoint để xóa một mục Todo theo ID
            app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            // Khởi chạy ứng dụng
            app.Run();

        }
    }
}
