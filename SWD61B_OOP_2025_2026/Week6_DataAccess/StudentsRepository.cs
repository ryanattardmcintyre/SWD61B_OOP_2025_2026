using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Common;

namespace Week6_DataAccess
{
    public class StudentsRepository
    {
        //this allows me to connect to the database
        //this is an abstraction of the database i.e. it represents the database
        private AttendanceDbContext _context;
        public StudentsRepository(AttendanceDbContext context) {
            _context = context; //assigning the parameter holding the object which
                                //represents the database into a field. Why?
                                //Reason: I need to make calls on that object from the CRUD methods
        }

        //CRUD

        //Read:
        //IQueryable: is used like a List but it doesn't hold the data but it holds a prepared SQL statement
        //            SQL is generated automatically and then executes the SQL when at one point you type
        //            .ToList()

        //IQueryable: is much more efficient than List!!!
        /// <summary>
        /// This method returns all the students
        /// </summary>
        /// <returns></returns>
        public IQueryable<Student> Get()
        {
            return _context.Students; //Students property represents the table Students from the database
        }

        /// <summary>
        /// This method returns a single instance of a student with the associated primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student Get(int id)
        {
            //LINQ-to-ENTITIES
            return Get().SingleOrDefault(s => s.Id == id);

            /*
             * var list = Get();
             * foreach (var s in list)
             * {
             *    if(s.Id == id) return s;
             * }
             */ 
        }

        public IQueryable<Student> GetByGroup(int groupId)
        {
            return Get().Where(x => x.GroupFK == groupId);
        }

        public IQueryable<Student> GetByGroup(string groupName)
        {
            //Group property inside Student class was not created in the database
            //That was created automatically by the Entity Data Model because we had relationships
            //So an advantage of the Entity Data Model, is that it creates these so-called 
            //Navigational properties

            //Select Students.*, Group.Id, Group.Name
            //From Students inner join Groups
            //on Students.GroupFK equals Groups.Id
            //Where Group.Name = ''

            return Get().Where(x => x.Group.Name == groupName);
        }

        public IQueryable<Student> Get(string keyword) 
        {
            //lambda expression  
            //Select * From Students where Name Like '%@keyword%'

            return Get()
                .Where(x => x.Name.StartsWith(keyword) || x.Surname.StartsWith(keyword))
                .OrderBy(x=>x.Name)
                .OrderBy(x=>x.Surname); 
        }


        public bool Add(Student s)
        {
            if (Get().SingleOrDefault(x=>x.IdCardNo == s.IdCardNo) == null)
            {
                _context.Students.Add(s); //adds Student s into the abstraction of the database
                _context.SaveChanges(); //persists the data into the storage layer i.e. db
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Student s)
        {
            if (Get().SingleOrDefault(x => x.IdCardNo == s.IdCardNo) == null)
            {
                return false;
            }
            else
            {
                var originalStudent = Get().SingleOrDefault(x => x.IdCardNo == s.IdCardNo);
                if (originalStudent != null)
                {
                    originalStudent.Surname = s.Surname;
                    originalStudent.Name = s.Name;
                    originalStudent.Email = s.Email;
                    originalStudent.GroupFK = s.GroupFK;

                    _context.SaveChanges(); //WITHOUT this line changes won't be saved permanently!!!
                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            var studentToDelete = Get().SingleOrDefault(x => x.Id == id);
            if(studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete); //removes the student from memory
                //to persist the change - the student deletion - we need to commit
                _context.SaveChanges();
                return true;
            }


            return false;

        }

    }
}
