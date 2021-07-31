using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]

    public int startingHealth = 100;
    public int currentHealth;


    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
