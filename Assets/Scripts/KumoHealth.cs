using System.Collections;
using UnityEngine;

public class KumoHealth : MonoBehaviour
{
   
   public int maxHealth = 100;
   public int currentHealth;
   
   public float invincibilityTimeAfterHit = 3f;
   public float flashDelay = 0.2f;
   public bool invincible = false;

   public SpriteRenderer sr;

   public HealthBar healthBar;

   public static KumoHealth instance;

    private void Awake()
    {
      
      if(instance != null)
      {
        Debug.LogWarning("Il y'a plus d'une instance de KumoHealth dans la scène");
        return;
      }

      instance = this;
    }
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }
    void Update()
    {
      if(Input.GetKey(KeyCode.H))
      {
        TakeDamage(60);
      }
    }
    
    public void HealPlayer(int amount)
    {
      if((currentHealth + amount) > maxHealth)
      {
        currentHealth = maxHealth;
      }else
      {
        currentHealth += amount;
      }

      healthBar.SetHealth(currentHealth);
    }
    
    public void TakeDamage(int damage)
    {
        if(!invincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            
            if(currentHealth <= 0)
            {
              isDead();
              return;
            }

            invincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(invincibleDelay());
            
        }
        
    }

    public void isDead()
    {
      Debug.Log("Le joueur est éliminé");
      KumoMovement.instance.enabled = false;
      KumoMovement.instance.animator.SetTrigger("isDead");
      KumoMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
      KumoMovement.instance.kumoCollider.enabled = false;
      GameOver.instance.OnPlayerDeath();
    }

    public IEnumerator InvincibilityFlash()
  {
    while (invincible)
    {
      sr.color = new Color(1f, 1f, 1f, 0f);
      yield return new WaitForSeconds(flashDelay);
      sr.color = new Color(1f, 1f, 1f, 1f);
      yield return new WaitForSeconds(flashDelay);
    }
  }

  public IEnumerator invincibleDelay()
  {
      yield return new WaitForSeconds(invincibilityTimeAfterHit);
      invincible = false;
  }
}
