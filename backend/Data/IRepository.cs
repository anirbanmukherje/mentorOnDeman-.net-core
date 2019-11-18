using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorOnDemand.Dtos;
using MentorOnDemand.Models;

namespace MentorOnDemand.Data
{
   public interface IRepository
    {
        IEnumerable<Course> GetCourses();
        bool AddCourses(Course course);
        Course GetCourse(int id);
        List<Course> SearchCourse(string criteria);
        bool UpdateCourse(Course course);
        bool DeleteCourse(Course course);
        IEnumerable<EnrolledCourse> GetEnrolledCourses();
        bool AddEnrolledCourses(EnrolledCourse enrolledCourse);

        IEnumerable<UserDto> GetMentorsList();
        IEnumerable<UserDto> GetStudentsList();
        bool BlockUser(string id);
        UserDto mentorProfileDetails(string email);
        bool UpdateMentorDetails(ProfileDto modUser, string mentorId);

    }
}
