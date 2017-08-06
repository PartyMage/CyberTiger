using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

    public Button bodyMod;
    public Button weaponMod;
    public Button powerMod;
    public int currentMod = 0;
    public Button[] upgrades = new Button[6];
    public Image[] bodyImages;
    public int[] bodyCosts;
    public Image[] weaponImages;
    public int[] weaponCosts;
    public Image[] powerImages;
    public int[] powerCosts;
    // Use this for initialization
    void Start () {
        BodyClick();
	}
	
	// Update is called once per frame
	void Update () {

    }
    // player clicks on the body mod button
    public void BodyClick() {
        for (int i = 0; i < upgrades.Length; i++) {
            upgrades[i].image = bodyImages[i];
        }
    }
    // player clicks on the weapon mod button
    public void WeaponClick() {
        for (int i = 0; i < upgrades.Length; i++) {
            upgrades[i].image = weaponImages[i];
        }

    }
    // player clicks on the battery mod button
    public void PowerClick() {
        for (int i = 0; i < upgrades.Length; i++) {
            upgrades[i].image = powerImages[i];
        }

    }

    public void upgradeClick() {

    }

}
