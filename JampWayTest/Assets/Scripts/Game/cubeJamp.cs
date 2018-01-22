using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeJamp : MonoBehaviour {
    public GameObject m_cube;
    public static bool nextBlock, jamp, gameOver;
    private bool animate, lose;
    private float sctatch_speed = 0.5f, starTime, yPos;
    public static int countBlock;

    private void Awake()
    {
        nextBlock = false;
        jamp = false;
        gameOver = false;
    }

    private void Start()
    {
        StartCoroutine(CanJamp());
    }

    void FixedUpdate()
    {
        gameOver = lose;
        if (m_cube != null && m_cube.GetComponent<Rigidbody>())
        {            
            if (animate && m_cube.transform.localScale.y >= 0.4f)            
                pressCube(-sctatch_speed);   
           
            else if (!animate)
                if (m_cube.transform.localScale.y < 1f)
                    pressCube(sctatch_speed * 3f); 
            
                else if (m_cube.transform.localScale.y != 1f)
                    m_cube.transform.localScale = new Vector3(1f, 1f, 1f);
            if (m_cube.transform.position.y < -8.4f)
            {
                Destroy(m_cube);
                print("Game Over");
                lose = true;
            }
        }        
    }

    void OnMouseDown()
    {
        if (nextBlock && m_cube.GetComponent<Rigidbody>())
        {
            animate = true;
            starTime = Time.time;
            yPos = m_cube.transform.position.y;
        }
    }

    private void OnMouseUp()
    {
        if (animate && m_cube != null && m_cube.GetComponent<Rigidbody>() && nextBlock)
        {
            animate = false;

            //jamp
            jamp = true;
            float force, diff;
            diff = Time.time - starTime;
            if (diff < 3f)
                force = 190 * diff;
            else force = 300f;
            if (force < 60f) force = 60f;

            m_cube.GetComponent<Rigidbody>().AddRelativeForce(m_cube.transform.up * force);
            m_cube.GetComponent<Rigidbody>().AddRelativeForce(m_cube.transform.right * force);

            StartCoroutine(CheckCubePos());
            nextBlock = false;
        }
    }

    void pressCube(float force)
    {
        m_cube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        m_cube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }

    IEnumerator CheckCubePos()
    {
        yield return new WaitForSeconds(1f);
        if (yPos == m_cube.transform.position.y)
        {
            print("Player lose");
            lose = true;
        }

        else
        {
            while (!m_cube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (m_cube == null) break;
            }
            if (!lose)
            {
                nextBlock = true;
                print("next one");
                countBlock++;
                m_cube.transform.localPosition = new Vector3(m_cube.transform.localPosition.x, m_cube.transform.localPosition.y, 0f);
                m_cube.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            }
        }
    }
    
    IEnumerator CanJamp()
    {
        /*while(PlayGame.starGame)
            yield return new WaitForSeconds(0.05f);*/
        if (m_cube != null)
        {
            while (!m_cube.GetComponent<Rigidbody>())
                yield return new WaitForSeconds(0.05f);
            yield return new WaitForSeconds(1f);
            nextBlock = true;
        }
    }    
}
