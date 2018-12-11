using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    public Material material;
    public bool selected;
    public float dissolveSpeed;
    public float dissolveValue;
    public bool dissolving;
    public bool dissolveIn;
    //Shader 
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.SetFloat("_disolveRef", 0F);
        dissolveIn = true;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (selected) material.SetFloat("_linewidth", 1);
        else material.SetFloat("_linewidth", 0);
        if (Input.GetKeyDown("t")) { dissolving = true; }
        if (dissolveIn) DissolveIn();
        if (dissolving) Dissolve();
        //   
    }
    public void Dissolve()
    {
        material.SetFloat("_disolveRef", dissolveValue);
        dissolveValue = Mathf.Clamp(dissolveValue - dissolveSpeed, 0, 1);
    }
    public void DissolveIn()
    {
        material.SetFloat("_disolveRef", dissolveValue);
        dissolveValue = Mathf.Clamp(dissolveValue + dissolveSpeed, 0, 1);
        if (dissolveValue == 1) dissolveIn = false;
    }
}
