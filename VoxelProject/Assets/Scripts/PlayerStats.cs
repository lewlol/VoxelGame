using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health { get; private set; }

    public Stat maxHealth;
    public Stat damage;
    public Stat speed;
    private void Awake()
    {
        health = maxHealth.GetValue();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        //Death Moment
        //Something about being overwitten
        Debug.Log(transform.name + " Took a Death Moment");
    }
}
