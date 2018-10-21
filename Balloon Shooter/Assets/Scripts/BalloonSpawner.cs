using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour {

    public GameObject Balloon;
    float maxSpawnRateInSeconds = 5f;


	// Use this for initialization
	void Start ()
    {
        Invoke("SpawnBalloon", maxSpawnRateInSeconds);

        //increase spawn rate every 5 seconds
        InvokeRepeating("IncreaseSpawnRate", 1f, 15f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SpawnBalloon()
    {
        //spawn the balloons at the bottom of the Camera view 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject aBallon = (GameObject)Instantiate(Balloon);
        aBallon.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

        ScheduleNextBalloonSpawn();
    }

    void ScheduleNextBalloonSpawn ()
    {
        float SpawnInSeconds;

        //pick a number between 1 and maxSpawnRateInSeconds and spawn 
        SpawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);       
        Invoke("SpawnBalloon", SpawnInSeconds);
    }

    //function to increase the difficulty of the game
    void IncreaseSpawnRate ()
    {
        maxSpawnRateInSeconds--;
        
        //limit on the difficultiness
        if (maxSpawnRateInSeconds == 0f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
          
    }
}
