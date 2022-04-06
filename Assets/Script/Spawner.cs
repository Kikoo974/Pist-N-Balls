using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pos1, pos2;
    float timer = 0;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] enemies;
    int rangeMin =3, rangeMax =5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {
            int toInst = Random.Range(0, enemies.Length);
            GameObject ar = Instantiate(enemies[toInst], transform.position, Quaternion.identity);
            Enemy curEn = ar.GetComponent<Enemy>();
            //curEn.speed = curEn.speed/2;
            //curEn.speed = (curEn.speed / gameManager.speedMult) *2;
            curEn.posLeft = pos1;
            curEn.posRight = pos2;
            if (curEn.pattern == 1) curEn.xOffset = Random.Range(-3.0f, 3.0f);
            else if(curEn.pattern==2)
            {
                curEn.xOffset = Random.Range(-3.0f, 3.0f);
                curEn.startRot = Random.Range(0f, 360f);
            }
            else if(curEn.pattern == 3)
            {
                curEn.which = Random.Range(0, 3);
            }

            timer = Random.Range(rangeMin*gameManager.speedMult, rangeMax*gameManager.speedMult);
        }
    }
}
