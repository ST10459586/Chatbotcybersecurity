# cybersecuritybot
# Cybersecurity Awareness Assistant

## Overview
The Cybersecurity Awareness Assistant is a console-based chatbot application designed to educate users about various cybersecurity topics and best practices. It provides information on common security concerns such as phishing, malware, password security, and more in an interactive and visually appealing format.

## Features
- **Interactive Command-Line Interface**: Enhanced console UI with colors, borders, and visual elements
- **Input Validation**: Detects and responds to invalid inputs and unsupported queries
- **Educational Content**: Provides detailed information on various cybersecurity topics
- **Typing Effect**: Simulates a conversational feel with text animation
- **Visual Elements**: Uses colored text, decorative borders, and symbols for better readability
- **Audio Welcome**: Plays a welcome audio message (when available)

## Getting Started

### Prerequisites
- .NET Framework 4.6.1 or higher
- Windows OS (for full audio support)

### Installation
1. Clone or download the repository
2. Open the solution in Visual Studio
3. Build the solution
4. Run the application

### Audio Setup (Optional)
To enable the welcome audio feature:
1. Add an audio file named "Audio.wav" to the output directory
2. Make sure the file is set to "Copy to Output Directory" in its properties

## Usage

### Basic Commands
- `topics` - View all available cybersecurity topics
- `help` - Display the help menu
- `clear` - Clear the console screen
- `exit` - End the conversation
- `about` - Information about the application

### Cybersecurity Topics
The assistant can provide information on the following cybersecurity topics:
- phishing
- malware
- passwords
- social engineering
- data protection
- ransomware
- two-factor authentication
- updates
- backups
- public wifi

Simply type the topic name to get detailed information about it.

## Code Structure

### Main Components
- **Program Class**: Contains the main entry point and application logic
- **InputValidator Class**: Handles validation of user inputs
- **ConsoleUI Class**: Manages the visual elements and user interface
- **Chatbot Class**: Processes user inputs and provides appropriate responses

### Key Methods
- `InputValidator.GetValidInput()`: Gets validated input from the user
- `ConsoleUI.DisplayWelcome()`: Displays the welcome screen with ASCII art
- `ConsoleUI.TypeText()`: Creates a typing effect for a more natural conversation
- `Chatbot.ProcessInput()`: Processes commands and returns appropriate responses
- `Chatbot.GetCybersecurityInfo()`: Provides information on specific topics

## Customization

### Visual Elements
You can customize the console colors by modifying the following variables in the `ConsoleUI` class:
- `PrimaryColor` - Used for borders and main elements (default: Cyan)
- `SecondaryColor` - Used for prompts and headers (default: Yellow)
- `AccentColor` - Used for success messages (default: Green)
- `ErrorColor` - Used for error messages (default: Red)
- `HighlightColor` - Used for bot responses (default: White)

### Adding New Topics
To add new cybersecurity topics:
1. Add the topic name to the `cybersecurityTopics` array in the `Chatbot` class
2. Add a new case for the topic in the `GetCybersecurityInfo()` method
3. Provide the information text for the new topic

## Contributing
Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgements
- Created as a tool for cybersecurity education
- Inspired by the need for better cybersecurity awareness
- ASCII art generated using text-to-ASCII art tools

## Version History
- 1.1: Added input validation, enhanced UI, and visual elements (April 2025)
- 1.0: Initial release (March 2025)
