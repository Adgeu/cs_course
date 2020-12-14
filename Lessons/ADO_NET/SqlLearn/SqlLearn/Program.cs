using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SqlLearn
{
    partial class Program
    {
        public class Order
        {
            public int Id { get; }
            public string Customer { get; }
            public DateTimeOffset OrderDate { get; }
            public double Discount { get; }

            public Order(int id, string customer, DateTimeOffset orderDate, double discount)
            {
                Id = id;
                Customer = customer;
                OrderDate = orderDate;
                Discount = discount;
            }

            public override string ToString()
            {
                return $"Id: {Id}, Customer: {Customer}, OrderDate: {OrderDate}, Discount: {Discount}";
            }
        }

        public class InsertOrderCommand
        {
            public int CusomerId { get; set; }
            public DateTimeOffset OrderDate { get; set; }
            public double? Discount { get; set; }
            public List<(int productId, int count)> Lines { get; set; }

            public InsertOrderCommand(int cusomerId, double? discount = default)
            {
                CusomerId = cusomerId;
                Discount = discount;
                OrderDate = DateTimeOffset.UtcNow;
                Lines = new List<(int productId, int count)>();
            }
        }

        public interface IOrderRepository
        {
            Task<int> GetCountAsync();
            Task<Order> GetByIdAsync(int id);
            Task<List<Order>> GetAllAsync();
            Task<int> InsertAsync(InsertOrderCommand dto);
        }

        public class OrderRepository : IOrderRepository
        {
            private readonly string _connection;

            public OrderRepository(string connection)
            {
                _connection = connection;
            }

            public async Task<List<Order>> GetAllAsync()
            {
                await using var connection = await GetConnection();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT O.Id, C.Name, O.OrderDate, O.Discount FROM [Order] AS O JOIN [Customer] AS C ON C.Id = O.CustomerId";

                await using var reader = await command.ExecuteReaderAsync();

                

                var orders = new List<Order>();

                if (!reader.HasRows)
                    return orders;

                var idIndex = reader.GetOrdinal("Id");
                var customerIndex = reader.GetOrdinal("Name");
                var orderDateIndex = reader.GetOrdinal("OrderDate");
                var discountIndex = reader.GetOrdinal("Discount");

                while (await reader.ReadAsync())
                {
                    var order = new Order(
                        reader.GetInt32(idIndex),
                        reader.GetString(customerIndex),
                        reader.GetDateTimeOffset(orderDateIndex),
                        reader.GetDouble(discountIndex)
                    );
                    orders.Add(order);
                }

                return orders;
            }

            public async Task<Order> GetByIdAsync(int id)
            {
                await using var connection = await GetConnection();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT O.Id, C.Name, O.OrderDate, O.Discount FROM [Order] AS O JOIN [Customer] AS C ON C.Id = O.CustomerId WHERE O.Id=@id";
                command.Parameters.AddWithValue("id", id);

                await using var reader = await command.ExecuteReaderAsync();

                if (!reader.HasRows)
                    throw new ArgumentException($"Order with id {id} not found");

                var idIndex = reader.GetOrdinal("Id");
                var customerIndex = reader.GetOrdinal("Name");
                var orderDateIndex = reader.GetOrdinal("OrderDate");
                var discountIndex = reader.GetOrdinal("Discount");

                await reader.ReadAsync();

                var order = new Order(
                    reader.GetInt32(idIndex),
                    reader.GetString(customerIndex),
                    reader.GetDateTimeOffset(orderDateIndex),
                    reader.GetDouble(discountIndex)
                );
                return order;
            }

            public async Task<int> GetCountAsync()
            {
                await using var connection = await GetConnection();
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT COUNT(*) FROM [Order]";

                return (int)command.ExecuteScalar();
            }

            public async Task<int> InsertAsync(InsertOrderCommand dto)
            {/*
                await using var connection = await GetConnection();
                await using var transaction = (SqlTransaction) await connection.BeginTransactionAsync(IsolationLevel.ReadCommitted);

                var command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;


                command.CommandText = "InsertProduct";
                command.Parameters.AddWithValue("p_name", dto.Name);
                command.Parameters.AddWithValue("p_price", dto.Price);


                var parameter = command.Parameters.Add("p_id", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;

                await command.ExecuteNonQueryAsync();
                
                return (int)parameter.Value;*/
                return 0;
            }

            private async Task<SqlConnection> GetConnection()
            {
                var connection = new SqlConnection(_connection);
                await connection.OpenAsync();
                return connection;
            }
        }

        private const string ConnectionString =
            "Server=tcp:shadow-art.database.windows.net,1433;" +
            "Initial Catalog=reminder;" +
            "Persist Security Info=False;" +
            "User ID=a_faradjaev@shadow-art;" +
            "Password=5NL8x7wga6qS8RdbQAX8;" +
            "Encrypt=True;";

        static async Task Main(string[] args)
        {
            var or = new OrderRepository(ConnectionString);
            Console.WriteLine(await or.GetCountAsync());

            Console.WriteLine();
            
            foreach (var order in await or.GetAllAsync())
            {
                Console.WriteLine(order);
            }
            /*
            var command = new InsertOrderCommand(3)
            {
                Lines = { (1, 3), (2, 5) }
            };
            var id = await or.InsertAsync(command);*/
        }
    }
}
