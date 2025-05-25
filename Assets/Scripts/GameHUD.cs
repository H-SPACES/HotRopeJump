using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    public TextMeshProUGUI jumpText;
    public TextMeshProUGUI timeText;
    

    private int jumpCount = 0;
    private float elapsedTime = 0f;

    

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timeText.text = "Time: " + elapsedTime.ToString("F2") + "s";
    }

    public MarioJump MarioJump;

    public void AddJump()
    {

        jumpCount++;
        jumpText.text = "Jump: " + jumpCount;

        if (jumpCount >= 5)
        {
            MarioJump.WinnerEnd();
        }
    }
    
}
