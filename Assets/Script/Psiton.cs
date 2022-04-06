using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psiton : MonoBehaviour
{
    // Start is called before the first frame updatepubli
    public float speed;
    public int oneLinus = 1;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
            transform.position -= new Vector3(speed*oneLinus, 0, 0) * Time.deltaTime;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
            speed = 0;
            
    }
}
