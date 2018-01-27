using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

    public Image[] weaponSpots;
    public Sprite[] weaponOptions;
    public Button currentWeapon;
    public CyberTigerController tiger;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < weaponOptions.Length; i++)
        {
            weaponSpots[i].sprite = weaponOptions[i];
        }
        currentWeapon.image.sprite = weaponOptions[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void openButtonPress() {
        
    }
}
