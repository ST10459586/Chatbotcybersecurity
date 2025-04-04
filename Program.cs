using System;
using System.Media;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace cybersecuritybot
{
    internal class Program
    {
        private static string username = "User";

        public class InputValidator
        {
            // Dictionary of validation patterns
            private readonly Dictionary<string, Regex> validationPatterns = new Dictionary<string, Regex>
            {
                { "name", new Regex(@"^[a-zA-Z\s]{2,30}$") },
                { "command", new Regex(@"^[a-zA-Z\s]+$") }
            };

            // List of supported commands
            private readonly List<string> supportedCommands = new List<string>
            {
                "topics", "exit", "hello", "hi", "how are you", "what is your name", "tell me a joke",
                "phishing", "malware", "passwords","two-factor authentication","backups", "public wifi"
            };

            // Validate input based on type
            public bool IsValid(string input, string type)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return false;

                if (type == "command")
                {
                    foreach (var cmd in supportedCommands)
                    {
                        if (input.ToLower().Contains(cmd))
                            return true;
                    }
                    return false;
                }
                else if (validationPatterns.ContainsKey(type))
                {
                    return validationPatterns[type].IsMatch(input);
                }

                return !string.IsNullOrWhiteSpace(input);
            }

            // Validating input
            public string GetValidInput(string prompt, string type)
            {
                string input;
                bool isValid = false;

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{prompt}: ");
                    Console.ResetColor();

                    input = Console.ReadLine()?.Trim() ?? "";

                    isValid = IsValid(input, type);
                    if (!isValid)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid input. Please enter a valid {type}.");
                        Console.ResetColor();
                    }
                } while (!isValid);

                return input;
            }
        }

        public class ConsoleUI
        {
            // Display text with typing effect
            public static void TypeText(string text, int delay = 10)
            {
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(delay);
                }
                Console.WriteLine();
            }

            // Display a section header
            public static void DisplayHeader(string title)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n┌─── {title} ───".PadRight(50, '─') + "┐");
                Console.ResetColor();
            }

            // Display a section footer
            public static void DisplayFooter()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"└" + "".PadRight(50, '─') + "┘\n");
                Console.ResetColor();
            }

            // Display welcome message with ASCII art
            public static void DisplayWelcome()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
      ┌────────────────────────────────────────────┐
      │             CYBERSECURITY                  │
      │           AWARENESS ASSISTANT              │
      ├────────────────────────────────────────────┤
      │  ★★★ Version 1.0 ★★★                   │
      │  Created: March 31, 2025                   │
      │  Keeping you safe in the digital world     │
      └────────────────────────────────────────────┘
      ");
                Console.ResetColor();
            }

            // Display bot response with highlighting
            public static void BotResponse(string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nCSA Bot: ");
                Console.ResetColor();
                TypeText(message);
            }
        }

        public class Chatbot
        {
            private readonly string[] cybersecurityTopics = {
                "phishing",
                "malware",
                "passwords",
                "two-factor authentication",
                "backups",
                "public wifi"
            };

            public string GetCybersecurityInfo(string topic)
            {
                switch (topic.ToLower())
                {
                    case "phishing":
                        return "Phishing is a type of social engineering attack where attackers attempt to steal sensitive information by disguising as a trustworthy entity. Always verify the sender's email address, check for spelling/grammar errors, and never click on suspicious links or download unexpected attachments.";

                    case "malware":
                        return "Malware is malicious software designed to harm your computer or steal information. This includes viruses, worms, trojans, and spyware. Always use reputable antivirus software, keep it updated, and scan your system regularly.";

                    case "passwords":
                        return "Use strong, unique passwords for each account. A strong password should be at least 12 characters long with a mix of uppercase and lowercase letters, numbers, and special characters. Consider using a password manager to help generate and store complex passwords.";

                    case "social engineering":
                        return "Social engineering is the psychological manipulation of people into performing actions or divulging confidential information. Be suspicious of unexpected contact, verify requests for information through official channels, and remember that if something seems too good to be true, it probably is.";

                    case "data protection":
                        return "Protect sensitive data by encrypting important files, using secure communication channels, regularly backing up your data, and properly disposing of old devices by securely wiping all data before recycling or donating them.";

                    case "ransomware":
                        return "Ransomware is a type of malware that encrypts your files and demands payment for the decryption key. Prevent ransomware attacks by maintaining regular backups, being cautious about email attachments, keeping software updated, and using security software.";

                    case "two-factor authentication":
                        return "Two-factor authentication (2FA) adds an extra layer of security by requiring two different types of verification before access is granted. Enable 2FA on all accounts that offer it to significantly increase your security, even if your password is compromised.";

                    case "updates":
                        return "Software updates often contain security patches for newly discovered vulnerabilities. Keep your operating system, applications, and security software updated to protect against the latest threats.";

                    case "backups":
                        return "Regular backups protect your data in case of hardware failure, theft, or ransomware attacks. Follow the 3-2-1 rule: keep 3 copies of your data, on 2 different media types, with 1 copy stored offsite or in the cloud.";

                    case "public wifi":
                        return "Public WiFi networks are often unsecured, making it easy for attackers to intercept your data. Avoid accessing sensitive information on public WiFi, use a VPN for encryption, and ensure websites use HTTPS before entering any personal information.";

                    default:
                        return "I don't have specific information on that cybersecurity topic. Try asking about: phishing, malware, passwords, social engineering, data protection, ransomware, two-factor authentication, updates, backups, or public wifi.";
                }
            }

            public void StartConversation()
            {
                ConsoleUI.DisplayHeader("WELCOME MESSAGE");
                ConsoleUI.BotResponse($"Hello, {Program.username}! I'm your Cybersecurity Awareness Assistant.I can help you learn about various cybersecurity topics");
                ConsoleUI.BotResponse("Type 'topics' to see all available topics, or type 'exit' to end our conversation.");
                ConsoleUI.DisplayFooter();
            }

            public string ProcessInput(string input)
            {
                // Added input validation
                if (string.IsNullOrEmpty(input))
                    return "I didn't catch that. Could you please try again?";

                input = input.ToLower().Trim();

                if ((input == "hello") || (input == "hi"))
                    return $"Hello, {Program.username}! How can I assist you with cybersecurity today?";

                if (input == "how are you")
                    return "I'm ready to help you stay safe online! What cybersecurity topic would you like to learn about?";

                if (input == "what is your name")
                    return "I'm the Cybersecurity Awareness Assistant, designed to help you understand cybersecurity best practices.";

                if (input == "exit")
                    return "Goodbye! Stay safe online!";

                if (input == "topics")
                {
                    // Enhanced topics display
                    ConsoleUI.DisplayHeader("AVAILABLE TOPICS");
                    StringBuilder sb = new StringBuilder("I can provide information on these cybersecurity topics:\n");

                    foreach (string topic in cybersecurityTopics)
                    {
                        sb.Append($"\n• {topic}");
                    }

                    sb.Append("\n\nWhat would you like to learn about?");
                    return sb.ToString();
                }

                if (input == "tell me a joke")
                    return "Why don't hackers go on vacation? They're afraid of getting phished! Now, let's get back to cybersecurity awareness.";

                // Check if the input contains any of our cybersecurity topics
                foreach (string topic in cybersecurityTopics)
                {
                    if (input.Contains(topic))
                    {
                        ConsoleUI.DisplayHeader($"TOPIC: {topic.ToUpper()}");
                        return GetCybersecurityInfo(topic);
                    }
                }

                return "I'm not sure I understand. For cybersecurity assistance, try asking about specific topics like phishing, passwords, or malware. Type 'topics' to see all available topics.";
            }
        }

        static void Main(string[] args)
        {
            // Enhanced display logo
            ConsoleUI.DisplayWelcome();
            Console.WriteLine("Hello, Welcome to Cybersecurity Awareness Bot! I am here to help you stay safe online");

            // Plays welcome audio file at the beginning
            try
            {
                using (SoundPlayer soundPlayer = new SoundPlayer("Audio.wav"))
                {
                    soundPlayer.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Note: Welcome audio could not be played: {ex.Message}");
                Console.ResetColor();
            }

            // Added validation for username input
            InputValidator validator = new InputValidator();
            ConsoleUI.DisplayHeader("USER INFORMATION");
            username = validator.GetValidInput("Please enter your name", "name");
            ConsoleUI.DisplayFooter();

            try
            {
                Chatbot chatbot = new Chatbot();
                chatbot.StartConversation();

                bool shutdown = false;
                while (!shutdown)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nUser: ");
                    Console.ResetColor();

                    string input = Console.ReadLine();

                    if (input == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input was null. Exiting...");
                        Console.ResetColor();
                        break;
                    }

                    string response = chatbot.ProcessInput(input);

                    // Enhanced response display
                    ConsoleUI.BotResponse(response);

                    if (input.ToLower().Trim() == "exit")
                    {
                        ConsoleUI.DisplayHeader("GOODBYE");
                        Console.WriteLine("Thank you for using the Cybersecurity Awareness Assistant!");
                        Console.WriteLine("Remember to stay vigilant online.");
                        ConsoleUI.DisplayFooter();
                        shutdown = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace); // Print stack trace for debugging
                Console.WriteLine("Press any key to exit...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
