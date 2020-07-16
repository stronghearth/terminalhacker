using UnityEngine;

public class Hacker : MonoBehaviour
   
{
    //Game config data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "verified", "tweet", "hashtag", "like", "viral" };

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
        Terminal.WriteLine("Enter your selection:");
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
            CheckPassword(input);
        }
        
    }

    void RunMainMenu (string input)
    {
        bool isValidLevelNumber = ( input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame(level, input);
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Need I remind you, 007, that you have a license to kill and hacking computer systems is my job. - Q");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level.");
        }
    }

    void StartGame(int level, string input)
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password: ");
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
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Please try again.");
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
                Terminal.WriteLine("Oh no, for some reason verified users can't tweet! ;)");
                Terminal.WriteLine(@"¯\_(ツ)_/¯");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
