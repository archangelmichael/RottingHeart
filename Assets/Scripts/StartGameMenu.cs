using UnityEngine;
using System.Collections;

public class StartGameMenu : MonoBehaviour
{
    private string playerName = string.Empty;
    private byte usernameMaxLength = 14;

    // check is the username valid or not
    private bool UserName(string username)
    {
        bool isValid = true;

        if (username.Length < 1 || username.Length > usernameMaxLength)
        {
            isValid = false;
        }
        return isValid;
    }

    void OnGUI()
    {
        playerName = GUI.TextField(new Rect(140, 240, 147, 24), playerName.ToUpper(), usernameMaxLength);
        //playerName = GUI.TextField(new Rect(38, 120, 147, 24), playerName.ToUpper(), usernameMaxLength);
    }

    // ------------------------------------------
    // change the text color when button pointed
    void OnMouseEnter()
    {
        if (UserName(playerName))
        {
            renderer.material.color = Color.green;
        }
        //else
        //{
        //    renderer.material.color = Color.black;
        //}
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    // ------------------------------------------
    // load the game on mouse click
    void OnMouseDown()
    {
        if (UserName(playerName))
        {
            Application.LoadLevel("LevelOne");
        }
    }
}