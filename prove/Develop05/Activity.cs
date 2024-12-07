/* 
This C# Program Code is made by Hazel Diane Fernandez for W05 Prove: Developer—Mindfulness
*/

using System;
using System.IO;
using System.Threading;

namespace Develop05
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;
        protected string _userName;  
        protected static int _activityCount = 0;  
        protected static string logFilePath = "activity_log.txt";  

        public Activity(string activityName, string description, int activityDuration)
        {
            _name = activityName;
            _description = description;
            _duration = activityDuration;
        }

        public void StartActivity()
        {
            Console.Clear();
            AskForName();  
            DisplayStartingMessage();
            LoadActivityLog(); 
        }

        public abstract void Run(int seconds);

        private void DisplayStartingMessage()
        {
            Console.WriteLine($"Welcome to the {_name} Activity, {_userName}.\n");
            Console.WriteLine($"{_description}\n");
        }

        private void AskForName()
        {
            Console.Write("Please enter your name: ");
            _userName = Console.ReadLine(); 
        }

        public int GetActivityDuration()
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            int userDuration = Int32.Parse(Console.ReadLine() ?? string.Empty);
            _duration = userDuration;
            return userDuration;
        }

        public void SetActivityDuration(int activityDuration)
        {
            _duration = activityDuration;
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!!\n");
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name} activity, {_userName}.");
            _activityCount++;  
            Console.WriteLine($"Great Job! You have performed {_activityCount} activities.");

            SaveActivityLog();  
            Thread.Sleep(5000);
        }

        public void Loading()
        {
            Console.Clear();
            if (_duration > 0)
            {
                Console.Write("Get ready");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
            }
        }

      
        public static int GetActivityCount()
        {
            return _activityCount;
        }

       
        private void SaveActivityLog()
        {
            try
            {
                
                using (StreamWriter writer = new StreamWriter(logFilePath, false))
                {
                    writer.WriteLine($"Last Activity Done: {_name}");
                    writer.WriteLine($"Total Sessions: {_activityCount}");
                    writer.WriteLine($"Last Session: {DateTime.Now}");
                    writer.WriteLine("------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving log: {ex.Message}");
            }
        }

       
        private void LoadActivityLog()
        {
            try
            {
                if (File.Exists(logFilePath))
                {
                  
                    using (StreamReader reader = new StreamReader(logFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            
                            if (line.Contains("Total Sessions"))
                            {
                                string[] parts = line.Split(":");
                                if (int.TryParse(parts[1].Trim(), out int count))
                                {
                                    _activityCount = count;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Activity log loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No activity log found. A new log will be created.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading log: {ex.Message}");
            }
        }
    }
}
