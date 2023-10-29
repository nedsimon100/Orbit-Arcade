using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract1 : MonoBehaviour
{
    const float G = 6674.08f;
    public Rigidbody2D rb;
    public static List<Attract1> attractors;


    void FixedUpdate()
    {

        foreach(Attract1 att in attractors)
        {
            if(att != this)
            pull(att);
        }
    }



    private void OnEnable()
    {
        if (attractors == null)
            attractors = new List<Attract1>();

        attractors.Add(this);
    }
    private void OnDisable()
    {
        attractors.Remove(this);
    }

    void pull(Attract1 objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance < 5)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
