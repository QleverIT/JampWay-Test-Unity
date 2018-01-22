using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class okCube : MonoBehaviour
{

    public GameObject selectCube;

    
    private void OnMouseDown()
    {
        PlayerPrefs.SetString("nowCube", selectCube.GetComponent<SelectCube>().nowCube);
        
    }
}
