using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject playButton;

    void Start()
    {
        Time.timeScale = 0f;  // Pausa el juego
    }

    public void StartGame()
    {
        Time.timeScale = 1f;            // Reanuda el juego
        
        playButton.SetActive(false); // Oculta solo el botón
    }
}
