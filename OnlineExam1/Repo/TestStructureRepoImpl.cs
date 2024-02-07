using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineExam1.DTO;
using OnlineExam1.Entity;

namespace OnlineExam1.Repo
{
    public class TestStructureRepoImpl : IRepo<TestStructureDTO>
    {
        private readonly MyContext context;

        public TestStructureRepoImpl(MyContext ctx)
        {
            context = ctx;
        }

        public bool Add(TestStructureDTO item)
        {
            TestStructure testStructure = new TestStructure
            {
                SiteID = item.SiteID,
                SubjectID = item.SubjectID,
                TestName = item.TestName,
                NoOfQuestions = item.NoOfQuestions,
                TotalMarks = item.TotalMarks,
                Duration = item.Duration
            };

            context.TestStructures.Add(testStructure);
            context.SaveChanges();
            return true;
        }

        public List<TestStructureDTO> GetAll()
        {
            var result = context.TestStructures
                .Include(t => t.Subject) // Include related Subject data
                .Select(t => new TestStructureDTO
                {
                    TestID = t.TestID,
                    SiteID = t.SiteID,
                    SubjectID = t.SubjectID,
                    SubjectName = t.Subject.SubjectName, // Include SubjectName
                    TestName = t.TestName,
                    NoOfQuestions = t.NoOfQuestions,
                    TotalMarks = t.TotalMarks,
                    Duration = t.Duration
                })
                .ToList();

            return result;
        }

        public TestStructureDTO GetById(int testId)
        {
            var testStructure = context.TestStructures
                .Include(t => t.Subject) // Include related Subject data
                .FirstOrDefault(t => t.TestID == testId);

            if (testStructure == null)
            {
                return null;
            }

            return new TestStructureDTO
            {
                TestID = testStructure.TestID,
                SiteID = testStructure.SiteID,
                SubjectID = testStructure.SubjectID,
                SubjectName = testStructure.Subject.SubjectName, // Include SubjectName
                TestName = testStructure.TestName,
                NoOfQuestions = testStructure.NoOfQuestions,
                TotalMarks = testStructure.TotalMarks,
                Duration = testStructure.Duration
            };
        }

        public bool Update(int testId, TestStructureDTO updatedItem)
        {
            var testStructure = context.TestStructures.Find(testId);

            if (testStructure == null)
            {
                return false; // TestStructure not found
            }

            testStructure.SiteID = updatedItem.SiteID;
            testStructure.SubjectID = updatedItem.SubjectID;
            testStructure.TestName = updatedItem.TestName;
            testStructure.NoOfQuestions = updatedItem.NoOfQuestions;
            testStructure.TotalMarks = updatedItem.TotalMarks;
            testStructure.Duration = updatedItem.Duration;

            context.SaveChanges();
            return true;
        }

        public bool Delete(int testId)
        {
            var testStructure = context.TestStructures.Find(testId);

            if (testStructure == null)
            {
                return false; // TestStructure not found
            }

            context.TestStructures.Remove(testStructure);
            context.SaveChanges();
            return true;
        }
    }
}
