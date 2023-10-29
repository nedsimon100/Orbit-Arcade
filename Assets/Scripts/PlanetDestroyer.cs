using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PlanetDestroyer : MonoBehaviour
{
    public GameObject CoM;
    public AudioSource crash;
    // Start is called before the first frame update
    private void Start()
    {
        CoM = GameObject.FindGameObjectWithTag("CoM");
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.position - CoM.transform.position).magnitude > 600)
        {
            Destroy(this.gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (this.gameObject.GetComponent<Rigidbody2D>().mass < collision.gameObject.GetComponent<Rigidbody2D>().mass)
        {
            
            collision.gameObject.GetComponent<Rigidbody2D>().mass += this.gameObject.GetComponent<Rigidbody2D>().mass;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(this.gameObject.GetComponent<Rigidbody2D>().velocity);
            Destroy(this.gameObject);
        }
        else
        {
            crash.Play();
        }

    }
}
