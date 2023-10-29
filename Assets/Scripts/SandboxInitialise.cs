using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SandboxInitialise : MonoBehaviour
{
    public Vector2 direction;
    public float mass = 3;
    public Vector2 mousePosition;
    public Camera sceneCamera;
    public GameObject Planet;
    public GameObject currentPlanet;
    public GameObject spawnIndicator;
    public TextMeshProUGUI planetsLeft;
    public GameObject listener;
    private Vector2 Follow;
    void Update()
    {

        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            spawnIndicator.transform.position = mousePosition;
            Follow = new Vector2(spawnIndicator.transform.position.x - listener.transform.position.x, spawnIndicator.transform.position.y - listener.transform.position.y);
        }
        if (Input.GetMouseButton(0) == true)
        {
            spawnIndicator.transform.position = new Vector2(listener.transform.position.x + Follow.x, listener.transform.position.y + Follow.y);
            spawnIndicator.GetComponent<LineRenderer>().sortingOrder = 1;
            spawnIndicator.GetComponent<LineRenderer>().material = new Material(Shader.Find("Sprites/Default"));
            spawnIndicator.GetComponent<LineRenderer>().material.color = new Color(1/ (new Vector2(mousePosition.x - spawnIndicator.transform.position.x, mousePosition.y - spawnIndicator.transform.position.y).magnitude/100),0.3f,0.6f);
            spawnIndicator.GetComponent<SpriteRenderer>().material.color = new Color(1 / (new Vector2(mousePosition.x - spawnIndicator.transform.position.x, mousePosition.y - spawnIndicator.transform.position.y).magnitude / 100), 0.3f, 0.6f);
            spawnIndicator.GetComponent<LineRenderer>().endWidth = 0;
            spawnIndicator.GetComponent<LineRenderer>().startWidth = 5;
            spawnIndicator.GetComponent<LineRenderer>().SetPosition(0, new Vector2(listener.transform.position.x + Follow.x, listener.transform.position.y + Follow.y));
            spawnIndicator.GetComponent<LineRenderer>().SetPosition(1, mousePosition);
            spawnIndicator.transform.localScale = new Vector2(5, 5);
        }

        if (Input.GetMouseButtonUp(0))
        {
            spawnIndicator.GetComponent<LineRenderer>().startWidth = 0;
            currentPlanet = Instantiate(Planet, spawnIndicator.transform.position, this.transform.rotation);
            currentPlanet.GetComponent<Rigidbody2D>().AddForce(new Vector2(mousePosition.x-spawnIndicator.transform.position.x, mousePosition.y - spawnIndicator.transform.position.y)*5);
            currentPlanet.GetComponent<Rigidbody2D>().mass = mass+Random.Range(0.5f,0.55f);
            currentPlanet.transform.localScale = new Vector2(5, 5);
            spawnIndicator.transform.position = new Vector3(0, 0, -100);
        }

        planetsLeft.text = GameObject.FindGameObjectsWithTag("Planet").Length.ToString() + " PLANETS";


    }
}
