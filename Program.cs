using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Workout> workouts = new List<Workout>();

            bool continueLogging = true;
            while (continueLogging)
            {
                Console.WriteLine("Fitness Tracker");
                Console.WriteLine("1. Log a Workout");
                Console.WriteLine("2. View Workouts");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LogWorkout(workouts);
                        break;
                    case "2":
                        ViewWorkouts(workouts);
                        break;
                    case "3":
                        continueLogging = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void LogWorkout(List<Workout> workouts)
        {
            Console.Write("Enter the type of workout (e.g., Running, Cycling, Weightlifting): ");
            string type = Console.ReadLine();
            Console.Write("Enter the duration (in minutes): ");
            int duration = int.Parse(Console.ReadLine());
            Console.Write("Enter the calories burned: ");
            int caloriesBurned = int.Parse(Console.ReadLine());

            workouts.Add(new Workout(type, duration, caloriesBurned));

            Console.WriteLine("Workout logged successfully!");
        }

        static void ViewWorkouts(List<Workout> workouts)
        {
            if (workouts.Count == 0)
            {
                Console.WriteLine("No workouts logged yet.");
            }
            else
            {
                Console.WriteLine("Workouts:");
                foreach (var workout in workouts)
                {
                    Console.WriteLine($"Type: {workout.Type}, Duration: {workout.Duration} minutes, Calories Burned: {workout.CaloriesBurned}");
                }
            }
        }
    }

    class Workout
    {
        public string Type { get; }
        public int Duration { get; }
        public int CaloriesBurned { get; }

        public Workout(string type, int duration, int caloriesBurned)
        {
            Type = type;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
        }
    }
}
