using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectDiomond : MonoBehaviour {

    public Text countDiomond; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {            
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("diomonds", PlayerPrefs.GetInt("diomonds") + 1);
            countDiomond.text = PlayerPrefs.GetInt("diomonds").ToString();
        }
    }

}
