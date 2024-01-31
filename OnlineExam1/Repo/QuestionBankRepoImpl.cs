using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineExam1.DTO;
using OnlineExam1.Entity;

namespace OnlineExam1.Repo
{
    public class QuestionBankRepoImpl : IRepo<QuestionBankDTO>
    {
        private readonly MyContext context;

        public QuestionBankRepoImpl(MyContext ctx)
        {
            context = ctx;
        }

        public bool Add(QuestionBankDTO item)
        {
            QuestionBank question = new QuestionBank
            {
                SubjectID = item.SubjectID,
                QuestionText = item.QuestionText,
                Answer = item.Answer,
                Option1 = item.option1,
                Option2 = item.option2,
                Option3 = item.option3,
                Option4 = item.option4
            };

            context.QuestionBanks.Add(question);
            context.SaveChanges();
            return true;
        }

        public List<QuestionBankDTO> GetAll()
        {
            var result = context.QuestionBanks
                .Select(q => new QuestionBankDTO
                {
                    QuestionID = q.QuestionID,
                    SubjectID = q.SubjectID,
                    QuestionText = q.QuestionText,
                    Answer = q.Answer,
                    option1 = q.Option1,
                    option2 = q.Option2,
                    option3 = q.Option3,
                    option4 = q.Option4
                })
                .ToList();

            return result;
        }

        public QuestionBankDTO GetById(int questionId)
        {
            var question = context.QuestionBanks
                .Include(q => q.Subject) // Include related Subject data if needed
                .FirstOrDefault(q => q.QuestionID == questionId);

            if (question == null)
            {
                return null;
            }

            return new QuestionBankDTO
            {
                QuestionID = question.QuestionID,
                SubjectID = question.SubjectID,
                QuestionText = question.QuestionText,
                Answer = question.Answer,
                option1 = question.Option1,
                option2 = question.Option2,
                option3 = question.Option3,
                option4 = question.Option4
            };
        }

        public bool Update(int questionId, QuestionBankDTO updatedItem)
        {
            var question = context.QuestionBanks.Find(questionId);

            if (question == null)
            {
                return false; // Question not found
            }

            question.SubjectID = updatedItem.SubjectID;
            question.QuestionText = updatedItem.QuestionText;
            question.Answer = updatedItem.Answer;
            question.Option1 = updatedItem.option1;
            question.Option2 = updatedItem.option2;
            question.Option3 = updatedItem.option3;
            question.Option4 = updatedItem.option4;

            context.SaveChanges();
            return true;
        }

        public bool Delete(int questionId)
        {
            var question = context.QuestionBanks.Find(questionId);

            if (question == null)
            {
                return false; // Question not found
            }

            context.QuestionBanks.Remove(question);
            context.SaveChanges();
            return true;
        }

        public List<QuestionBankDTO> GetBySubjectID(int subjectId)
        {
            var result = context.QuestionBanks
                .Where(q => q.SubjectID == subjectId)
                .Select(q => new QuestionBankDTO
                {
                    QuestionID = q.QuestionID,
                    SubjectID = q.SubjectID,
                    QuestionText = q.QuestionText,
                    Answer = q.Answer,
                    option1 = q.Option1,
                    option2 = q.Option2,
                    option3 = q.Option3,
                    option4 = q.Option4
                })
                .ToList();

            return result;
        }

        public List<QuestionBankDTO> GetByQuestion(string questionText)
        {
            var result = context.QuestionBanks
                .Where(q => q.QuestionText.Contains(questionText))
                .Select(q => new QuestionBankDTO
                {
                    QuestionID = q.QuestionID,
                    SubjectID = q.SubjectID,
                    QuestionText = q.QuestionText,
                    Answer = q.Answer,
                    option1 = q.Option1,
                    option2 = q.Option2,
                    option3 = q.Option3,
                    option4 = q.Option4
                })
                .ToList();

            return result;
        }
    }
}