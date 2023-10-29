using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour
{
    const float G = 6.67408f;
    public Rigidbody2D rb;
    public static List<Attract> attractors;


    void FixedUpdate()
    {

        foreach(Attract att in attractors)
        {
            if(att != this)
            gravity(att);
        }
    }



    private void OnEnable()
    {
        if (attractors == null)
            attractors = new List<Attract>();

        attractors.Add(this);
    }
    private void OnDisable()
    {
        attractors.Remove(this);
    }

    void gravity(Attract objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
