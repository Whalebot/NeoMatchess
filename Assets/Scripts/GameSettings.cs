using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static bool isPaused;
    public bool willSmooth;
    public float speed0 = 0.1F;
    public float speed1 = 0.25F;
    public float speed2 = 0.5F;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PieceScript.willSmooth = willSmooth;
        PieceScript.moveVelocity = moveSpeed;
        
    }
    private void Update()
    {
        PieceScript.willSmooth = willSmooth;
        PieceScript.moveVelocity = moveSpeed;
    }
}
