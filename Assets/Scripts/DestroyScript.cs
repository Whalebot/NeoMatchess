using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float lifeTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyObject");
    }
    IEnumerator DestroyObject() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
  