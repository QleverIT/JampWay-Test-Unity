using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    public GameObject shopCubes;
    private Vector3 screenPoint, offset;
    private float _lokedYPos;

    private void Start()
    {
        _lokedYPos = shopCubes.transform.position.y;
    }

    void Update () {
		if(shopCubes.transform.position.x > 0)
        {
            shopCubes.transform.position = Vector3.MoveTowards(shopCubes.transform.position, new Vector3(0f, shopCubes.transform.position.y, shopCubes.transform.position.z), Time.deltaTime*10f);
        }
        else if (shopCubes.transform.position.x < -8f)
        {
            shopCubes.transform.position = Vector3.MoveTowards(shopCubes.transform.position, new Vector3(-8f, shopCubes.transform.position.y, shopCubes.transform.position.z), Time.deltaTime * 10f);
        }
    }

    private void OnMouseDown()
    {
        //_lokedYPos = screenPoint.y;
        offset = shopCubes.transform.position - Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToViewportPoint(curScreenPoint) + offset;
        curPosition.y = _lokedYPos;
        shopCubes.transform.position = curPosition;
    }
    private void OnMouseUp()
    {
        Cursor.visible = true;
    }
}
