using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class initialise : MonoBehaviour
{
    public Vector2 direction;
    public float mass;
    public Vector2 mousePosition;
    public Camera sceneCamera;
    public GameObject Planet;
    public GameObject currentPlanet;
    public GameObject spawnIndicator;
    public GameObject aimUI;
    public TextMeshProUGUI MassText;
    public TextMeshProUGUI VelocityText;
    public TextMeshProUGUI planetsLeft;
    public float minMass = 40;
    public float maxMass = 80;
    void Start()
    {
        setValues();
        
    }
    void setValues()
    {
        direction = new Vector2(Random.Range(-10f,10f), Random.Range(-10f,10f));
        direction = direction.normalized * Random.Range(100000,150000);
        mass = Random.Range(minMass, maxMass);
    }
    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 1)
        {
            mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                currentPlanet = Instantiate(Planet, mousePosition, this.transform.rotation);
                currentPlanet.GetComponent<Rigidbody2D>().AddForce(direction);
                currentPlanet.GetComponent<Rigidbody2D>().mass = mass;
                currentPlanet.transform.localScale = new Vector2(mass / 10, mass / 10);
                setValues();
            }
            spawnIndicator.transform.position = new Vector2(aimUI.transform.position.x + (direction.x / 4000), aimUI.transform.position.y + (direction.y / 4000));
            spawnIndicator.GetComponent<LineRenderer>().sortingOrder = 1;
            spawnIndicator.GetComponent<LineRenderer>().material = new Material(Shader.Find("Sprites/Default"));
            spawnIndicator.GetComponent<LineRenderer>().material.color = new Color(1 / (new Vector2(mousePosition.x - spawnIndicator.transform.position.x, mousePosition.y - spawnIndicator.transform.position.y).magnitude / 500), 0.3f, 0.6f);
            spawnIndicator.GetComponent<SpriteRenderer>().color = new Color(1 / (new Vector2(mousePosition.x - spawnIndicator.transform.position.x, mousePosition.y - spawnIndicator.transform.position.y).magnitude / 500), 0.3f, 0.6f);
            spawnIndicator.GetComponent<LineRenderer>().endWidth = 0;
            spawnIndicator.GetComponent<LineRenderer>().startWidth = Mathf.RoundToInt(mass / 15);
            spawnIndicator.GetComponent<LineRenderer>().SetPosition(0, aimUI.transform.position);
            spawnIndicator.GetComponent<LineRenderer>().SetPosition(1, spawnIndicator.transform.position);
           // spawnIndicator.transform.position = new Vector2(aimUI.transform.position.x, aimUI.transform.position.y);
            spawnIndicator.transform.localScale = new Vector2(mass / 15, mass / 15);
        }
        else
        {
            spawnIndicator.transform.position = new Vector2(1000, 1000);
        }
        planetsLeft.text = GameObject.FindGameObjectsWithTag("Planet").Length.ToString() + " PLANETS";
        MassText.text = (mass / 10).ToString() + " x10^27 KG";
        VelocityText.text = direction.magnitude.ToString() + " x10^11 N";



    }
}
