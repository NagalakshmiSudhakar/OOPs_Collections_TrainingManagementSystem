
using System;
using System.Collections.Generic;
using OOPs_Collections_TrainingManagementSystem.Models;

namespace OOPs_Collections_TrainingManagementSystem.Services
{
    public class LearnerService
    {
        private readonly Dictionary<string, Learner> learners = new();

        public void RegisterLearner()
        {
            Console.Write("Enter Learner ID: ");
            string learnerId = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(learnerId))
            {
                Console.WriteLine("Learner ID cannot be empty.");
                return;
            }

            if (learners.ContainsKey(learnerId))
            {
                Console.WriteLine("Learner ID already exists.");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            Console.Write("Enter Contact Number: ");
            string contact = Console.ReadLine() ?? "";

            if (contact.Length != 10 || !IsDigitsOnly(contact))
            {
                Console.WriteLine(
                    "Contact number must contain exactly 10 digits.");
                return;
            }

            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(email) ||
                !email.Contains('@') ||
                !email.Contains('.'))
            {
                Console.WriteLine("Enter a valid email address.");
                return;
            }

            Learner learner = new Learner(
                learnerId, name, contact, email);

            learners.Add(learnerId, learner);

            Console.WriteLine("Learner registered successfully!");
        }

        private bool IsDigitsOnly(string value)
        {
            foreach (char character in value)
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }

            return true;
        }

        public void DisplayLearners()
        {
            if (learners.Count == 0)
            {
                Console.WriteLine("No learners registered.");
                return;
            }

            foreach (Learner learner in learners.Values)
            {
                Console.WriteLine(
                    $"{learner.LearnerId} | {learner.Name} | " +
                    $"{learner.ContactNumber} | {learner.Email}");
            }
        }

        public void SearchLearner()
        {
            Console.Write("Enter Learner ID to search: ");
            string learnerId = Console.ReadLine() ?? "";

            if (learners.TryGetValue(learnerId, out Learner? learner))
            {
                Console.WriteLine($"ID: {learner.LearnerId}");
                Console.WriteLine($"Name: {learner.Name}");
                Console.WriteLine($"Contact: {learner.ContactNumber}");
                Console.WriteLine($"Email: {learner.Email}");
            }
            else
            {
                Console.WriteLine("Learner not found.");
            }
        }
    }
}
