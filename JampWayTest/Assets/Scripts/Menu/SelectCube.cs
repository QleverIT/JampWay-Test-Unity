using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCube : MonoBehaviour {

    public GameObject select, buy;
    public string nowCube;

    private void Start()
    {
        if (PlayerPrefs.GetString("Cube") != "open") { 
            PlayerPrefs.SetString("Cube", "open");
            PlayerPrefs.SetString("nowCube", "Cube");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        nowCube = other.gameObject.name;
        other.transform.localScale += new Vector3(0.3f,0.3f,0.3f);
        if(PlayerPrefs.GetString(other.gameObject.name) == "open")
        {
            select.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            select.SetActive(false);
            buy.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
    }
}
