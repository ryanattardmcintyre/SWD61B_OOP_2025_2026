using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;
using Week6_DataAccess;

namespace Week6_Services
{
    public class StudentsServices
    {
        private StudentsRepository _studentsRepo;
        public StudentsServices(StudentsRepository studentsRepo) 
        {
            _studentsRepo = studentsRepo;
        }

        public IQueryable<Student> List()
        {
            return _studentsRepo.Get();
        }

        public IQueryable<Student> List(string keyword="", int columnIndexToSortWith = 0, bool ascending=true)
        {
            var list = _studentsRepo.Get();
            if (keyword == "") return list;

            switch (columnIndexToSortWith)
            {
                case 0:
                    list = list.Where(s => s.Name.StartsWith(keyword) || s.Surname.StartsWith(keyword))
                    .OrderBy(s => s.Name);

                    if (!ascending)
                        list = list.OrderByDescending(x => x.Name);
                    break;

                case 1:
                    list = list.Where(s => s.Name.StartsWith(keyword) || s.Surname.StartsWith(keyword))
                        .OrderBy(s => s.Surname);

                    if (!ascending)
                        list = list.OrderByDescending(x => x.Surname);
                    break;
            }
            return list;
        }

        public IQueryable<Student> ListByGroup(int groupId, string groupName)
        {
            return _studentsRepo.Get().Where(s => s.GroupFK == groupId || s.Group.Name.Contains(groupName));
        }

        
    }
}
