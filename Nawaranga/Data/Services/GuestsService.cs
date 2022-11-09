using Nawaranga.Data.Base;
using Nawaranga.Models;

namespace Nawaranga.Data.Services
{
    public class GuestsService : EntityBaseRepository<Guest>, IGuestsService
    {
        public GuestsService(AppDbContext context): base(context)
        {

        }
    }
}
