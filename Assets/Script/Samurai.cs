using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Samurai : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedY = 5f, speedX =5f;
    public float speedCur;
    [SerializeField] GameObject pistL, pistR;
    Button a;
    bool isPress = false;
    GameObject cur;
    AudioSource piston;
    
    void Start()
    {
        piston = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
       if(isPress)
        {
            cur.transform.position += new Vector3(speedCur, 0, 0) * Time.deltaTime;
            piston.Play();
        }
      
    }
    public void OnCLick(int i)
    {
        switch(i)
        {
            case 0:
                cur = pistL;
                cur.GetComponent<Psiton>().speed = 0;
                speedCur = +speedX;
                break;
            case 1:
                cur = pistR;
                cur.GetComponent<Psiton>().speed = 0;
                speedCur = -speedX;
                break;
 
        }
        isPress = true;
    }
    
    public void OnReal()
    {
        isPress = false;
        cur.GetComponent<Psiton>().speed = speedCur/2;
        

    }
}
