using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
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
        Terminal.WriteLine("Press 2 for police radio");
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
        if (input == "1")
        {
            level = 1;
            password = "books";
            StartGame(level, input);
        }
        else if (input == "2")
        {
            level = 2;
            password = "prisoner";
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
        Terminal.WriteLine("You chose level " + level);
        Terminal.WriteLine("Please enter your password: ");

    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Correct!");
        }
        else
        {
            Terminal.WriteLine("Please try again.");
        }
    }
}
