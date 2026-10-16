
using System;
using OOPs_Collections_TrainingManagementSystem.Models;
using OOPs_Collections_TrainingManagementSystem.Services;
using OOPs_Collections_TrainingManagementSystem.Sessions;

class Program
{
    static void Main()
    {
        // 1. Create course catalogue
        Course[] courses =
        {
            new Course("CN01", "Python", 1000m, 90, 30, 0),
            new Course("CN02", "EthicalHacking", 1500m, 85, 25, 12),
            new Course("CN03", "CCNA", 2000m, 100, 45, 0),
            new Course("CN04", "Java", 750m, 85, 32, 0),
            new Course("CN05", "C#", 800m, 70, 40, 0)
        };

        // 2. Create services
        LearnerService learnerService = new LearnerService();
        FeeCalculator feeCalculator = new FeeCalculator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== TRAINING MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Display all courses");
            Console.WriteLine("2. Search course by code");
            Console.WriteLine("3. Search course by title");
            Console.WriteLine("4. Sort courses by fee (ascending)");
            Console.WriteLine("5. Sort courses by fee (descending)");
            Console.WriteLine("6. Register learner");
            Console.WriteLine("7. Display learners");
            Console.WriteLine("8. Search learner");
            Console.WriteLine("9. Test online/classroom session charges");
            Console.WriteLine("10. Test fee calculation");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayCourses(courses);
                    break;

                case "2":
                    SearchByCode(courses);
                    break;

                case "3":
                    SearchByTitle(courses);
                    break;

                case "4":
                    SortByFee(courses, true);
                    DisplayCourses(courses);
                    break;

                case "5":
                    SortByFee(courses, false);
                    DisplayCourses(courses);
                    break;

                case "6":
                    learnerService.RegisterLearner();
                    break;

                case "7":
                    learnerService.DisplayLearners();
                    break;

                case "8":
                    learnerService.SearchLearner();
                    break;

                case "9":
                    TestSessionCharges();
                    break;

                case "10":
                    TestFeeCalculation(feeCalculator);
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Thank you for using the system!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Display all courses
    static void DisplayCourses(Course[] courses)
    {
        Console.WriteLine(
            "\nTitle\t\tCourseCode\tFee\tDuration\tEnrolled\tAvailable");

        for (int i = 0; i < courses.Length; i++)
        {
            Console.WriteLine(
                $"{courses[i].Title}\t\t" +
                $"{courses[i].CourseCode}\t\t" +
                $"{courses[i].Fee}\t" +
                $"{courses[i].DurationDays}\t\t" +
                $"{courses[i].EnrolledCount}\t\t" +
                $"{courses[i].GetAvailableSeats()}");
        }
    }

    // Search course by code
    static void SearchByCode(Course[] courses)
    {
        Console.Write("Enter course code: ");
        string? code = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < courses.Length; i++)
        {
            if (string.Equals(
                code,
                courses[i].CourseCode,
                StringComparison.OrdinalIgnoreCase))
            {
                DisplayOneCourse(courses[i]);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Course not found!");
        }
    }

    // Search course by title
    static void SearchByTitle(Course[] courses)
    {
        Console.Write("Enter course title: ");
        string? title = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < courses.Length; i++)
        {
            if (string.Equals(
                title,
                courses[i].Title,
                StringComparison.OrdinalIgnoreCase))
            {
                DisplayOneCourse(courses[i]);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Course not found!");
        }
    }

    // Display one course
    static void DisplayOneCourse(Course course)
    {
        Console.WriteLine("\nCourse details:");
        Console.WriteLine($"Title: {course.Title}");
        Console.WriteLine($"Course code: {course.CourseCode}");
        Console.WriteLine($"Fee: ₹{course.Fee}");
        Console.WriteLine($"Duration: {course.DurationDays} days");
        Console.WriteLine($"Enrolled learners: {course.EnrolledCount}");
        Console.WriteLine($"Available seats: {course.GetAvailableSeats()}");
    }

    // Sort courses using loops (no LINQ)
    static void SortByFee(Course[] courses, bool ascending)
    {
        for (int i = 0; i < courses.Length - 1; i++)
        {
            for (int j = 0; j < courses.Length - 1 - i; j++)
            {
                bool shouldSwap = ascending
                    ? courses[j].Fee > courses[j + 1].Fee
                    : courses[j].Fee < courses[j + 1].Fee;

                if (shouldSwap)
                {
                    Course temp = courses[j];
                    courses[j] = courses[j + 1];
                    courses[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Sorting completed.");
    }

    // Test inheritance and runtime polymorphism
    static void TestSessionCharges()
    {
        CourseSession online = new OnlineSession(
            "CN01",
            DateTime.Today.AddDays(20),
            90);

        CourseSession classroom = new ClassroomSession(
            "CN02",
            DateTime.Today.AddDays(20),
            85);

        Console.WriteLine(
            $"Online session charge: ₹{online.CalculateSessionCharge()}");

        Console.WriteLine(
            $"Classroom session charge: ₹{classroom.CalculateSessionCharge()}");

        SessionDuration duration = new SessionDuration(90);

        Console.WriteLine($"Session duration: {duration.Days} days");
    }

    // Test fee calculation
    static void TestFeeCalculation(FeeCalculator feeCalculator)
    {
        Console.Write("Enter base course fee: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal baseFee))
        {
            Console.WriteLine("Invalid fee.");
            return;
        }

        Console.Write("Is this an early-bird enrollment? (yes/no): ");
        bool earlyBird = string.Equals(
            Console.ReadLine(),
            "yes",
            StringComparison.OrdinalIgnoreCase);

        Console.Write("Is the group discount applicable? (yes/no): ");
        bool groupDiscount = string.Equals(
            Console.ReadLine(),
            "yes",
            StringComparison.OrdinalIgnoreCase);

        Console.Write("Is this an online session? (yes/no): ");
        bool isOnline = string.Equals(
            Console.ReadLine(),
            "yes",
            StringComparison.OrdinalIgnoreCase);

        try
        {
            var result = feeCalculator.CalculateFee(
                baseFee,
                earlyBird,
                groupDiscount,
                isOnline);

            Console.WriteLine($"Base fee: ₹{result.BaseFee}");
            Console.WriteLine($"Total discount: ₹{result.TotalDiscount}");
            Console.WriteLine($"Final fee: ₹{result.FinalFee}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
