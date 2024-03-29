﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam1.DTO;
using OnlineExam1.Entity;
using OnlineExam1.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace OnlineExam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestStructureController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly ILogger<TestStructureController> _logger;

        public TestStructureController(MyContext context, ILogger<TestStructureController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _logger = logger;
        }

        // GET: api/TestStructure/GetAll
        [HttpGet, Route("GetAll")]
        //[AllowAnonymous]
        public ActionResult<IEnumerable<TestStructureDTO>> GetTestStructures()
        {
            try
            {
                var testStructures = unitOfWork.TestStructureRepoImplObject.GetAll();
                return Ok(testStructures);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/TestStructure/GetById/5
        [HttpGet, Route("GetById/{id}")]
        //[AllowAnonymous]
        public ActionResult<TestStructureDTO> GetTestStructure(int id)
        {
            try
            {
                var testStructure = unitOfWork.TestStructureRepoImplObject.GetById(id);

                if (testStructure == null)
                {
                    return NotFound();
                }

                return Ok(testStructure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/TestStructure/Add
        [HttpPost, Route("Add")]
        //[Authorize(Roles = "Admin")] // Reinstated authorization attribute
        public ActionResult<TestStructureDTO> PostTestStructure(TestStructureDTO testStructureDTO)
        {
            try
            {
                if (testStructureDTO == null)
                {
                    return BadRequest("TestStructureDTO is null");
                }

                unitOfWork.TestStructureRepoImplObject.Add(testStructureDTO);
                unitOfWork.SaveAll();

                return CreatedAtAction(nameof(GetTestStructure), new { id = testStructureDTO.TestID }, testStructureDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a test structure");
                return StatusCode(500, "An error occurred while adding a test structure");
            }
        }

        // PUT: api/TestStructure/Update/5
        [HttpPut, Route("Update/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult PutTestStructure(int id, TestStructureDTO testStructureDTO)
        {
            try
            {
                if (id != testStructureDTO.TestID)
                {
                    return BadRequest();
                }

                bool success = unitOfWork.TestStructureRepoImplObject.Update(id, testStructureDTO);

                if (!success)
                {
                    return NotFound();
                }

                unitOfWork.SaveAll();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/TestStructure/Delete/5
        [HttpDelete, Route("Delete/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteTestStructure(int id)
        {
            try
            {
                bool success = unitOfWork.TestStructureRepoImplObject.Delete(id);

                if (!success)
                {
                    return NotFound();
                }

                unitOfWork.SaveAll();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
