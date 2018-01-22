using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandBG : MonoBehaviour {

    public Material[] materials;
    public static int materialCount;
    int controlTheme;


    void Start () {
        materialCount = materials.Length;
        controlTheme = PlayerPrefs.GetInt("CountColor");
        GetComponent<Skybox>().material = materials[controlTheme];
        
    //GetComponent<Skybox>().material = materials[Random.Range(0,materials.Length)];        
}

    private void Update()
    {
        if(controlTheme != PlayerPrefs.GetInt("CountColor")){
            controlTheme = PlayerPrefs.GetInt("CountColor");
            GetComponent<Skybox>().material = materials[controlTheme];
        }
    }

}
