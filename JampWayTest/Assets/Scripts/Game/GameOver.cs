using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public GameObject buttom, buttom_lose, bg;//, fon2
    public Text gameName;
	
	
	
	void Update () {
        if (cubeJamp.gameOver)
        {
            
            buttom.GetComponent<ScrollObjects>().checkPos = 120;
            buttom.GetComponent<ScrollObjects>().speed = 5f;
            if (!buttom_lose.activeSelf && !bg.activeSelf)
                buttom_lose.SetActive(true);
            buttom_lose.GetComponent<ScrollObjects>().checkPos = 200;
            /*if (!fon2.activeSelf)
                fon2.SetActive(true);*/
            gameName.GetComponent<ScrollObjects>().checkPos = -65;
            gameName.text = "Game Over";

            //aweke в скрипте kube_jamp
            /*cubeJamp.nextBlock = false;
            cubeJamp.jamp = false;*/
            
        

        }
	}
}
