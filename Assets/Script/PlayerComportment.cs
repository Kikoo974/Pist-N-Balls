using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComportment : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifepoint = 12;
    [SerializeField] Image[] lifes;
    bool black;
    Renderer mat;
    Color startColor;
    bool invicible = false;
    float speed;
    [SerializeField] GameManager gameManager;
    AudioSource hit;
    void Start()
    {
        mat = GetComponent<Renderer>();
        startColor = mat.material.color;
        hit = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Enemy"&& !invicible)
        {
            hit.Play();
            lifepoint--;
            lifes[lifepoint].enabled = false;
            invicible = true;
            StartCoroutine(HitPhase());

            if (lifepoint <= 0) GameOver();

        }
        /*if (collision.gameObject.tag == "Piston")
            speed = GetComponentInParent<Samurai>().speedCur; */

    }

    private void GameOver()
    {
        gameManager.GameFinish();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Piston")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    IEnumerator HitPhase()
       
    {
        int redo = 5;
        while(redo > 0)
        {
            mat.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(0.2f);
            mat.material.SetColor("_Color",startColor);
            yield return new WaitForSeconds(0.2f);
            redo--;

        }
        invicible = false;


    }
}
