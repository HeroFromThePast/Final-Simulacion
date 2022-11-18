using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI enemiesCount;

    float time;

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 70)
        {
            gameOverCanvas.SetActive(true);
            player.SetActive(false);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
