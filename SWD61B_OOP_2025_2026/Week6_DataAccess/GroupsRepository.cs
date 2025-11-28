using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class GroupsRepository
    {
        //abstraction of the database
        private AttendanceDbContext _context;
        public GroupsRepository(AttendanceDbContext db) {
            _context = db;
        }

        public IQueryable<Group> Get()
        {

            return _context.Groups;
        }

        public Group Get(int id)
        { 
            return Get().SingleOrDefault(x=>x.Id == id);
        }

         
    }
}
