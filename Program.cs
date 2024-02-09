using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("3. Calculate Total Calories Burned");
                Console.WriteLine("4. Sort Workouts by Duration");
                Console.WriteLine("5. Filter Workouts by Type");
                Console.WriteLine("6. Edit/Delete Workouts");
                Console.WriteLine("7. Export Workouts to File");
                Console.WriteLine("8. Exit");
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
                        CalculateTotalCaloriesBurned(workouts);
                        break;
                    case "4":
                        SortWorkoutsByDuration(workouts);
                        break;
                    case "5":
                        FilterWorkoutsByType(workouts);
                        break;
                    case "6":
                        EditOrDeleteWorkouts(workouts);
                        break;
                    case "7":
                        ExportWorkoutsToFile(workouts);
                        break;
                    case "8":
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

        static void CalculateTotalCaloriesBurned(List<Workout> workouts)
        {
            int totalCaloriesBurned = workouts.Sum(w => w.CaloriesBurned);
            Console.WriteLine($"Total calories burned: {totalCaloriesBurned}");
        }

        static void SortWorkoutsByDuration(List<Workout> workouts)
        {
            var sortedWorkouts = workouts.OrderBy(w => w.Duration).ToList();
            ViewWorkouts(sortedWorkouts);
        }

        static void FilterWorkoutsByType(List<Workout> workouts)
        {
            Console.Write("Enter the type of workout to filter (e.g., Running, Cycling, Weightlifting): ");
            string type = Console.ReadLine();
            var filteredWorkouts = workouts.Where(w => w.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
            ViewWorkouts(filteredWorkouts);
        }

        static void EditOrDeleteWorkouts(List<Workout> workouts)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Edit Workout");
            Console.WriteLine("2. Delete Workout");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.WriteLine("Enter the index of the workout to edit:");
                int index = int.Parse(Console.ReadLine()) - 1;
                if (index >= 0 && index < workouts.Count)
                {
                    Console.Write("Enter the new type of workout: ");
                    workouts[index].Type = Console.ReadLine();
                    Console.Write("Enter the new duration (in minutes): ");
                    workouts[index].Duration = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new calories burned: ");
                    workouts[index].CaloriesBurned = int.Parse(Console.ReadLine());
                    Console.WriteLine("Workout updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else if (option == "2")
            {
                Console.WriteLine("Enter the index of the workout to delete:");
                int index = int.Parse(Console.ReadLine()) - 1;
                if (index >= 0 && index < workouts.Count)
                {
                    workouts.RemoveAt(index);
                    Console.WriteLine("Workout deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

        static void ExportWorkoutsToFile(List<Workout> workouts)
        {
            Console.Write("Enter the file path to export workouts: ");
            string filePath = Console.ReadLine();
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(filePath))
            {
                foreach (var workout in workouts)
                {
                    file.WriteLine($"{workout.Type},{workout.Duration},{workout.CaloriesBurned}");
                }
            }
            Console.WriteLine("Workouts exported to file successfully!");
        }
    }

    class Workout
    {
        public string Type { get; set; }
        public int Duration { get; set; }
        public int CaloriesBurned { get; set; }

        public Workout(string type, int duration, int caloriesBurned)
        {
            Type = type;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
        }
    }
}
