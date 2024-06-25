using Microsoft.EntityFrameworkCore;
using NominaAPI.Data;
using SharedModels;
using System.Linq.Expressions;

namespace NominaAPI.Repository
{
    public class NominaRepository: Repository<Nomina>
    {
        private readonly NominaContext _context;
        readonly DbSet<Nomina> _nominas;

        public NominaRepository(NominaContext context) : base(context)
        {
            _context = context;
            _nominas = _context.Set<Nomina>();
        }

        public async Task<List<Nomina>> GetPopulatedNominas(Expression<Func<Nomina, bool>>? filter = null)
        {
            IQueryable<Nomina> query = _nominas;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query
                .Include(n => n.Ingresos)
                .Include(n => n.Deducciones)
                .Include(n => n.Empleado)
                .ToListAsync();
        }
    }
}
