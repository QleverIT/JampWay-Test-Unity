using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyCube : MonoBehaviour {

    public GameObject selectCube, ok;
    



    private void OnMouseDown()
    {
        if(PlayerPrefs.GetInt("diomonds") >= 10)
        {
            PlayerPrefs.SetString(selectCube.GetComponent<SelectCube>().nowCube, "open");
            ok.SetActive(true);
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("diomonds", PlayerPrefs.GetInt("diomonds") - 10);            
        }
    }
}
