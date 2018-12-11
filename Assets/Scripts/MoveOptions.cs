using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOptions : MonoBehaviour
{
    public float setupTime = 0.1F;
    public int ID;
    public bool offensiveTile;
    public bool noOffense;
    public bool isActive;
    public bool isBlocking;
    public bool blocked;
    private bool canSet;
    public bool isColliding;
    public GameObject prevTile;
    public GameObject nextTile;
    public Collider col;

    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<BoxCollider>();
    }
    private void OnEnable()
    {
        { isBlocking = false; blocked = false; canSet = true; isActive = false; }
    }

    private void OnDisable()
    {
        { isBlocking = false; blocked = false; canSet = true; isActive = false; }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (isActive && !blocked) { transform.GetChild(0).gameObject.SetActive(true); }
        else { transform.GetChild(0).gameObject.SetActive(false); }

        if (isBlocking || blocked)
        {
            if (blocked) isActive = false;
            if (nextTile != null)
                nextTile.GetComponent<MoveOptions>().blocked = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Blocker")) { isActive = false; isBlocking = true; canSet = false; }
        else if (other.CompareTag("ID") && noOffense && !blocked)
        {

            isActive = false; isBlocking = true; canSet = false;
        }
        else if (other.CompareTag("ID") && !offensiveTile && !noOffense && !blocked)
        {
            if (other.GetComponent<IDScript>().ID != ID) { isActive = false; isBlocking = true; }
            else { isActive = true; isBlocking = true; canSet = false; }
        }
        else if (offensiveTile && !noOffense)
        {
            if (other.CompareTag("ID"))
                if (other.GetComponent<IDScript>().ID == ID)
                {
                    canSet = false;
                    isActive = true;
                }
        }
        else if (!offensiveTile && !blocked && !isBlocking && canSet)
        {
            if (other.CompareTag("SpawnLocation") && !other.CompareTag("ID"))
            {
                canSet = false;
                isActive = true;
            }
        }

    }
    public void EnableCollision() { }
    public void DisableCollision() { }

}
