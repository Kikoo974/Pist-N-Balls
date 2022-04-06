using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ground, pause, gameOver, start, global;
    [SerializeField] Text scoreText, bestScoreText, gameOverscore, gameOverBestScore;
    PlayerPrefs bestScore;
    Renderer texRend;
    public float speed = 1.0f;
    public float speedMult = 0.5f;
    float scroll;
    float timer = 5f;
    float score = 0;
    void Start()
    {
        Time.timeScale = 0;
        texRend = ground.GetComponent<Renderer>();
        if (PlayerPrefs.HasKey("BPR"))
            bestScoreText.text = "Best : " + PlayerPrefs.GetFloat("BPR");
        else
            bestScoreText.text = "Best : 0";
    }

    // Update is called once per frame
    void Update()
    {
        scroll = Time.time * speed;
        texRend.material.SetTextureOffset("_MainTex", new Vector2(0, -scroll)) ;
        timer -= Time.deltaTime;
        if (timer < 0 && speedMult > 0.4f)
        {
          
            speedMult -= 0.05f;
            timer = 2.0f; 
        }
        score += Time.deltaTime *10 /speedMult;
        scoreText.text = "Score : " + (int)score;

    }
    public void GameFinish()
    {
        if (PlayerPrefs.GetFloat("BPR") < score)
            PlayerPrefs.SetFloat("BPR", (int)score);
        if (PlayerPrefs.HasKey("BPR"))
            gameOverBestScore.text = "Best : " + PlayerPrefs.GetFloat("BPR");
        gameOverscore.text = "Score : " + (int)score;
        gameOver.SetActive(true);
        global.SetActive(false);
        
        Time.timeScale = 0;
    }
    public void OnClick(int i)
    {
        switch(i)
        {
            case 0:
                pause.SetActive(true);
                Time.timeScale = 0;
                break;
            case 1:
                pause.SetActive(false);
                Time.timeScale = 1;
                break;
            case 2:
                Application.Quit();
                break;
            case 3:
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
                break;
            case 4:
                global.SetActive(true);
                start.SetActive(false);
                Time.timeScale = 1;
                break;
               
        }
    }
}
