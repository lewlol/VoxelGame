using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitching : MonoBehaviour
{
    public GameObject[] borders;

    public int currentWeapon;
    public bool sword = true;
    public bool pick = false;
    public bool axe = false;
    public PlayerAttack attack;

    private void Start()
    {
        CheckingTool();
    }
    private void Update()
    {
        ChangeTool();
        CheckingTool();
    }

    void ChangeTool()
    {
        if (Input.GetKeyDown(KeyCode.Return) && attack.isAttacking == false)
        {
            borders[currentWeapon].SetActive(false);
            currentWeapon++;
            if (currentWeapon > 2)
            {
                currentWeapon = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && attack.isAttacking == false)
        {
            borders[currentWeapon].SetActive(false);
            currentWeapon = 0;
            CheckingTool();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && attack.isAttacking == false)
        {
            borders[currentWeapon].SetActive(false);
            currentWeapon = 1;
            CheckingTool();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && attack.isAttacking == false)
        {
            borders[currentWeapon].SetActive(false);
            currentWeapon = 2;
            CheckingTool();
        }
    }

    void CheckingTool()
    {
        if(currentWeapon == 0 && sword == false)
        {
            sword = true;
            borders[currentWeapon].SetActive(true);
            pick = false;
            axe = false;
        }
        if(currentWeapon == 1 && pick == false)
        {
            pick = true;
            borders[currentWeapon].SetActive(true);
            sword = false;
            axe = false;
        }
        if(currentWeapon == 2 && axe == false)
        {
            axe = true;
            borders[currentWeapon].SetActive(true);
            sword = false;
            pick = false;
        }
    }
}
