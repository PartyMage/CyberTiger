using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

    public Image[] weaponSpots;
    public Sprite[] weaponOptions;
    public Button currentWeapon;
    public CyberTigerController tiger;

    RectTransform weaponSelectorTransorm;
    bool isWeaponDrawerOpen;
    bool weaponPanelMovement;
    float weaponPanelPosition;

    // Use this for initialization
    void Start ()
    {
        weaponSelectorTransorm = this.GetComponent<RectTransform>();
        weaponPanelPosition = -weaponSelectorTransorm.rect.width;
        weaponSelectorTransorm.anchoredPosition = new Vector2(weaponPanelPosition, 0);
        isWeaponDrawerOpen = false;
        weaponPanelMovement = false;
        for (int i = 0; i < weaponOptions.Length; i++)
        {
            weaponSpots[i].sprite = weaponOptions[i];
        }
        currentWeapon.image.sprite = weaponOptions[0];
	}
	
	// Update is called once per frame
	void Update () {
        if(weaponPanelMovement != false)
        {
            if(isWeaponDrawerOpen == true)
            {
                weaponPanelPosition += weaponSelectorTransorm.rect.width * (Time.deltaTime*4);
                if (weaponPanelPosition >= 0)
                {
                    weaponPanelMovement = false;
                    weaponPanelPosition = 0;
                }
            }
            else if(isWeaponDrawerOpen == false)
            {
                weaponPanelPosition -= weaponSelectorTransorm.rect.width * (Time.deltaTime*4);
                if (weaponPanelPosition <= -weaponSelectorTransorm.rect.width)
                {
                    weaponPanelMovement = false;
                    weaponPanelPosition = -weaponSelectorTransorm.rect.width;
                }
            }

            weaponSelectorTransorm.anchoredPosition = new Vector2(weaponPanelPosition, 0);
        }
    }

    public void OpenCloseButtonPress()
    {
        if(isWeaponDrawerOpen == false)
        {
            OpenWeapons();
        }
        else
        {
            CloseWeapons();
        }
    }

    public void OpenWeapons()
    {
        weaponPanelMovement = true;
        isWeaponDrawerOpen = true;
    }

    public void CloseWeapons()
    {
        weaponPanelMovement = true;
        isWeaponDrawerOpen = false;
    }

    public void WeaponSelect()
    {
        Weapon buttonClick = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Weapon>();
        switch (buttonClick.weaponNumber)
        {
            case 0:
                tiger.currentEnergyCost = 6;
                tiger.currentShot = tiger.weapon[0];
                break;
            case 1:
                tiger.currentEnergyCost = 8;
                tiger.currentShot = tiger.weapon[1];
                break;
            case 2:
                tiger.currentEnergyCost = 8;
                tiger.currentShot = tiger.weapon[2];
                break;
            case 3:
                tiger.currentEnergyCost = 20;
                tiger.currentShot = tiger.weapon[3];
                break;
            case 4:
                tiger.currentEnergyCost = 8;
                tiger.currentShot = tiger.weapon[4];
                break;
        }
    }

}
