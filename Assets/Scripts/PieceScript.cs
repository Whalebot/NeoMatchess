using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    public int ID;
    public bool enemy;
    public GameObject SFX;
    public GameObject evolveSound;
    public GameObject mergeSound;
    public GameObject particle;
    Ray ray;
    Ray moveRay;
    Ray touchRay;
    Ray moveTouchRay;
    RaycastHit hit;
    RaycastHit moveHit;
    RaycastHit touchHit;
    RaycastHit touchMovehit;
    public LayerMask moveMask;
    public GameObject evolutionTarget;
    public GameObject moveOptions;
    public bool selected;
    public List<Vector3> path;
    public List<bool> reachedPath;
    public float selectedOffset;
    public bool pathFound;
    bool executeOnce;
    public float lerpTime;

    public static float moveVelocity;
    public static bool willSmooth;
    Vector3 zeroVel = Vector3.zero;
    public float marginOfError;
    public float mergeTime = 0.5F;
    public MaterialScript materialScript;
    public GameObject selectLight;
    // Start is called before the first frame update
    void Start()
    {
        materialScript = transform.GetChild(0).GetComponent<MaterialScript>();
        GameDataManager.saveGame = true;
        InputManager.Instance.mouseClick += Click;
    }
    private void OnDisable()
    {
        InputManager.Instance.mouseClick -= Click;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy)
        {
            if (selected && !pathFound)
            {
                moveOptions.SetActive(true); selectLight.SetActive(true);
                if (materialScript != null)
                    materialScript.selected = true;
            }
            else
            {
                moveOptions.SetActive(false);
                selectLight.SetActive(false);
                if (materialScript != null)
                    materialScript.selected = false;
            }


            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //moveRay = Camera.main.ScreenPointToRay(Input.mousePosition);


            ////Touch input
            //if (SpawnScript.touchInput)
            //{
            //    //    if (Input.touchCount > 0)
            //    //    {
            //    //        touchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //    //        moveTouchRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //    //        if (Input.touchCount == 1)
            //    //        {
            //    //            if (Physics.Raycast(moveTouchRay, out touchMovehit, 100f, moveMask) && selected)
            //    //            {
            //    //                if (touchMovehit.collider.CompareTag("MoveOption"))
            //    //                {
            //    //                    if (touchMovehit.collider.gameObject.GetComponent<MoveOptions>().isActive)
            //    //                    {
            //    //                        if (!pathFound)
            //    //                        {
            //    //                            path[0] = (transform.position + Vector3.up * selectedOffset);
            //    //                            path[1] = (touchMovehit.collider.transform.position + Vector3.up * selectedOffset);
            //    //                            path[2] = (touchMovehit.collider.transform.position);
            //    //                            pathFound = true;
            //    //                        }
            //    //                    }
            //    //                    else if (selected && !pathFound)
            //    //                    {
            //    //                        selected = false;
            //    //                        SpawnScript.hasSelected = false;
            //    //                    }
            //    //                }
            //    //                else if (selected && !pathFound)
            //    //                {
            //    //                    selected = false;
            //    //                    SpawnScript.hasSelected = false;
            //    //                }
            //    //            }
            //    //        }

            //    //        else if (Physics.Raycast(touchRay, out moveHit) && !SpawnScript.hasSelected)
            //    //        {
            //    //            if (moveHit.collider.gameObject == gameObject.transform.GetChild(0).gameObject || moveHit.collider.gameObject == gameObject.transform.GetChild(1).gameObject)
            //    //            {
            //    //                selected = true;
            //    //                if (SFX != null) Instantiate(SFX, transform.position, transform.rotation);
            //    //                CameraScript.camTarget = gameObject;
            //    //                SpawnScript.hasSelected = true;
            //    //            }
            //    //            else { selected = false; SpawnScript.hasSelected = false; }
            //    //        }
            //    //        else if (selected && SpawnScript.hasSelected) { selected = false; SpawnScript.hasSelected = false; }
            //    //    }
            //}
            ////Normal input
            //else
            //{
            //    if (Input.GetMouseButtonDown(0))
            //    {
            //        if (Physics.Raycast(moveRay, out moveHit, 100f, moveMask) && selected)
            //        {
            //            if (moveHit.collider.CompareTag("MoveOption"))
            //            {
            //                if (moveHit.collider.gameObject.GetComponent<MoveOptions>().isActive)
            //                {
            //                    if (!pathFound)
            //                    {
            //                        path[0] = (transform.position + Vector3.up * selectedOffset);
            //                        path[1] = (moveHit.collider.transform.position + Vector3.up * selectedOffset);
            //                        path[2] = (moveHit.collider.transform.position);
            //                        pathFound = true;
            //                    }
            //                }
            //                else if (selected && !pathFound)
            //                {
            //                    selected = false;
            //                    SpawnScript.hasSelected = false;
            //                }
            //            }
            //            else if (selected && !pathFound)
            //            {
            //                selected = false;
            //                SpawnScript.hasSelected = false;
            //            }
            //        }

            //        else if (Physics.Raycast(ray, out hit) && !SpawnScript.hasSelected && !SpawnScript.isMoving)
            //        {
            //            if (hit.collider.transform.IsChildOf(transform))
            //            //     if (hit.collider.gameObject == gameObject.transform.GetChild(0).gameObject || hit.collider.gameObject == gameObject.transform.GetChild(1).gameObject)
            //            {
            //                selected = true;
            //                if (SFX != null) Instantiate(SFX, transform.position, transform.rotation);
            //                CameraScript.camTarget = gameObject;
            //                SpawnScript.hasSelected = true;
            //            }
            //            else { selected = false; SpawnScript.hasSelected = false; }
            //        }
            //        else if (selected && SpawnScript.hasSelected) { selected = false; SpawnScript.hasSelected = false; }

            //    }
            //}
        }


    }

    void Click(Vector2 pos)
    {
        if (SpawnScript.isMoving) { Debug.Log("click while moving"); return; }
        touchRay = Camera.main.ScreenPointToRay(pos);
        moveTouchRay = Camera.main.ScreenPointToRay(pos);
        if (Physics.Raycast(moveTouchRay, out touchMovehit, 100f, moveMask) && selected)
        {
            Debug.Log("Try Move");
            if (touchMovehit.collider.CompareTag("MoveOption"))
            {
                if (touchMovehit.collider.gameObject.GetComponent<MoveOptions>().isActive)
                {
                    if (!pathFound)
                    {
                        path[0] = (transform.position + Vector3.up * selectedOffset);
                        path[1] = (touchMovehit.collider.transform.position + Vector3.up * selectedOffset);
                        path[2] = (touchMovehit.collider.transform.position);
                        pathFound = true;
                        InputManager.Instance.ClickSFX();
                    }
                }
                else if (selected && !pathFound)
                {
                    selected = false;
                    SpawnScript.hasSelected = false;
                }
            }
            else if (selected && !pathFound)
            {
                selected = false;
                SpawnScript.hasSelected = false;
            }
        }

        else if (Physics.Raycast(touchRay, out moveHit) && !SpawnScript.hasSelected && !SpawnScript.isMoving)
        {
            Rigidbody rb = moveHit.rigidbody;
            if (rb != null)
                Debug.Log(rb.gameObject);
            bool foundRB = rb != null;
            bool foundThis = false;
            if (foundRB)
                foundThis = moveHit.rigidbody.gameObject == gameObject;

            if (foundThis)
            {
                selected = true;
                if (SFX != null) Instantiate(SFX, transform.position, transform.rotation);
                InputManager.Instance.ClickSFX();
                CameraScript.camTarget = gameObject;
                SpawnScript.hasSelected = true;
            }
            else { selected = false; SpawnScript.hasSelected = false; }
        }
        else if (selected && SpawnScript.hasSelected) { selected = false; SpawnScript.hasSelected = false; }

    }
    private void FixedUpdate()
    {
        if (pathFound)
        {
            SpawnScript.isMoving = true;
            if (!reachedPath[0])
            {

                if (!willSmooth) transform.position = Vector3.Lerp(transform.position, path[0], lerpTime);
                else transform.position = Vector3.SmoothDamp(transform.position, path[0], ref zeroVel, moveVelocity);
                if (Vector3.Distance(transform.position, path[0]) < marginOfError)
                {
                    transform.position = path[0]; reachedPath[0] = true;
                }
            }
            else if (!reachedPath[1])
            {
                if (!willSmooth) transform.position = Vector3.Lerp(transform.position, path[1], lerpTime);
                else transform.position = Vector3.SmoothDamp(transform.position, path[1], ref zeroVel, moveVelocity);
                if (Vector3.Distance(transform.position, path[1]) < marginOfError)
                {
                    transform.position = path[1]; reachedPath[1] = true;
                }
            }
            else if (!reachedPath[2])
            {
                if (!willSmooth) transform.position = Vector3.Lerp(transform.position, path[2], lerpTime);
                else transform.position = Vector3.SmoothDamp(transform.position, path[2], ref zeroVel, moveVelocity);
                if (Vector3.Distance(transform.position, path[2]) < marginOfError)
                {
                    transform.position = path[2]; reachedPath[2] = true; selected = false; pathFound = false; reachedPath[0] = false; reachedPath[1] = false; reachedPath[2] = false;
                    if (!executeOnce) { SpawnScript.createObject = true; }
                    SpawnScript.hasSelected = false;
                    SpawnScript.isMoving = false;


                }
            }

        }
    }

    /*   private void OnMouseOver()
       {
           print("MOUSE");
           if (Input.GetMouseButtonDown(0)) { print("MOUSECLICK"); selected = true; }

       }*/

    private void OnTriggerEnter(Collider other)
    {
        if (ID == 1)
        {
            if (other.CompareTag("Evolve") && !executeOnce)
            {

                if (other.GetComponent<EvolveTile>().enemy && enemy)
                    StartCoroutine("Evolve", other);
                else if (!other.GetComponent<EvolveTile>().enemy && !enemy)
                    StartCoroutine("Evolve", other);
            }
        }
        if (other.CompareTag("Piece") && pathFound && !executeOnce)
        {
            if (other.GetComponentInParent<PieceScript>().ID == ID)
                StartCoroutine("Merge", other);
        }
    }

    IEnumerator Evolve(Collider other)
    {
        if (selected) SpawnScript.createObject = true;
        print("Evolve");
        executeOnce = true;
        if (materialScript != null)
            materialScript.Dissolve();
        yield return new WaitForSeconds(mergeTime);
        SpawnScript.points = SpawnScript.points + (int)Mathf.Pow(2, ID);
        SpawnScript.hasSelected = false;
        if (evolveSound != null) Instantiate(evolveSound, transform.position, transform.rotation);
        Instantiate(particle, transform.position, transform.rotation);
        Instantiate(evolutionTarget, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator Merge(Collider other)
    {

        executeOnce = true;
        if (materialScript != null)
            materialScript.Dissolve();
        yield return new WaitForSeconds(mergeTime);
        if (mergeSound != null) Instantiate(mergeSound, transform.position, transform.rotation);
        SpawnScript.createObject = true;
        SpawnScript.points = SpawnScript.points + (int)Mathf.Pow(2, ID);
        Instantiate(particle, transform.position, transform.rotation);
        Instantiate(evolutionTarget, transform.position, transform.rotation);
        Destroy(other.transform.parent.parent.gameObject);
        Destroy(gameObject);

    }
}
