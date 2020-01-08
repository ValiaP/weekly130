using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour
{
    public GameObject EndPanel;
    public GameObject Win,Lose;

    public Button Restart;


    public void End(bool isWin)
    {
        EndPanel.SetActive(true);

        if (isWin)
        {
            Win.SetActive(true);
            Lose.SetActive(false);

        }
        else
        {
            Win.SetActive(false);
            Lose.SetActive(true);

        }
        Time.timeScale = 0f;

    }

    // Start is called before the first frame update
    void Start()
    {
        Restart.onClick.AddListener(()=> {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
