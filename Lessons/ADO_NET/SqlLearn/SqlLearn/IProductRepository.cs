using System.Threading.Tasks;

namespace SqlLearn
{
    partial class Program
    {
        public interface IProductRepository
        {
            Task<int> GetCountAsync();
            Task<Product> GetByIdAsync(int id);
            Task<Product[]> GetAllAsync();
            Task<int> InsertAsync(InsertProductCommand dto);
        }
    }
}
