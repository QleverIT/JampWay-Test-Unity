using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour {

    Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
        txt.text = "Top: " + PlayerPrefs.GetInt("topNext").ToString();
    }

    void Update () {
        if (PlayerPrefs.GetInt("topNext") < cubeJamp.countBlock)
        {
            PlayerPrefs.SetInt("topNext", cubeJamp.countBlock);
            txt.text = "Top: " + PlayerPrefs.GetInt("topNext").ToString();
        }
            

    }
}
