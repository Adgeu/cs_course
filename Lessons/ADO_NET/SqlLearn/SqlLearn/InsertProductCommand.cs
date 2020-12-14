namespace SqlLearn
{
    partial class Program
    {
        public class InsertProductCommand
        {
            public string Name { get; }
            public decimal Price { get; }

            public InsertProductCommand(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }
    }
}
