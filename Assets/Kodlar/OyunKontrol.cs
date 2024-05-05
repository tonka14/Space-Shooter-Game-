using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{

    public GameObject[] Asteroidler;

    Vector3 vec;

    public Text text;
    int score = 0;

    bool GameOver = false;
    public Text OyunBittiText;
    
   

    void Start()
    {
        StartCoroutine(Olustur());
        PlayerPrefs.SetInt("kalan", SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && GameOver)
        {
            SceneManager.LoadScene("level 1");
        }
    }

    //random asteroid oluşturma 
    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {              
                int ast = Random.Range(1, 3);
                vec = new Vector3(Random.Range(-6, 6), 0, 12);
                Instantiate(Asteroidler[Random.Range(0, 3)], vec, Quaternion.identity);
                yield return new WaitForSeconds(1);
                
            }
            if (GameOver == true)
            {
                break;
            }
            yield return new WaitForSeconds(5);

            
        }
    }
   
    //Skor
    public void ScoreArttir(int gelenscore)
    {
        score = score + gelenscore;

        text.text = "Score : "+ score;
    }
    //OyunBitti
    public void OyunBitti()
    {
        OyunBittiText.text = "OYUN BİTTİ";
        GameOver = true;
    }

}
