using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataManager : MonoBehaviour
{
    public GameData gameData;
    public static int[] savedPiece = new int[25];
    GameObject[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        print(spawnLocations.Length);
        gameData = new GameData();
    }

    public void SaveData()
    {
        foreach (GameObject spawnLocation in spawnLocations)
        {
            spawnLocation.GetComponent<SpawnLocation>().SaveGame();
        }
        gameData.savedPieces = savedPiece;
        string jsonData = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(Application.persistentDataPath + "/gameData.json", jsonData);
    }
    public void LoadData()
    {


        gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "/gameData.json"));
        savedPiece = gameData.savedPieces;

        foreach (GameObject spawnLocation in spawnLocations)
        {
            spawnLocation.GetComponent<SpawnLocation>().LoadGame();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("o")) SaveData();
        if (Input.GetKeyDown("p")) LoadData();
    }
}
