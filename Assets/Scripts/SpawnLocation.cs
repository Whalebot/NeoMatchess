using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public bool startTile;
    public int positionID;
    public int pieceID;
    public bool enemy;
    public bool hasPiece;
    public bool hasSpawned;
    public PieceManager pieceManager;
    // Start is called before the first frame update
    void Start()
    {
        if (startTile)
        {    // if (GameDataManager.savedPiece[])
            bool hasSave = false;
            for (int i = 0; i < 25; i++)
            {
                if (GameDataManager.savedPiece[i] != 0) hasSave = true;
            }
            if(!hasSave)
            Instantiate(pieceManager.playerPieces[GameDataManager.savedPiece[0]], transform.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")) LoadGame();
        if (Input.GetKeyDown("s")) SaveGame();
        if (Input.GetKeyDown("w")) print("Position " + positionID + " contains " + GameDataManager.savedPiece[positionID - 1]);
        if (!hasPiece)
        {
        }
    }
    public void LoadGame()
    {
        enemy = GameDataManager.savedEnemy[positionID - 1];
        if (GameDataManager.savedPiece[positionID - 1] != 0 && !hasPiece)
        {
            if (enemy) { Instantiate(pieceManager.enemyPieces[GameDataManager.savedPiece[positionID - 1] - 1], transform.position, Quaternion.identity); }

            else
            { Instantiate(pieceManager.playerPieces[GameDataManager.savedPiece[positionID - 1] - 1], transform.position, Quaternion.identity); }
        }
    }

    public void SaveGame()
    {
        GameDataManager.savedPiece[positionID - 1] = pieceID;
        GameDataManager.savedEnemy[positionID - 1] = enemy;
    }

    public void ResetValues()
    {
        pieceID = 0;
        hasPiece = false;
        enemy = false;

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Piece")) { pieceID = other.transform.parent.GetComponentInParent<PieceScript>().ID; hasPiece = true; enemy = other.transform.parent.GetComponentInParent<PieceScript>().enemy; }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Piece")) { pieceID = 0; hasPiece = false; }

    }
}
