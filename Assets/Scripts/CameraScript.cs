using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static GameObject camTarget;
    public GameObject target;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            camTarget = target;
            startPos = transform.position - target.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {if(camTarget != null)
        transform.position = camTarget.transform.position + startPos;
    }
}
