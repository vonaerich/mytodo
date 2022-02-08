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
  if(todo == null)
  {
    return Results.BadRequest();
  }

  var nextId = todos.LastOrDefault()?.Id + 1 ?? 1;
  todo.Id = nextId;
  todos.Add(todo);

  return Results.NoContent();
});

app.Run("http://0.0.0.0:5001");