using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public Image jumpImage;
    public Image fireImage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public void JumpClick() {
        jumpImage.gameObject.SetActive(false);
    }

    public void FireClick() {
        fireImage.gameObject.SetActive(false);

    }
}
