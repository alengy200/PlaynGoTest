using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {

    float speed;

    Animator anim;
    AudioSource source;
    public AudioClip boomSound;
    public AudioClip looseSound;

    // Use this for initialization
    void Start ()
    {
        anim = this.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        speed = 2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //the object's y value position is increasing
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;
   	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //when the obejct's and the finish empty object's collider meet 
        if (collision.gameObject.tag == "Finish")
        {
            ScoreScript.ScoreValue--;
            anim.SetInteger("BoomStage", 2);
            source.PlayOneShot(looseSound, 2F);
            StartCoroutine(Die());
        }
    }

    private void OnMouseDown()
    {
        //when you click on the object
        ScoreScript.ScoreValue++;
        StartCoroutine(Die());
        anim.SetInteger("BoomStage", 1);
        source.PlayOneShot(boomSound, 0.7F);
        GetComponent<CircleCollider2D>().enabled = false;

    }

    IEnumerator Die()
    {
        //delete the object
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

