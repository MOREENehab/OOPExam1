using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam1
{
    public class PracticalExam : Exam
    {
        public PracticalExam(
            int time,
            int numberOfQuestions,
            Question[] questions)
            : base(time, numberOfQuestions, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("===== Practical Exam =====");

            foreach (Question question in Questions)
            {
                Console.WriteLine(question);

                Console.WriteLine(
                    $"Right Answer: {question.RightAnswer}");

                Console.WriteLine();
            }
        }
    }
}
