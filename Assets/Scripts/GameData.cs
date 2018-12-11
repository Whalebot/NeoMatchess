using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static int[] savedPiece = new int[25];
    // Start is called before the first frame update
    void Start()
    {
        print(savedPiece);
    }

    public void SaveData() { }
}
