using Microsoft.EntityFrameworkCore;
using Nawaranga.Data.Base;
using Nawaranga.Models;

namespace Nawaranga.Data.Services
{
    public class RoomsService : EntityBaseRepository<Room>, IRoomsService
    {
        public RoomsService(AppDbContext context): base(context)
        {
            
        }
       

       

       
    }
}
