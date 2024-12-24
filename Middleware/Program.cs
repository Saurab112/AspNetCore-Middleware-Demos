using Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();


//middlware 1
app.Use(async (context, next) =>
{
	await context.Response.WriteAsync("Hello");
	await next(context);
});

app.UseMiddleware<MyCustomMiddleware>();

//middleware 2
app.Use(async (context, next) =>
{
	await context.Response.WriteAsync("Hello again");
	await next(context);
});

//middleware 3  - terminal middleware
app.Run(async (HttpContext context) =>
{
	await context.Response.WriteAsync("Hello again");
});
app.Run();

