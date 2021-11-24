using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    public float difficulty = 0.2f;
    public float difficultyIncreaseSpeed = 0.01f;
    public Transform startPosition;
    public GameObject ballonGreen;

    public int playerHealth = 10;

    private float ballonTimer = 0f;
    private float nextBallon = 1f;

    private float waveTimer = 0;
    private float nextWave = 1;
    public int ballonPerWave = 20;
    private int ballonCount = 1;
    
    // Update is called once per frame
    void Update()
    {
        
        if (ballonTimer < Time.time && waveTimer < Time.time)
        {
            ballonCount++;
            var ballon = Instantiate(ballonGreen, startPosition.position, ballonGreen.transform.rotation);
            
            difficulty += difficultyIncreaseSpeed;
            waveTimer = Time.time + nextWave;
           
            
            ballon.GetComponent<Ballon>().health += (int) System.Math.Round(difficulty);
            ballon.GetComponent<Ballon>().speed += (int) System.Math.Round(difficulty);
          
        }

        if (ballonCount % ballonPerWave == 0 && waveTimer < Time.time)
        {
            waveTimer = nextWave + Time.time;
        }
        
    }
}
