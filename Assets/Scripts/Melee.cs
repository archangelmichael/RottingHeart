using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour //, IMeleeAttack
{
    public static float weaponRange = 10;
    private static float damage = 50;
    private static float defence = 50;
    private Transform thesystem;

    public static float attackRepeatTime = 1.0f;
    private static float attackTime;

    private string GetCurrentShield()
    {
        string activeShield;
        for (int i = 0; i < ShieldSwitch.shields.Count; i++)
        {
            if (ShieldSwitch.shields[i].gameObject.activeSelf == true)
            {
                activeShield = ShieldSwitch.shields[i].gameObject.name;
                return activeShield;
            }
        }
        return null;
    }
    private string GetCurrentWeapon()
    {
        string activeWeapon;
        for (int i = 0; i < WeaponSwitch.weapons.Count; i++)
        {
            if (WeaponSwitch.weapons[i].gameObject.activeSelf == true)
            {
                activeWeapon = WeaponSwitch.weapons[i].gameObject.name;
                return activeWeapon;
            }
        }
        return null;
    }
    public void GetCurrentAttackAndRange()
    {
        string weapon = GetCurrentWeapon();
        if (weapon == "Spear")
        {
            damage = 100;
            weaponRange = 20;
        }
        else if (weapon == "Staff")
        {
            damage = 120;
            weaponRange = 10;
        }
        else if (weapon == "Dagger")
        {
            damage = 50;
            weaponRange = 5;
        }
    }
    public void GetCurrentDefence()
    {
        string shield = GetCurrentShield();
        if (shield == "Magic")
        {
            defence = 100;
        }
        else if (shield == "Bronze")
        {
            defence = 70;
        }
        else if (shield == "Wooden")
        {
            defence = 50;
        }
    }

    void Update()
    {
        GetCurrentAttackAndRange();
        GetCurrentDefence();
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 30, Screen.width / 4 + damage, 20), "DAMAGE " + damage);
        GUI.Box(new Rect(10, 50, Screen.width / 4 + weaponRange, 20), "RANGE " + weaponRange);
        GUI.Box(new Rect(10, 70, Screen.width / 4 + defence, 20), "DEFENCE " + defence);
    }

    public static void AttackEnemy(Vector3 positionAtScreen, RaycastHit hit)
    {
        if (Time.time > attackTime)
        {
            Debug.Log("attack enemy!");
            hit.transform.SendMessage("DamageEnemy", damage, SendMessageOptions.DontRequireReceiver);
            attackTime = Time.time + attackRepeatTime;
        }
    }
}
