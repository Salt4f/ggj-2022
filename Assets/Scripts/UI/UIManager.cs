using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public TMP_Text healthText;
    public Slider armorBar;
    public TMP_Text armorText;

    public Image face;
    public Sprite ninjaFace;
    public Sprite samuraiFace;
    

    void Awake()
    {
        GameManager.instance.uiManager = this;
    }

    public void UpdatePlayerHealth(int currentHealth, int maxHealth) 
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    public void UpdatePlayerArmor(int currentArmor, int maxArmor)
    {
        armorBar.maxValue = maxArmor;
        armorBar.value = currentArmor;
        armorText.text = currentArmor.ToString() + "/" + maxArmor.ToString();
    }

    public void ChangeFace(bool samurai)
    {
        if (samurai) face.sprite = samuraiFace;
        else face.sprite = ninjaFace;
    }

}
