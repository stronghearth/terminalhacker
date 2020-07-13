using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    int level;
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
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "menu") 
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
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

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You chose level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }
}
