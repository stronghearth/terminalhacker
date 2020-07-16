using UnityEngine;

public class Hacker : MonoBehaviour
   
{
    //Game config data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "verified", "tweet", "hashtag", "notifications", "mentions" };
    string[] level3Passwords = { "operation", "international", "clandestine", "undercover", "classified"};
    const string menuMessage = "Type 'menu' to return to the main menu.";

    //Game State
    int level;
    string password;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start() {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        Terminal.ClearScreen();
        Terminal.WriteLine("Good Day");
        Terminal.WriteLine("Where shall we venture today?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for Twitter");
        Terminal.WriteLine("Press 3 for CIA");
        Terminal.WriteLine("Enter your selection:");
    }

    void PrintMenuMessage()
    {
        Terminal.WriteLine(menuMessage);
    }

    void OnUserInput(string input) {
        
        if (input == "menu") //user will always have the option to go to the main menu
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        } else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password)
        {
            CheckPassword(level, input);
        }
        
    }

    void RunMainMenu (string input)
    {
        bool isValidLevelNumber = ( input == "1" || input == "2" || input == "3" );
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword(level, input);
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Need I remind you, 007, that you have a license to kill and hacking computer systems is my job. - Q");
            PrintMenuMessage();
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level.");
            PrintMenuMessage();
        }
    }

    void AskForPassword(int level, string input)
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword(level);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        PrintMenuMessage();
    }

    void SetRandomPassword(int level)
    {
        switch (level)
        {
            case 1:
                int randomPasswordOne = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[randomPasswordOne];
                break;
            case 2:
                int randomPasswordTwo = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[randomPasswordTwo];
                break;
            case 3:
                int randomPasswordThree = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[randomPasswordThree];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(int level, string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword(level, input);
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("No more late fees for you!");
                Terminal.WriteLine(@"[̲̅$̲̅(̲̅:D)̲̅$̲̅]");
                break;
            case 2:
                Terminal.WriteLine("Oh no, for some reason, verified users can't tweet! ;)");
                Terminal.WriteLine(@"¯\_(ツ)_/¯");
                break;
            case 3:
                Terminal.WriteLine("Success! You erased your entire history!");
                Terminal.WriteLine(@"(-(-_(-_-)_-)-)");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
        PrintMenuMessage();
    }
}
