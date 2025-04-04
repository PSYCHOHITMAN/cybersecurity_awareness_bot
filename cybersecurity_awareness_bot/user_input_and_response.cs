using System.Collections;
using System.Threading;
using System;

namespace cybersecurity_awareness_bot
{
    public class user_input_and_response
    {
        // Lists to store questions, answers, and ignored words
        ArrayList questions = new ArrayList();
        ArrayList answers = new ArrayList();
        ArrayList ignoreWords = new ArrayList();

        public user_input_and_response()
        {
            Store_IgnoreWords(); // Set ignored words
            Store_Responses();   // Set questions and answers

            //exception handling
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Enter your name: ");
                Console.ResetColor();

                string userName = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(userName))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    userName = "User"; // Default name if none given
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome {userName}! I'm here to answer your cybersecurity questions. Just type 'exit' when you're done.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                string userInput;

                //do-while loop to keep the code running until user types exit
                do
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{userName}:-> ");
                    Console.ResetColor();
                    userInput = Console.ReadLine()?.Trim().ToLower();

                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypeEffect("Cybersecurity Bot:-> Please enter a question related to cybersecurity\n");
                        Console.ResetColor();
                        continue;
                    }

                    if (userInput != "exit")
                    {
                        ProcessQuestion(userInput); // Handle user question
                    }

                } while (userInput != "exit");

                Console.ForegroundColor = ConsoleColor.Green;
                TypeEffect($"Cybersecurity Bot:-> Goodbye, {userName}! Stay safe online.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOops! Something went wrong. Please restart the chatbot.");
                Console.ResetColor();
                Console.WriteLine($"Error Details: {ex.Message}");
            }
        }

        //method to add a type like effect response
        private void TypeEffect(string text)
        {
            // Simulate typing effect
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        //method to handle the user questions
        private void ProcessQuestion(string question)
        {
            try
            {
                // Remove punctuation
                question = new string(Array.FindAll(question.ToCharArray(), c => !char.IsPunctuation(c)));
                string[] words = question.Split(' ');
                ArrayList relevantWords = new ArrayList();

                // Remove ignored words
                foreach (string word in words)
                {
                    if (!ignoreWords.Contains(word))
                    {
                        relevantWords.Add(word);
                    }
                }

                bool found = false;
                string message = string.Empty;
                Random rand = new Random();

                // Check if any word matches stored questions
                foreach (string word in relevantWords)
                {
                    for (int i = 0; i < questions.Count; i++)
                    {
                        if (questions[i].ToString().Contains(word))
                        {
                            ArrayList possibleAnswers = (ArrayList)answers[i];
                            string selectedAnswer = (string)possibleAnswers[rand.Next(possibleAnswers.Count)];

                            message += selectedAnswer + "\n";
                            found = true;
                        }
                    }
                }

                // Show answer or default response
                if (found)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypeEffect("Cybersecurity Bot:-> " + message);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeEffect("Cybersecurity Bot:-> I couldn't find an answer for that. ask questions about passwords, phishing, or cybersecurity topics.\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAn error occurred while processing your question. Please try again.");
                Console.ResetColor();
                Console.WriteLine($"Error Details: {ex.Message}");
            }
        }

        //method to store IgnoredWords
        private void Store_IgnoreWords()
        {
            // Common words to ignore in questions
            ignoreWords.Add("tell");
            ignoreWords.Add("me");
            ignoreWords.Add("about");
            ignoreWords.Add("what");
            ignoreWords.Add("is");
            ignoreWords.Add("a");
            ignoreWords.Add("the");
            ignoreWords.Add("how");
            ignoreWords.Add("do");
            ignoreWords.Add("you");
            ignoreWords.Add("explain");
            ignoreWords.Add("your");
            ignoreWords.Add("you");

        }

        //method for stored_Responses
        private void Store_Responses()
        {
            // Store questions and multiple answers
            questions.Add("password");// Adding the keyword to the questions list
            answers.Add(new ArrayList { // Adding an ArrayList of possible answers for "password"
                "A strong password should be at least 12 characters long and contain a mix of letters, numbers, and symbols.",
                "Using a password manager is a great way to store and generate strong passwords securely.",
                "Avoid using the same password across multiple sites to reduce security risks.",
                "Change your passwords regularly, especially if a website reports a data breach.",
                "Passphrases (random words combined) can be easier to remember and more secure than complex passwords."
            });

            questions.Add("cybersecurity");
            answers.Add(new ArrayList {
                "Cybersecurity is the practice of protecting systems, networks, and data from digital attacks.",
                "Cybersecurity involves implementing security measures to prevent unauthorized access, data breaches, and cyber threats.",
                "It's all about staying safe online! Think of it like locking your doors, but for your digital life.",
                "Hackers try to break into systems every day. Cybersecurity helps stop them!",
                "Keeping software updated, using strong passwords, and enabling two-factor authentication are simple steps to improve cybersecurity."
            });

            questions.Add("how are you");
            answers.Add(new ArrayList {
                "I'm just a bot, but I'm always here to help!",
                "I'm functioning at optimal efficiency! How can I assist you today?"
            });

            questions.Add("what's your purpose");
            answers.Add(new ArrayList {
                "My purpose is to provide cybersecurity tips and answer your security-related questions.",
                "I'm here to help you stay safe online by answering your questions about cybersecurity."
            });

            questions.Add("what can I ask you about");
            answers.Add(new ArrayList {
                "You can ask me about password security, phishing, malware, VPNs, and more!",
                "I can help with cybersecurity topics like safe browsing, password management, and online threats."
            });

            questions.Add("phishing");
            answers.Add(new ArrayList {
                "Phishing scams trick you into revealing personal information. Be cautious with unexpected emails and links.",
                "Always verify the sender before clicking on email links. If in doubt, go directly to the official website instead.",
                "Look for signs of phishing, like urgent language, misspellings, and unexpected attachments.",
                "Legitimate companies will never ask for sensitive information via email or text.",
                "If you suspect a phishing attempt, report it and never interact with the email."
            });

            questions.Add("safe browsing");
            answers.Add(new ArrayList {
                "Safe browsing means avoiding malicious websites and using secure connections to protect your data.",
                "Always check for 'HTTPS' in the URL before entering sensitive information online.",
                "Be cautious when clicking on links, especially in emails or pop-ups, as they may lead to phishing sites.",
                "Keeping your browser updated helps protect against the latest security threats.",
                "Consider using browser extensions that enhance security, like ad blockers and anti-tracking tools."
            });

            questions.Add("firewall");
            answers.Add(new ArrayList {
                "A firewall acts as a security barrier between your device and potential cyber threats.",
                "Firewalls help prevent unauthorized access by filtering incoming and outgoing traffic.",
                "Enable your operating system’s built-in firewall for an extra layer of protection.",
                "Both hardware and software firewalls can enhance your network security.",
                "Regularly updating your firewall settings helps protect against new threats."
            });

            questions.Add("malware");
            answers.Add(new ArrayList {
        "Malware is harmful software that can damage or steal data from your system. Keep your software updated and avoid suspicious downloads.",
        "Installing a reliable antivirus program can help detect and remove malware before it harms your system.",
        "Avoid downloading software from untrusted sources to reduce malware risks.",
        "Malware can spread through email attachments, fake downloads, and malicious websites.",
        "Regularly scanning your system for malware helps keep your devices secure."
    });

            questions.Add("vpn");
            answers.Add(new ArrayList {
        "A VPN (Virtual Private Network) encrypts your internet connection, keeping your data private from hackers and trackers.",
        "Using a VPN on public Wi-Fi adds an extra layer of security to prevent unauthorized access to your data.",
        "Some VPNs keep logs, so choose a no-log VPN service for better privacy.",
        "A VPN can help bypass geo-restrictions but shouldn't be used for illegal activities.",
        "Free VPNs often come with risks, such as logging your data or slower speeds."
    });

            questions.Add("ransomware");
            answers.Add(new ArrayList {
        "Ransomware locks your files and demands payment. Never pay the ransom—there’s no guarantee you’ll regain access!",
        "Regularly back up your important files to an external drive or cloud storage to protect against ransomware attacks.",
        "Avoid opening unexpected email attachments, as ransomware often spreads through phishing emails.",
        "Use advanced security software to detect and block ransomware threats before they spread.",
        "Disabling macros in documents from untrusted sources can help prevent ransomware infections."
    });

            questions.Add("sql");
            answers.Add(new ArrayList {
        "SQL (Structured Query Language) is used to manage databases but can be vulnerable to SQL injection attacks.",
        "To prevent SQL injection, always use parameterized queries instead of directly concatenating user inputs.",
        "Database administrators should regularly review permissions to restrict unauthorized access to sensitive data.",
        "Encrypting stored data and using strong authentication can improve SQL database security.",
        "Input validation and proper error handling help prevent attackers from exploiting SQL vulnerabilities."
    });

            questions.Add("2fa");
            answers.Add(new ArrayList {
        "Two-Factor Authentication (2FA) adds an extra layer of security by requiring a second verification step beyond your password.",
        "Enabling 2FA on your accounts makes it much harder for hackers to access them, even if they steal your password.",
        "Popular 2FA methods include SMS codes, authentication apps, and hardware security keys.",
        "Authentication apps like Google Authenticator and Authy are more secure than SMS-based 2FA.",
        "For maximum security, use a hardware key like YubiKey instead of SMS or app-based 2FA."
    });

        }
    }
}



