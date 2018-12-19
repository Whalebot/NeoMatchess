using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    public GameData gameData;
    public static int[] savedPiece = new int[25];
    public static bool[] savedEnemy = new bool[25];
    public static bool saveGame;
    GameObject[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        print(spawnLocations.Length);
        gameData = new GameData();
        LoadData();
    }

    public void SaveData()
    {
        foreach (GameObject spawnLocation in spawnLocations)
        {
            spawnLocation.GetComponent<SpawnLocation>().SaveGame();
        }
        gameData.savedPieces = savedPiece;
        gameData.savedEnemy = savedEnemy;
        string jsonData = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(Application.persistentDataPath + "/gameData.json", jsonData);
    }
    public void LoadData()
    {
        gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "/gameData.json"));
        savedPiece = gameData.savedPieces;
        savedEnemy = gameData.savedEnemy;
        foreach (GameObject spawnLocation in spawnLocations)
        {
            spawnLocation.GetComponent<SpawnLocation>().LoadGame();
        }
    }
    public void ResetData()
    {
        gameData = new GameData();
    
        string jsonData = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(Application.persistentDataPath + "/gameData.json", jsonData);
        SceneManager.LoadScene(0);
    } 
    private void Update()
    {
        if (saveGame) { saveGame = false;  SaveData(); }
        if (Input.GetKeyDown("o")) SaveData();
        if (Input.GetKeyDown("p")) LoadData();
        if (Input.GetKeyDown("i")) ResetData();
    }
}
