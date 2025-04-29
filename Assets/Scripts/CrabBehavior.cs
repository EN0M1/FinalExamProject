using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CrabBehavior : MonoBehaviour
{
    public Slider HealthBarSlider;
    public GameObject winTextObject;

    float maxHealth = 100f;
    float minHealth = 0f;
    float currentHealth = 100f;
    public int damage = 1;
    public bool damaged = false;

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

        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            TakeDamage(damage);
        }

        LockHealthAmt();
        PlayerWins();
    }

    public void UpdateHealthBar()
    {
        HealthBarSlider.maxValue = maxHealth;
        HealthBarSlider.value = currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        damaged = true;

        if (currentHealth > minHealth)
        {
            currentHealth = currentHealth - damageAmount;
        }
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

    public void PlayerWins()
    {
        if (currentHealth <= minHealth)
        {
            winTextObject.SetActive(true);
        }
    }
}
