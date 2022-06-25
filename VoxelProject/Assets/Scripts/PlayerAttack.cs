using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject[] tool;
    public ToolSwitching toolSwitch;
    public bool isAttacking = false;

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attacking());
        }
    }

    IEnumerator Attacking()
    {
        tool[toolSwitch.currentWeapon].SetActive(true);
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        tool[toolSwitch.currentWeapon].SetActive(false);
        isAttacking = false;
    }
}
