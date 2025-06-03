using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject target;
    public GameObject pivotPoint;
    public float startX;
    public float rotationSpeed;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        //if (Input.GetMouseButtonDown(1)) { startX = Input.mousePosition.x; }
        //if (Input.GetMouseButton(1))
        //{
        //    print(Input.mousePosition.x - startX);
        //    pivotPoint.transform.Rotate(0, (Input.mousePosition.x - startX)*rotationSpeed*Time.deltaTime, 0);
        //    startX = Input.mousePosition.x;
        //}
        //if (Input.GetMouseButtonDown(2))
        //{
        //    transform.position = startPos;
        //}
    }
    private void LateUpdate()
    {
        transform.LookAt(target.transform);
    }
}
