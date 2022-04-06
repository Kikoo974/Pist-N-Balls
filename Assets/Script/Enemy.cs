using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float pattern = 0;
    public Transform posLeft, posRight;
    bool left = true;
    public float xOffset = 0;
     float rot;
    public int which;
    public float startRot;
    [SerializeField] GameObject[] sides;

    void Start()
    {
        transform.position += new Vector3(xOffset, 0, 0);
        switch(pattern)
        {
            case 1:
                StartCoroutine(Rightleft());
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0, startRot, 0);
                StartCoroutine(Rotate());
                break;
            case 3:
                SetSides();
                StartCoroutine(OpenSide(which));
                break;
            default:
                break;
        }
    }
    void SetSides()
    {
        switch(which)
        {
            case 0:
                sides[1].transform.position = new Vector3(sides[1].transform.position.x, -1f, sides[1].transform.position.z);
                sides[2].transform.position = new Vector3(sides[2].transform.position.x, -1f, sides[2].transform.position.z);
                break;
            case 1:
                sides[0].transform.position = new Vector3(sides[0].transform.position.x, -1f, sides[0].transform.position.z);
                sides[2].transform.position = new Vector3(sides[2].transform.position.x, -1, sides[2].transform.position.z);
                break;
            case 2:
                sides[1].transform.position = new Vector3(sides[1].transform.position.x, -1f, sides[1].transform.position.z);
                sides[0].transform.position = new Vector3(sides[0].transform.position.x, -1f, sides[0].transform.position.z);
                break;
        }
    }
   

    void Update()
    {
        transform.position -= new Vector3(0, 0, speed) * Time.deltaTime;
    }
    private IEnumerator Rightleft()
    {
        while (true)
        {
            if(left)  
            {
                transform.position -= new Vector3(speed/5, 0, 0) * Time.deltaTime;
                if (transform.position.x < posLeft.transform.position.x) left = false;
            }
            else
            {
                transform.position += new Vector3(speed / 5, 0, 0) * Time.deltaTime;
                if (transform.position.x > posRight.transform.position.x) left = true;
            }
            yield return new WaitForEndOfFrame();
            Debug.Log("++");
        }
    }
    private IEnumerator Rotate()
    {
       
       while(true)
        {
            rot += 1* Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, transform.rotation.y + rot * speed*5, 0);
            yield return new WaitForEndOfFrame();
        }
    }
    private IEnumerator OpenSide(int num)
    {
        while(sides[num].transform.position.y > -1f)

        {
            sides[num].transform.position -= new Vector3(0, Time.deltaTime * speed/3, 0);
            if (num == 0)
            {
                sides[1].transform.position += new Vector3(0, Time.deltaTime * speed/3, 0);

            }
            else if (num == 1)
            {
                Debug.Log("wtf");
                sides[2].transform.position += new Vector3(0, Time.deltaTime * speed/3, 0);
            }
            else
            {
                sides[0].transform.position += new Vector3(0, Time.deltaTime * speed/3, 0);
            }
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.5f);
        if (num == 2)
            StartCoroutine(OpenSide(0));
        else
            StartCoroutine(OpenSide(num + 1));
               
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
            Destroy(gameObject);
    }*/

    // Update is called once per frame

}
