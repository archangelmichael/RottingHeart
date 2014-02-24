using UnityEngine;
using System.Collections;
using System;

public class QuitGame : MonoBehaviour
{
    // change the text color when button pointed
    void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    // quit the game on mouse click
    void OnMouseDown()
    {
        Application.Quit();
    }
}