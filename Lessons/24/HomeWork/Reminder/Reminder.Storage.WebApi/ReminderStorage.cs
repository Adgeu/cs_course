using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Reminder.Storage.WebApi
{
	using Exceptions;
	using Dto;

	public class ReminderStorage : IReminderStorage
	{
		private const string ApiPrefix = "/api/reminders";

		private static readonly JsonSerializerOptions SerializerOptions =
			new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

		private readonly HttpClient _client;

		public ReminderStorage(string endpoint)
		{
			_client = new HttpClient
			{
				BaseAddress = new Uri(endpoint)
			};
		}

		public ReminderStorage(HttpClient client)
		{
			_client = client;
		}

		public void Add(ReminderItem item)
		{
			var json = JsonSerializer.Serialize(item, SerializerOptions);
			var content = new StringContent(json, Encoding.Unicode, "application/json");
			var message = _client.PostAsync(ApiPrefix, content)
				.GetAwaiter()
				.GetResult();

			if (message.StatusCode == HttpStatusCode.Conflict)
			{
				throw new ReminderItemAlreadyExistsException(item.Id);
			}

			message.EnsureSuccessStatusCode();
		}

		public void Update(ReminderItem item)
		{
			throw new NotImplementedException();
		}

		public ReminderItem Get(Guid id)
		{
			var message = _client.GetAsync($"{ApiPrefix}/{id:N}")
				.GetAwaiter()
				.GetResult();

			if (message.StatusCode == HttpStatusCode.NotFound)
			{
				throw new ReminderItemNotFoundException(id);
			}

			message.EnsureSuccessStatusCode();

			var json = message.Content.ReadAsStringAsync()
				.GetAwaiter()
				.GetResult();
			var dto = JsonSerializer.Deserialize<ReminderItemDto>(json, SerializerOptions);

			return new ReminderItem(
				dto.Id,
				dto.Status,
				dto.DateTime,
				dto.Message,
				dto.ContactId
			);
		}

		public ReminderItem[] Find(ReminderItemFilter filter)
		{
			throw new NotImplementedException();
		}
	}
}