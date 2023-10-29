using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject listener;
    private void Update()
    {
        Vector3 pos = new Vector3(0,0,0);
        float overallMass = 0;
        foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet"))
        {
            overallMass += planet.GetComponent<Rigidbody2D>().mass;
        }
        foreach (GameObject planet in GameObject.FindGameObjectsWithTag("Planet"))
        {
            pos += planet.transform.position * planet.GetComponent<Rigidbody2D>().mass / overallMass;
        }
        listener.transform.position = pos;
        pos.z = -10;

        this.GetComponent<Rigidbody2D>().velocity = pos-this.transform.position;
    }
}
