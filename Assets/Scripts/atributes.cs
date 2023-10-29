using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class atributes : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject CoM;
    public AudioSource woosh;
    public AudioSource crash;
    public bool sandbox = false;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        CoM = GameObject.FindGameObjectWithTag("CoM");
    }
    // Update is called once per frame
    void Update()
    {
        values();
    }
    public void values()
    {
        if (sandbox == false)
        {
            this.gameObject.transform.localScale = new Vector2(5+ rb.mass / 40, 5+ rb.mass / 40);
            Color colour = new Color(rb.mass / 200, 0.5f / rb.velocity.magnitude + 0.5f / rb.mass, (CoM.transform.position - this.transform.position).magnitude / 600);
            this.gameObject.GetComponent<TrailRenderer>().startColor = colour;
            this.gameObject.GetComponent<TrailRenderer>().endColor = colour;
            this.gameObject.GetComponent<SpriteRenderer>().color = colour;
            woosh.volume = (rb.mass * rb.velocity.magnitude) / 10000;
            crash.volume = (rb.mass * rb.velocity.magnitude) / 10000;
            woosh.pitch = (rb.velocity.magnitude) / rb.mass;
            crash.pitch = (rb.velocity.magnitude) / rb.mass;
        }
        else
        {
            this.gameObject.transform.localScale = new Vector2(5+rb.mass,5+ rb.mass);
            Color colour = new Color(0.2f+(rb.mass / 2), (rb.mass / 10) + (1/((CoM.transform.position - this.transform.position).magnitude+2f)), (CoM.transform.position - this.transform.position).magnitude / 600);
            this.gameObject.GetComponent<TrailRenderer>().startColor = colour;
            this.gameObject.GetComponent<TrailRenderer>().endColor = colour;
            this.gameObject.GetComponent<SpriteRenderer>().color = colour;
            woosh.volume = (rb.mass * rb.velocity.magnitude) / 10000;
            crash.volume = (rb.mass * rb.velocity.magnitude) / 10000;
            woosh.pitch = (rb.velocity.magnitude) / rb.mass;
            crash.pitch = (rb.velocity.magnitude) / rb.mass;
        }
        


    }
}
