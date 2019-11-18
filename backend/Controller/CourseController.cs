using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorOnDemand.Data;
using MentorOnDemand.Dtos;
using MentorOnDemand.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentorOnDemand.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        IRepository repository;
        public CourseController(IRepository repository)
        {
            this.repository = repository;
        }
        
        // GET: api/Course
        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(repository.GetCourses());
        }

       
        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.AddCourses(course);
                if (result)
                {
                    return Created("AddCourse", course);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Course course)
        {
            if (ModelState.IsValid && id == course.Id)
            {
                bool result = repository.UpdateCourse(course);
                if (result)
                {
                    return Created("UpdatedCourse", course.Id);
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = repository.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            bool result = repository.DeleteCourse(course);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("search/{criteria}")]
        public IActionResult SearchCourse(string criteria)
        {
            var result = repository.SearchCourse(criteria);
            return Ok(result);
        }


      

        [HttpGet("mentorsList")]
        public IActionResult GetMentorsList()
        {
            return Ok(repository.GetMentorsList());
        }

        [HttpGet("studentsList")]
        public IActionResult GetStudentsList()
        {
            return Ok(repository.GetStudentsList());
        }

        [HttpGet("blockunblock/{id}")]
        public IActionResult GetBlockUnblock(string id)
        {
            var result =repository.BlockUser(id);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpGet("mentorProfile/{email}")]
        public IActionResult mentorProfileDetails(string email)
        {
            var result = repository.mentorProfileDetails(email);
            return Ok(result);
        }

        [HttpPut("mentorProfile/{mentorId}")]
        public IActionResult UpdateMentorDetails(string mentorId, [FromBody] ProfileDto mentorData)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.UpdateMentorDetails(mentorData, mentorId);
                if (result)
                {
                    return Created("UpdatedCourse", null);
                }
            }
            return BadRequest(ModelState);
        }



    }
}
