using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour {

    private SpriteRenderer starR;
    private float _movenSpeed = 0.2f;


    void Start () {
        starR = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 5f);
	}
		
	void Update () {
        starR.color = new Color(starR.color.r, starR.color.g, starR.color.b, Mathf.PingPong(Time.time / 2.5f, 1f));

        //move star
        transform.position += transform.up * Time.deltaTime * _movenSpeed;
    }
}
