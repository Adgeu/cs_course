using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Reminder.WebApi
{
	using Storage;
	using Storage.Exceptions;
	using Storage.Memory;

	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSingleton<IReminderStorage, ReminderStorage>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
		{
			if (environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.Use(ReminderExceptionHandling);
			app.UseRouting();
			app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
		}

		private static async Task ReminderExceptionHandling(HttpContext context, Func<Task> next)
		{
			try
			{
				await next();
			}
			catch (ReminderItemNotFoundException)
			{
				context.Response.StatusCode = 404;
			}
			catch (ReminderItemAlreadyExistsException)
			{
				context.Response.StatusCode = 409;
			}
		}
	}
}