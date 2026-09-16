namespace OOPExam1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ============================
            // Choose Exam Type
            // ============================

            Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final):");
            int examType = int.Parse(Console.ReadLine());

            while (examType != 1 && examType != 2)
            {
                Console.WriteLine("Please enter 1 for Practical or 2 for Final:");
                examType = int.Parse(Console.ReadLine());
            }


            // ============================
            // Enter Exam Time
            // ============================

            Console.WriteLine("Please enter the time for the exam (30 to 180 minutes):");
            int time = int.Parse(Console.ReadLine());

            while (time < 30 || time > 180)
            {
                Console.WriteLine("Please enter a valid time (30 to 180 minutes):");
                time = int.Parse(Console.ReadLine());
            }


            // ============================
            // Number Of Questions
            // ============================

            Console.WriteLine("Please enter the number of questions:");
            int numberOfQuestions = int.Parse(Console.ReadLine());

            Question[] questions = new Question[numberOfQuestions];


            // ============================
            // Create Questions
            // ============================

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Question {i + 1}");

                // Question Body
                Console.WriteLine("Please enter the question body:");
                string body = Console.ReadLine();

                // Question Mark
                Console.WriteLine("Please enter the question mark:");
                int mark = int.Parse(Console.ReadLine());


                // ====================================
                // Practical Exam -> MCQ Only
                // Final Exam -> T/F or MCQ
                // ====================================

                int questionType = 2; // Default = MCQ

                if (examType == 2)
                {
                    Console.WriteLine("Choose Question Type:");
                    Console.WriteLine("1. True / False");
                    Console.WriteLine("2. MCQ");

                    questionType = int.Parse(Console.ReadLine());

                    while (questionType != 1 && questionType != 2)
                    {
                        Console.WriteLine("Please choose 1 or 2:");
                        questionType = int.Parse(Console.ReadLine());
                    }
                }


                // ============================
                // True / False Question
                // ============================

                if (questionType == 1)
                {
                    Answer trueAnswer = new Answer(1, "True");
                    Answer falseAnswer = new Answer(2, "False");

                    Answer[] answers =
                    {
                        trueAnswer,
                        falseAnswer
                    };

                    Console.WriteLine(
                        "Please enter the right answer (1 for True, 2 for False):"
                    );

                    int rightAnswerNumber = int.Parse(Console.ReadLine());

                    while (rightAnswerNumber != 1 &&
                           rightAnswerNumber != 2)
                    {
                        Console.WriteLine(
                            "Please enter 1 for True or 2 for False:"
                        );

                        rightAnswerNumber = int.Parse(Console.ReadLine());
                    }

                    Answer rightAnswer =
                        answers[rightAnswerNumber - 1];

                    questions[i] = new TrueFalseQuestion(
                        $"Question {i + 1}",
                        body,
                        mark,
                        answers,
                        rightAnswer
                    );
                }


                // ============================
                // MCQ Question
                // ============================

                else
                {
                    Console.WriteLine("Please enter number of choices:");
                    int numberOfChoices = int.Parse(Console.ReadLine());

                    while (numberOfChoices < 2)
                    {
                        Console.WriteLine(
                            "Please enter at least 2 choices:"
                        );

                        numberOfChoices = int.Parse(Console.ReadLine());
                    }

                    Answer[] answers =
                        new Answer[numberOfChoices];


                    for (int j = 0; j < numberOfChoices; j++)
                    {
                        Console.WriteLine(
                            $"Please enter choice number {j + 1}:"
                        );

                        string answerText =
                            Console.ReadLine();

                        answers[j] = new Answer(
                            j + 1,
                            answerText
                        );
                    }


                    Console.WriteLine(
                        "Please enter the right answer number:"
                    );

                    int rightAnswerNumber =
                        int.Parse(Console.ReadLine());

                    while (rightAnswerNumber < 1 ||
                           rightAnswerNumber > numberOfChoices)
                    {
                        Console.WriteLine(
                            "Please enter a valid answer number:"
                        );

                        rightAnswerNumber =
                            int.Parse(Console.ReadLine());
                    }

                    Answer rightAnswer =
                        answers[rightAnswerNumber - 1];


                    questions[i] = new MCQQuestion(
                        $"Question {i + 1}",
                        body,
                        mark,
                        answers,
                        rightAnswer
                    );
                }
            }


            // ============================
            // Create Exam
            // ============================

            Exam exam;

            if (examType == 1)
            {
                exam = new PracticalExam(
                    time,
                    numberOfQuestions,
                    questions
                );
            }
            else
            {
                exam = new FinalExam(
                    time,
                    numberOfQuestions,
                    questions
                );
            }


            // ============================
            // Create Subject
            // ============================

            Subject subject = new Subject(
                1,
                "OOP"
            );

            subject.CreateExam(exam);


            // ============================
            // Start Exam
            // ============================

            Console.WriteLine();
            Console.WriteLine("Do You Want To Start Exam (Y | N)");

            char choice = char.Parse(
                Console.ReadLine()
            );

            if (choice == 'Y' || choice == 'y')
            {
                Console.Clear();

                int grade = 0;


                // ============================
                // Answer Questions
                // ============================

                for (int i = 0;
                     i < subject.Exam.Questions.Length;
                     i++)
                {
                    Question question =
                        subject.Exam.Questions[i];

                    Console.WriteLine(
                        $"Question {i + 1}: {question.Body}"
                    );

                    Console.WriteLine(
                        $"Mark: {question.Mark}"
                    );

                    Console.WriteLine("Choices:");

                    for (int j = 0;
                         j < question.Answers.Length;
                         j++)
                    {
                        Console.WriteLine(
                            $"{question.Answers[j].AnswerId}. " +
                            $"{question.Answers[j].AnswerText}"
                        );
                    }


                    // User chooses answer
                    Console.Write(
                        "Please choose your answer: "
                    );

                    int answerNumber =
                        int.Parse(Console.ReadLine());


                    // Check answer
                    if (answerNumber ==
                        question.RightAnswer.AnswerId)
                    {
                        grade += question.Mark;
                    }

                    Console.WriteLine();
                }


                // ============================
                // Exam Result
                // ============================

                Console.WriteLine("==============================");
                Console.WriteLine("Exam Finished!");
                Console.WriteLine($"Your Grade = {grade}");
                Console.WriteLine("==============================");


                // ============================
                // Practical Exam
                // Show Right Answers
                // ============================

                if (examType == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Right Answers:");

                    for (int i = 0;
                         i < subject.Exam.Questions.Length;
                         i++)
                    {
                        Question question =
                            subject.Exam.Questions[i];

                        Console.WriteLine(
                            $"Question {i + 1}: " +
                            $"{question.RightAnswer.AnswerText}"
                        );
                    }
                }
            }
            else
            {
                Console.WriteLine("Exam Cancelled.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}