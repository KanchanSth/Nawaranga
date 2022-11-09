using Nawaranga.Data.Base;
using Nawaranga.Models;

namespace Nawaranga.Data.Services
{
    public class StaffsService : EntityBaseRepository<Staff>, IStaffsService
    {
        public StaffsService(AppDbContext context): base(context)
        {
                
        }
    }
}
