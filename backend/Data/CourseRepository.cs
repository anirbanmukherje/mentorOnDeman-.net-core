using MentorOnDemand.Dtos;
using MentorOnDemand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorOnDemand.Data
{
    public class CourseRepository : IRepository
    {
        MentorOnDemandContext context;
        public CourseRepository(MentorOnDemandContext context)
        {
            this.context = context;
        }

        public bool AddCourses(Course course)
        {
            try
            {
                context.Courses.Add(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        

        public bool DeleteCourse(Course course)
        {
            try
            {
                context.Courses.Remove(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public Course GetCourse(int id)
        {
            return context.Courses.Find(id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return this.context.Courses.ToList();
        }

        

        public List<Course> SearchCourse(string criteria)
        {
            var result = from c in context.Courses
                         where c.Name.Contains(criteria) || c.Id == Convert.ToInt32(criteria)
                         select c;

            return result.ToList();
        }

        public bool UpdateCourse(Course course)
        {
            try
            {
                context.Courses.Update(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public IEnumerable<UserDto> GetMentorsList()
        {
            var mentor = from a in context.MODUsers
                         join ma in context.UserRoles on a.Id equals ma.UserId
                         where ma.RoleId == "2"
                         select new UserDto
                         {
                             id = a.Id,

                             Experience = a.Experience,
                             Firstname = a.FirstName,
                             Lastname = a.LastName,
                             Skill = a.Skill,
                             Email = a.Email,
                             Active = a.Active

                         };
            return mentor;
        }
        public IEnumerable<UserDto> GetStudentsList()
        {
            var student = from a in context.MODUsers
                          join ma in context.UserRoles on a.Id equals ma.UserId
                          where ma.RoleId == "3"
                          select new UserDto
                          {
                              id = a.Id,


                              Firstname = a.FirstName,
                              Lastname = a.LastName,
                              Email = a.Email,
                              PhoneNumber = a.PhoneNumber,
                              Active = a.Active


                          };
            return student;
        }
        public bool BlockUser(string id)
        {
            {
                var userblock = context.MODUsers.SingleOrDefault(u => u.Id == id);
                userblock.Active = !userblock.Active;
            }
            var result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public UserDto mentorProfileDetails(string email)
        {
            var result = from a in context.MODUsers
                         where a.Email == email
                         select new UserDto
                         {
                             id = a.Id,
                             Experience = a.Experience,
                             Firstname = a.FirstName,
                             Lastname = a.LastName,
                             Skill = a.Skill,
                             Email = a.Email,
                             PhoneNumber = a.PhoneNumber

                         };
            return result.SingleOrDefault();
        }
        public bool UpdateMentorDetails(ProfileDto ModUser, string mentorId)
        {
            try
            {
                var user = (from a in context.MODUsers
                            where a.Id == mentorId
                            select a).SingleOrDefault();
                if (user != null)
                {
                    user.Id = ModUser.id;
                    user.Email = ModUser.Email;
                    user.FirstName = ModUser.FirstName;
                    user.LastName = ModUser.LastName;
                    user.PhoneNumber = ModUser.PhoneNumber;
                    user.Skill = ModUser.Skill;
                    user.Experience = ModUser.Experience;

                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                return false;
            }
        }

        public UserDto studentProfileDetails(string email)
        {
            var result = from a in context.MODUsers
                         where a.Email == email
                         select new UserDto
                         {
                             id = a.Id,

                             Firstname = a.FirstName,
                             Lastname = a.LastName,
                             Skill = a.Skill,
                             Email = a.Email,
                             PhoneNumber = a.PhoneNumber

                         };
            return result.SingleOrDefault();
        }

        public bool UpdateStudentDetails(ProfileDto ModUser, string studentId)
        {
            try
            {
                var user = (from a in context.MODUsers
                            where a.Id == studentId
                            select a).SingleOrDefault();
                if (user != null)
                {
                    user.Id = ModUser.id;
                    user.Email = ModUser.Email;
                    user.FirstName = ModUser.FirstName;
                    user.LastName = ModUser.LastName;
                    user.PhoneNumber = ModUser.PhoneNumber;
                    user.Skill = ModUser.Skill;
                    user.Experience = ModUser.Experience;

                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                return false;
            }
            throw new NotImplementedException();
        }



        public bool ChangeCourseStatus(EnrolledCourse enrolledCourse, string UserEmail)
        {
            try
            {
                if (UserEmail == enrolledCourse.MentorEmail)
                {
                    if (enrolledCourse.Status == "Requested")
                    {
                        enrolledCourse.Status = "Request Accepted";
                    }
                    else if (enrolledCourse.Status == "In Progress")
                    {
                        enrolledCourse.Status = "Completed";
                    }
                    context.EnrolledCourses.Update(enrolledCourse);
                    int result = context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                else if (UserEmail == enrolledCourse.StudentEmail && enrolledCourse.Status == "Request Accepted")
                {
                    enrolledCourse.Status = "In Progress";
                    context.EnrolledCourses.Update(enrolledCourse);
                    int result = context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<EnrolledCourse> GetEnrolledCoursesByMentor(string modelEmail)
        {
            var result = from c in context.EnrolledCourses
                         where c.MentorEmail == modelEmail
                         select c;
            return result.ToList();
        }

        public List<EnrolledCourse> GetEnrolledCoursesByStudent(string modelEmail)
        {
            var result = from c in context.EnrolledCourses
                         where c.StudentEmail == modelEmail
                         select c;
            return result.ToList();
        }
        public IEnumerable<EnrolledCourse> GetEnrolledCourses()
        {

            return this.context.EnrolledCourses.ToList();
        }

        public bool AddEnrolledCourses(EnrolledCourse enrolledCourse)
        {
            try
            {
                var result1 = from c in context.EnrolledCourses
                              where c.StudentEmail == enrolledCourse.StudentEmail
                                    && c.Name == enrolledCourse.Name
                              select c;
                if (result1.Count() == 0)
                {
                    context.EnrolledCourses.Add(enrolledCourse);
                    int result = context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}




