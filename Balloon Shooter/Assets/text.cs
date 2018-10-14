using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Timer()
    {
        //destroy the Text after 4 seconds
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
