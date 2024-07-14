/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }




    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    
    
    
    
    }
}
*/








using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public float healthDecreaseRate = 1f; // Health decrease per second
    public float healthRegenRate = 5f; // Health regeneration per second
    public float healthRegenAmount = 20f; // Total health to regenerate

    private bool isRegenerating = false;


    // Static instance of HealthManager
    private static HealthManager instance;

    // Property to get the instance
    public static HealthManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Searching for an existing HealthManager instance in the scene
                instance = FindObjectOfType<HealthManager>();

                // If no instance exists, create a new GameObject and attach HealthManager to it
                if (instance == null)
                {
                    GameObject obj = new GameObject("HealthManager");
                    instance = obj.AddComponent<HealthManager>();
                }
            }
            return instance;
        }
    }









    void Start()
    {
        healthBar.fillAmount = healthAmount / 100f;
    }

    void Update()
    {
        DecreaseHealthOverTime();

        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        

    }

    // Decreases health over time
    void DecreaseHealthOverTime()
    {
        if (!isRegenerating)
        {
            healthAmount -= healthDecreaseRate * Time.deltaTime;
            healthAmount = Mathf.Clamp(healthAmount, 0, 100);
            healthBar.fillAmount = healthAmount / 100f;
        }
    }

    // Starts the health regeneration process
    public void StartHealthRegen()
    {
        if (!isRegenerating)
        {
            StartCoroutine(RegenerateHealth());
        }
    }

    // Coroutine to regenerate health over time
    IEnumerator RegenerateHealth()
    {
        isRegenerating = true;
        float totalRegen = 0f;

        while (totalRegen < healthRegenAmount)
        {
            float regen = healthRegenRate * Time.deltaTime;
            healthAmount += regen;
            healthAmount = Mathf.Clamp(healthAmount, 0, 100);
            healthBar.fillAmount = healthAmount / 100f;
            totalRegen += regen;
            yield return null; // Wait until the next frame
        }

        isRegenerating = false;
    }

    // Method to be called when an enemy is killed
    public void OnEnemyKilled()
    {
        StartHealthRegen();
    }
}
