using Microsoft.EntityFrameworkCore;

namespace EventEase.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContext<DataContext> options) : base(options)
        {

        }
    }
}
