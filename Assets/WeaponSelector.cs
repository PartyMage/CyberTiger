using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

    public Image[] weaponSpots;
    public Sprite[] weaponOptions;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < weaponOptions.Length; i++)
        {
            weaponSpots[i].sprite = weaponOptions[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
