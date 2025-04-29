using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AccordeonBehavior : MonoBehaviour
{
    public Slider HealthBarSlider;
    public GameObject winTextObject;

    
    float maxHealth = 100f;
    float minHealth = 0f;
    float currentHealth = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBarSlider != null)
        {
            UpdateHealthBar();
        }

        DamageOverTime(5, 10000);
        LockHealthAmt();
        GameOver();
    }

    public void UpdateHealthBar()
    {
        HealthBarSlider.maxValue = maxHealth;
        HealthBarSlider.value = currentHealth;
    }

    public void LockHealthAmt()
    {
        if (currentHealth < minHealth)
        {
            currentHealth = minHealth;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void DamageOverTime(int damageAmount, int damageTime)
    {
        StartCoroutine(DamageOverTimeCoroutine(damageAmount, damageTime));
    }

    IEnumerator DamageOverTimeCoroutine(float damageAmount, float duration)
    {
        float amountDamaged = 0f;
        float damagePerLoop = damageAmount / duration;
        while (amountDamaged < damageAmount)
        {
            currentHealth -= damagePerLoop;
            amountDamaged += damagePerLoop;
            yield return new WaitForSeconds(1f);
        }
    }

    public void GameOver()
    {
        if (currentHealth <= minHealth)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Game Over!";
        }
    }
}
