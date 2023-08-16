using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingcode : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Camera fpscam;
    public float damage = 10f;

    public GameObject player;
    public AudioSource src;
    public AudioClip sfx1;
    
    
  
    public ParticleSystem muzzleFlash;
    
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float range = 100f;
    
    public float playerHealth = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
void Update()
{
    Debug.Log(playerHealth);
    Application.targetFrameRate = 60;
    if (Input.GetButton("Fire1"))
    {

        if (!alreadyAttacked)
        {
            /// Attack code here
            src.clip = sfx1;
            src.Play();
            muzzleFlash.Play();
            Shoot();
            /// End of attack code
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); // Use "ResetAttack" instead of "Reset1Attack"
        }
    }
}

private void ResetAttack() // Method name corrected
{
    alreadyAttacked = false;
}
    
        
    
    
    
    void Shoot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            // getting the target script so i can use variables inside it
            EnemyAi Target = hit.transform.GetComponent<EnemyAi>();
            
            if (Target != null)
            {
                
                Target.TakeDamage(damage);
            
            }
        
        
        }
        
    
    
    }
    
    public void TakeDamage1(float damage1)
    {
        playerHealth -= damage1;
        
        if (playerHealth <= 0)
        {
        
            Destroyplayer();
        
        }
    }
    
    void Destroyplayer()
    {
       
       Destroy(player.gameObject); 
    
    }

}
