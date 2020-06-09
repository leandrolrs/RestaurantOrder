using Microsoft.EntityFrameworkCore;

namespace RestaurantOrder.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<OrderHistory> OrderHistories { get; set; }
    }
}
