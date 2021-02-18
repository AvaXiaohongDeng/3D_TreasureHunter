using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureTerrain : MonoBehaviour
{
    public GameObject cube;
    public float m_speed;
    public float m_height;
    public GameObject sphere;
    public GameObject water;
    public bool isEntered;

    private void Start()
    {
        cube = GameObject.Find("Cube");
        m_speed = 100f;
        m_height = cube.transform.localScale.y;
        sphere = GameObject.Find("Sphere");
        water = GameObject.Find("Water");
        isEntered = false;        
    }

    private void Update()
    {

        Vector3 pos = cube.transform.position;

        //keep the cube is always on the top or terrain.
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position)+ m_height/2;
        cube.transform.position = pos;


        //move the cube by the WASD keys
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(m_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-m_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, m_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0, 0, -m_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.U))
        {
            transform.Translate(0, m_speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(0, -m_speed * Time.deltaTime, 0);
        }

        //rotate the cube using the QE keys
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 40, 0);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 40, 0);
        }

        //halve the cube's speed after it entered water
        if (water.GetComponent<Collider>().bounds.Contains(transform.position))
        {
            Debug.Log("Enter water");
            isEntered = true;
            m_speed /= 2;
        }

        //double the cube's speed after it exited water
        if (isEntered && (!water.GetComponent<Collider>().bounds.Contains(transform.position)))
        {
            Debug.Log("Exit water");
            isEntered = true;
            m_speed *= 2;
        }

        //catch the sphere
        if (GetComponent<Collider>().bounds.Contains(sphere.transform.position))
        {
            Debug.Log("Win Scene Loading");
            SceneManager.LoadScene("Win");
        }
    }

}
