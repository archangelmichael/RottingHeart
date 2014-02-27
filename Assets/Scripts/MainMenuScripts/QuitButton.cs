using UnityEngine;
using System.Collections;
using System;

public class QuitButton : Button
{
    // change the text color when button pointed
    public override void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    public override void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    // quit the game on mouse click
    public override void OnMouseDown()
    {
        Application.Quit();
    }
}