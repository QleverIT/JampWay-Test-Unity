using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBG : MonoBehaviour {

    public GameObject Plane, tap, loseButton, button, shop; //, shopCubes, scroll;   

    private void OnEnable()
    {
        //Plane.SetActive(false);
        Plane.GetComponent<BoxCollider>().enabled = false;
        tap.SetActive(false);
        //shopCubes.SetActive(true);
        //scroll.SetActive(true);
        button.SetActive(false);//*
        shop.SetActive(true);
        loseButton.SetActive(false);
        
            
    }
    
    private void OnDisable()
    {
        //Plane.SetActive(true);
        button.SetActive(true);//*
        Plane.GetComponent<BoxCollider>().enabled = true;
        shop.SetActive(false);
        //scroll.SetActive(false);
        //shopCubes.SetActive(false);
        if (!cubeJamp.gameOver)        
            tap.SetActive(true);        
    }


}
