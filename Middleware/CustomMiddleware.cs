
namespace Middleware
{
	public class CustomMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			await context.Response.WriteAsync("This is a custom middleware");
			await next(context);
		}
	}
}
