using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam1
{
    public class FinalExam : Exam
    {
        public FinalExam(
            int time,
            int numberOfQuestions,
            Question[] questions)
            : base(time, numberOfQuestions, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("===== Final Exam =====");

            foreach (Question question in Questions)
            {
                Console.WriteLine(question);

                foreach (Answer answer in question.Answers)
                {
                    Console.WriteLine(answer);
                }

                Console.WriteLine(
                    $"Right Answer: {question.RightAnswer}");

                Console.WriteLine();
            }

            Console.WriteLine("Grade: ...");
        }
    }
}
