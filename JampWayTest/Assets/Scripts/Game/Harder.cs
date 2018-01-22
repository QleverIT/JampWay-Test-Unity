using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour {

    private bool hards;
    public GameObject DetectClick;

    void Update() {
        if (cubeJamp.countBlock > 0)
        {
            if (cubeJamp.countBlock % 2 == 0 && !hards)
            {
                print("hard");
                Camera.main.GetComponent<Animation>().Play("Harder");                
                DetectClick.transform.position = new Vector3(9.09f, 1.4f, -4.88f);
                DetectClick.transform.eulerAngles = new Vector3(-60f, -58.31f, 0f);
                hards = true;
            }
            else if ( (cubeJamp.countBlock % 2) - 1 == 0 && hards)
            {
                print("easi");
                Camera.main.GetComponent<Animation>().Play("Easier");                
                DetectClick.transform.position = new Vector3(-0.03f,2.68f,-3.36f);
                DetectClick.transform.eulerAngles = new Vector3(90f, 0f, 0f);
                hards = false;
            }
        }
    }
}
