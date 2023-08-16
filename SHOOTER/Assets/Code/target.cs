using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 100;

    public void takeDamage(float  amount)
    {
        // subtracting amount of dmg by enemy health
        health -= amount;
        
        if(health <= 0)
        {

            Die();
        
        }
    
    }

    void Die()
    {

        Destroy(gameObject);

    }

}
