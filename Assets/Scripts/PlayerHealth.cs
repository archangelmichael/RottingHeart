using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Camera))]

public class PlayerHealth : MonoBehaviour
{
    public Camera lookAround1;
    public CharacterController charController;
    
    public float maxHealth = 10000;
    public float currentHealth;
    
    public float healthbarLength;
    public static bool playerIsDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthbarLength = Screen.width / 2;
    }
    void Update()
    {
        AdjustCurrentHealth(0);
        if (playerIsDead)
        {
            lookAround1.enabled = false;
            charController.enabled = false;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 2 / (maxHealth / currentHealth), 20), currentHealth + "/" + maxHealth);
        if (playerIsDead || Input.GetKeyDown(KeyCode.Escape))
        {
            // Make a background box
            GUI.Box(new Rect(Screen.width/2 , Screen.height / 2, 150, 100), "You have been killed!");
            // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 20, 80, 20), "Respawn"))
            {
                RespawnPlayer();
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 40, 80, 20), "Exit Game"))
            {
                Application.Quit();
            }
        }
    }

    public void AdjustCurrentHealth(float adj)
    {
        currentHealth += adj;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
        healthbarLength = (Screen.width / 2) * (currentHealth / (float)maxHealth);
    }

    void DamagePlayer(float damage) // Applies damage when hit
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        playerIsDead = true;
        animation.CrossFade("die");
    }

    void RespawnPlayer()
    {
        //transform.position = respawnLocation.position;
        //transform.rotation = respawnLocation.rotation;
        //gameObject.SendMessage("RespawnStats");
        playerIsDead = false;
        currentHealth = maxHealth;
        lookAround1.enabled = true;
        charController.enabled = true;
        Application.LoadLevel(1);
    }
    
}
