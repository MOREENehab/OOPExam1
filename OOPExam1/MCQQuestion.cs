using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam1
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(
            string header,
            string body,
            int mark,
            Answer[] answers,
            Answer rightAnswer)
            : base(header, body, mark, answers, rightAnswer)
        {
        }
    }
}
