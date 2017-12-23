using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour {
    [SerializeField]
    private Slider healthSlider;
    private int currentHealth;
    [SerializeField]
    private float speed = 5f;
    public bool IsOver {
        get {
            return currentHealth <= healthSlider.minValue;
        }
    }

    [ContextMenu("text Init 100")]
    private void textInit() {
        Init(100);
    }
    [ContextMenu("text Hurt 50")]
    private void textHurt() {
        Hurt(50);
    }

    public void Init(int maxHealth) {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        currentHealth = maxHealth;
    }

    public void Hurt(int damege) {
        currentHealth -= damege;
        currentHealth = (int)Mathf.Max(currentHealth, healthSlider.minValue);  //當前生命>最小生命0 
    }

    private void Update() {
        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime * speed);
    }
}
