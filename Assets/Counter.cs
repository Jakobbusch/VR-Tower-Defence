using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    public GameObject counter;
    public Text CounterText;
    public Text gameOverText;
    private Ballon _ballon;

    public int playerHealth = 10;
    public int _counter;





    //public Event _event;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        gameOverText.text = "Game Over! Press X to restart";
    }
    public int getHp()
    {
        return playerHealth;
    }

    public void HealthCount()
    {
        playerHealth--;
        print(playerHealth);
    }
    public void DestroyBallon()
    {
        _counter++;
        CounterText.text = "Ballon Count: " + _counter;
        
    }
}
