var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.MapGet("/", () => "Api is online!");

var todos = new List<Todo> 
{
  new Todo { Id = 1, TodoItem = "Buy Eggs" }
};

app.MapGet("/todos", () => Results.Ok(todos));

app.MapPost("/todos", (Todo todo) => 
{
  todos.Add(todo);
  Results.NoContent();
});

app.Run("http://0.0.0.0:5001");