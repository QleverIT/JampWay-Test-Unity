using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class countDiamond : MonoBehaviour {

    private Text txt;
	
	void Start () {
        txt = GetComponent<Text>();
        txt.text = PlayerPrefs.GetInt("diomonds").ToString();
	}
    
}
