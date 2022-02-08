var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.MapGet("/", () => "Api is online!");

var todos = new List<Todo> 
{
  new Todo { Id = 1, TodoItem = "Buy Eggs" }
};

app.MapGet("/todos", () => Results.Ok(todos));

app.MapPost("/todos", (TodoRequest todo) => 
{
  if(todo == null)
  {
    return Results.BadRequest();
  }

  var nextId = todos.LastOrDefault()?.Id + 1 ?? 1;
  todos.Add(new Todo { Id = nextId, TodoItem = todo.TodoItem });

  return Results.NoContent();
});

app.MapDelete("/todos/{id}", (int id) => 
{
  var todo = todos.FirstOrDefault(a => a.Id == id);
  if(todo == null)
  {
    return Results.NotFound();
  }

  todos.Remove(todo);
  return Results.NoContent();
});

app.Run("http://0.0.0.0:5001");