using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ballon : MonoBehaviour
{


    public GameObject[] wayPoints;

    private int nextWayPointIndex = 0;

    
    
    public int health = 1;

    public float speed = 1;

    private Material m_Material;

    public Counter counter;
    public Counter healthCounter;

    public GameObject counter2;

 //   public Text CounterText;
    private void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        
        wayPoints = GameObject.FindGameObjectsWithTag("Waypoints"); 
        counter = GameObject.FindGameObjectWithTag("counter").GetComponent<Counter>();
        healthCounter = GameObject.FindGameObjectWithTag("gameOver").GetComponent<Counter>();




    }


    // Update is called once per frame
    void Update()
    {
        MoveBallon();

        if (health == 3)
        {
            m_Material.color = Color.red;
        }
        else if (health == 2)
        {
            m_Material.color = Color.blue;
        }
        else if (health == 1)
        {
            m_Material.color = Color.green;
        }
        if (OVRInput.GetDown(OVRInput.Button.One,OVRInput.Controller.LTouch))
        {
            print("Test");
            SceneManager.LoadScene("SampleScene");
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Dart")) return;
        health--;
         
            
        if (health <= 0)
        {
            counter.DestroyBallon();
            //CounterText.text = " Ballon Counter " + counter.ToString(); 
            Destroy(this.gameObject);
        }
    }

    
    private void MoveBallon()
    {
        var lastWayPointIndex = wayPoints.Length - 1;
        Vector3 lastWayPoint = wayPoints[lastWayPointIndex].transform.position + new Vector3(0,2,0);
        Vector3 nextWayPoint = wayPoints[nextWayPointIndex].transform.position+ new Vector3(0,2,0);
        Vector3 direction = nextWayPoint - transform.position;


        if (Vector3.Distance(transform.position, lastWayPoint)> 0.1f)
        {
            transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World);
        }

        if (Vector3.Distance(transform.position, nextWayPoint)< 0.5f && nextWayPointIndex < lastWayPointIndex)
        {
            nextWayPointIndex++;
        }

        if (nextWayPointIndex == lastWayPointIndex && Vector3.Distance(transform.position,lastWayPoint) < 0.5f)
        {

           
            
            Destroy(this.gameObject);
            healthCounter.HealthCount();
            print("Balloon: " + healthCounter.getHp());
            if (healthCounter.getHp() == 0)
            {
                print("Game over");
                healthCounter.gameOver();

                StartCoroutine(waiter());
              
                

            }
        }
        
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
    }
}
