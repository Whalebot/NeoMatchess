using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float lifeTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator DestroyObject() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
