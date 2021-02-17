using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float inputX, inputZ;
    public GameObject cube;
    public Vector3 cameraOffSet;

    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube");
        cameraOffSet = new Vector3(-10, 5, -30);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = cube.transform.position + cameraOffSet;

        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        if (inputX != 0)
            rotate();
        if (inputZ != 0)
            move();        
    }

    private void rotate()
    {
        transform.Rotate(new Vector3(0f, inputX * Time.deltaTime*5f, 0f));
    }

    private void move()
    {
        transform.position += transform.forward * inputZ * Time.deltaTime*5f;
    }
}
