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

        IEnumerable<UserDto> GetMentorsList();
        IEnumerable<UserDto> GetStudentsList();
        bool BlockUser(string id);
        UserDto mentorProfileDetails(string email);
        bool UpdateMentorDetails(ProfileDto modUser, string mentorId);
        UserDto studentProfileDetails(string email);
        bool UpdateStudentDetails(ProfileDto modUser, string studentId);
       
        List<EnrolledCourse> GetEnrolledCoursesByStudent(string modelEmail);
        List<EnrolledCourse> GetEnrolledCoursesByMentor(string modelEmail);
        bool ChangeCourseStatus(EnrolledCourse enrolledCourse, string UserEmail);
        IEnumerable<EnrolledCourse> GetEnrolledCourses();
        bool AddEnrolledCourses(EnrolledCourse enrolledCourse);





    }
}
