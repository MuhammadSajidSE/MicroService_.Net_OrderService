using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderService.DataBase_Context;
using OrderService.Return_Data;

namespace OrderService.Common_Repository
{
    public class CommonRepoImplementation<Tentity, TDTO> : CommonRepoInterfac<Tentity, TDTO>
        where Tentity : class
        where TDTO : class
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private readonly DbSet<Tentity> entities;

        public CommonRepoImplementation(DatabaseContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
            entities = context.Set<Tentity>();
        }

        // ✅ Marked as async
        public async Task<CommonRetrun> AddOrder(TDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return new CommonRetrun
                    {
                        errormessage = "Data cannot be empty",
                        result = false
                    };
                }

                var data = mapper.Map<Tentity>(dto);
                await entities.AddAsync(data);
                await context.SaveChangesAsync();

                return new CommonRetrun
                {
                    Data = data,
                    result = true
                };
            }
            catch (Exception ex)
            {
                return new CommonRetrun
                {
                    errormessage = ex.Message,
                    result = false
                };
            }
        }

        // ✅ Marked as async
        public async Task<CommonRetrun> GetAllOrder()
        {
            try
            {
                var data = await entities.ToListAsync();
                var returndata = mapper.Map<List<TDTO>>(data);

                return new CommonRetrun
                {
                    result = true,
                    Data = returndata
                };
            }
            catch (Exception ex)
            {
                return new CommonRetrun
                {
                    errormessage = ex.Message,
                    result = false
                };
            }
        }
    }
}