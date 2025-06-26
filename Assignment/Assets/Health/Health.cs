using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float startingHealth;
    private float CurrentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    private void Awake()
    {
        CurrentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth > 0)
        {
        }
        else
        {
        }
    }
}
