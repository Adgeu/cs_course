using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Reminder.Storage.WebApi
{
	using Exceptions;
	using Dto;
    using System.Collections.Generic;
    using System.Linq;

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
			var json = JsonSerializer.Serialize(item, SerializerOptions);
			var content = new StringContent(json, Encoding.Unicode, "application/json");
			var message = _client.PutAsync($"{ApiPrefix}/{item.Id:N}", content)
				.GetAwaiter()
				.GetResult();

			if (message.StatusCode == HttpStatusCode.NotFound)
			{
				throw new ReminderItemNotFoundException(item.Id);
			}

			message.EnsureSuccessStatusCode();
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

			return dto.ReminderItem;
		}

		public ReminderItem[] Find(ReminderItemFilter filter)
		{
			var url = ApiPrefix;

			if (filter.HasFilter)
            {
				url += "?";

				if (filter.DateTime.HasValue)
					url += $"datetime={filter.DateTime.Value.ToUnixTimeMilliseconds()}&";

				if (filter.Status.HasValue)
					url += $"status={filter.Status.Value}&";

				url.Remove(url.Length - 1, 1);
			}		

			var message =  _client.GetAsync(url)
				.GetAwaiter()
				.GetResult();

			var json = message.Content.ReadAsStringAsync()
				.GetAwaiter()
				.GetResult();

			var dtos = JsonSerializer.Deserialize<List<ReminderItemDto>>(json, SerializerOptions);

			return dtos.Select(dto => dto.ReminderItem).ToArray();
		}
	}
}