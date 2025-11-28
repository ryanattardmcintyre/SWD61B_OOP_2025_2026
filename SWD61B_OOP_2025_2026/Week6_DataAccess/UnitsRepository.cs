using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class UnitsRepository
    {
        private AttendanceDbContext _context;
        public UnitsRepository(AttendanceDbContext db)
        {
            _context = db;
        }

        public IQueryable<Unit> Get()
        {

            return _context.Units;
        }

        public Unit Get(string code)
        {
            return Get().SingleOrDefault(x => x.Code ==code);
        }
    }
}
