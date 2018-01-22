using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandColor : MonoBehaviour {

    private Color[][] colors;
    public Color[] colorSky;
    public Color[] colorSky2;
    public Color[] colorSky3;
    int controlTheme;

    void Start () {
        colors = new Color[RandBG.materialCount][];
        colors[0] = colorSky;
        colors[1] = colorSky2;
        colors[2] = colorSky3;
        GetComponent<MeshRenderer>().material.color = colors[PlayerPrefs.GetInt("CountColor")][Random.Range(0,colors[PlayerPrefs.GetInt("CountColor")].Length)];
        controlTheme = PlayerPrefs.GetInt("CountColor"); 
    }
    /*private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "block" && GetComponent<MeshRenderer>().material.color== other.gameObject.GetComponent<MeshRenderer>().material.color)
            GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
    }*/

    private void Update()
    {
        if (controlTheme != PlayerPrefs.GetInt("CountColor"))
        {
            controlTheme = PlayerPrefs.GetInt("CountColor");
            GetComponent<MeshRenderer>().material.color = colors[PlayerPrefs.GetInt("CountColor")][Random.Range(0, colors[PlayerPrefs.GetInt("CountColor")].Length)];
        }
    }
}
