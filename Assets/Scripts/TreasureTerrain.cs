using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureTerrain : MonoBehaviour
{
    public GameObject cube, sphere, water;
    public float m_speed,start_speed, m_height;    
    public bool isEntered;

    private void Start()
    {
        cube = GameObject.Find("Cube");
        sphere = GameObject.Find("Sphere");
        water = GameObject.Find("Water");
        m_speed = 100f;
        start_speed = 100f;
        m_height = cube.transform.localScale.y;                      
    }

    private void Update()
    {
        GluedToTerrain();
        MoveCube();
        HalfSpeed();
        FindTreasure();        
    }

    //To keep the cube is always on the top or terrain.
    public void GluedToTerrain(){
        Vector3 pos = cube.transform.position;        
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position) + m_height / 2;
        cube.transform.position = pos;
    }

    //To find the treasure
    public void FindTreasure(){
        //catch the sphere, then load to win scene
        if (GetComponent<Collider>().bounds.Contains(sphere.transform.position))
            SceneManager.LoadScene("Win");       
    }

    //To control the movement of the cube
    public void MoveCube(){
        //move the cube by the WASD keys
        if (Input.GetKey(KeyCode.W))
            transform.Translate(m_speed * Time.deltaTime, 0, 0);
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(-m_speed * Time.deltaTime, 0, 0);       
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(0, 0, m_speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.A))
            transform.Translate(0, 0, -m_speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.U))
            transform.Translate(0, m_speed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.J))
            transform.Translate(0, -m_speed * Time.deltaTime, 0);

        //rotate the cube using the QE keys
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(0, 40, 0);
        else if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0, 40, 0);
    }

    //halve the cube's speed after it entered water
    public void HalfSpeed(){
        //x,y,z of the water center
        var waterCenterX = water.transform.position.x;
        var waterCenterY = water.transform.position.y;
        var waterCenterZ = water.transform.position.z;

        //scale of x, y z
        var waterScaleX = water.transform.localScale.x;
        var waterScaleY = water.transform.localScale.y;
        var waterScaleZ = water.transform.localScale.z;

        //calculate offsets for x, y, and z based on 
        //1 scale is 100f
        var offsetX = waterScaleX * 100.0f / 2;
        var offsetY = waterScaleY * 100.0f / 2;
        var offsetZ = waterScaleZ * 100.0f / 2;

        //min & max of x, y, z
        var minWaterX = waterCenterX - offsetX;
        var maxWaterX = waterCenterX + offsetX;
        var minWaterY = waterCenterY - offsetY;
        var maxWaterY = waterCenterY + offsetY;
        var minWaterZ = waterCenterZ - offsetZ;
        var maxWaterZ = waterCenterZ + offsetZ;

        // x, y, z of the cube
        var cubeX = cube.transform.position.x;
        var cubeY = cube.transform.position.y;
        var cubeZ = cube.transform.position.z;

        // Check x, y, and z
        if (cubeX > minWaterX && cubeX < maxWaterX &&
            cubeY > minWaterY && cubeY < maxWaterY &&
            cubeZ > minWaterZ && cubeZ < maxWaterZ){
           if (m_speed == start_speed)
           {
                Debug.Log("Enter water");
                // The speed is half in the water
                m_speed = m_speed / 2;                
            }
        }else            
            m_speed = start_speed;
    }
}
