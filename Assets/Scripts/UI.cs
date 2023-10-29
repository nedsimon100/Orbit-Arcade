using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public int points = 0;
    private bool paused = false;
    public GameObject normalUI;
    public GameObject pauseUI;
    public GameObject scoringUI;
    public GameObject Settings;
    public GameObject MainMenu;
    public TextMeshProUGUI score;
    public TextMeshProUGUI TimeLeft;
    bool fast = false;

    public void quit()
    {
        Application.Quit();
    }
    public void Done()
    {
        Destroy(GameObject.FindGameObjectsWithTag("Planet")[GameObject.FindGameObjectsWithTag("Planet").Length-1]);
        StartCoroutine("ffwd");
    }
    public void fastTime()
    {
        if(fast == false)
        {
            fast = true;
            Time.timeScale = 10f;
            normalUI.SetActive(false);
            pauseUI.SetActive(false);
            scoringUI.SetActive(true);
        }
        else
        {
            fast = false;
            Time.timeScale = 1f;
            normalUI.SetActive(true);
            pauseUI.SetActive(false);
            scoringUI.SetActive(false);
        }
    }
    IEnumerator ffwd()
    {
        normalUI.SetActive(false);
        pauseUI.SetActive(false);
        scoringUI.SetActive(true);
        Time.timeScale = 10f;
        int startplanets = GameObject.FindGameObjectsWithTag("Planet").Length;
        int currentPlanets = GameObject.FindGameObjectsWithTag("Planet").Length;

        for (int x = 40; x > -1; x--)
        {
            //if (GameObject.FindGameObjectsWithTag("Planet").Length < 1 || startplanets/2 > GameObject.FindGameObjectsWithTag("Planet").Length)
            //{
            //    bonus = false;
            //    x = -1;
            //}
            if (GameObject.FindGameObjectsWithTag("Planet").Length < 1)
            {
                x = -1;
            }
            else
            {
               // foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet"))
               // {
               //     points += Mathf.RoundToInt(1000 / planet.transform.position.magnitude);
               // }
                if (GameObject.FindGameObjectsWithTag("Planet").Length < currentPlanets)
                {
                    points += -100 * (currentPlanets - GameObject.FindGameObjectsWithTag("Planet").Length);
                    currentPlanets = GameObject.FindGameObjectsWithTag("Planet").Length;
                }
                points += 10 * GameObject.FindGameObjectsWithTag("Planet").Length;
                score.text = points.ToString();
                TimeLeft.text = (Mathf.Round(x / 2)).ToString();
                yield return new WaitForSeconds(5f);
            }
        }

        Time.timeScale = 2f;
        points += 100 * GameObject.FindGameObjectsWithTag("Planet").Length;
        TimeLeft.text = "SIMULATION COMPLETE";
    //    if (bonus == true)
    //    {
    //        points += 1000 * GameObject.FindGameObjectsWithTag("Planet").Length;
    //        TimeLeft.text = "SIMULATION COMPLETE";
    //    }
    //    else
    //    {
    //        points -= 1000 * startplanets-GameObject.FindGameObjectsWithTag("Planet").Length;
    //        TimeLeft.text = "LOST TOO MANY PLANETS";
    //    }
        score.text = points.ToString();
        
    }

    public void destroyAll()
    {
        normalUI.SetActive(true);
        pauseUI.SetActive(false);
        scoringUI.SetActive(false);
        points = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void Sandbox()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void PauseOrPlay()
    {
        if(paused == false)
        {
            paused = true;
            normalUI.SetActive(false);
            scoringUI.SetActive(false);
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            paused = false;
            normalUI.SetActive(true);
            pauseUI.SetActive(false);
            scoringUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
