using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    public static bool touchInput;
    public bool hasTouchInput;
    public bool randomBlockers;
    public static int points;
    public Text text;
    public bool randomSpawn;
    public int counter;
    public List<GameObject> pieceTypes;
    public List<GameObject> spawnPoints;
    public List<GameObject> randomPoints;
    public int RNG;
    public static bool hasSelected;
    public static bool isMoving;
    public bool showSelected;
    public static bool createObject;
    // Use this for initialization
    void Start()
    {
        points = 0;
        touchInput = hasTouchInput;
    }

    // Update is called once per frame
    void Update()
    {
        showSelected = hasSelected;
        
             
        text.text = "Score: " + points;
        if (createObject) { createObject = false; SpawnRandom();  }
    }

    public void SpawnRandom()
    {


        if (randomSpawn)
        {
            int i = randomPoints.Count;
            RNG = Random.Range(0, i);
            if (randomPoints[RNG].GetComponent<SpawnLocation>().hasPiece)
            {
                bool isFull = true;
                for (int j = 0; j < randomPoints.Count; j++)
                {
                    if (!randomPoints[j].GetComponent<SpawnLocation>().hasPiece) { isFull = false; }

                }
                if (!isFull) SpawnRandom();
                else print("GameOver?");

            }

            else
            {
                if (randomBlockers)
                {
                    if (counter % 3 == 2)
                    {
                        int flip = Random.Range(0, 2);
                        if (flip == 1)
                            Instantiate(pieceTypes[1], randomPoints[RNG].transform.position, randomPoints[RNG].transform.rotation);

                        else Instantiate(pieceTypes[0], randomPoints[RNG].transform.position, randomPoints[RNG].transform.rotation);
                    }
                    else { Instantiate(pieceTypes[0], randomPoints[RNG].transform.position, randomPoints[RNG].transform.rotation); }
                    counter++;
                }
                else
                {
                    Instantiate(pieceTypes[counter % 2], randomPoints[RNG].transform.position, randomPoints[RNG].transform.rotation);
                    counter++;

                }

            }
        }/*
        else
        {
            int i = spawnPoints.Count;
            RNG = Random.Range(0, i);
            if (spawnPoints[RNG].GetComponent<SpawnLocation>().hasPiece)
            {
                bool isFull = true;
                for (int j = 0; j < spawnPoints.Count; j++)
                {
                    if (!spawnPoints[j].GetComponent<SpawnLocation>().hasPiece) { isFull = false; }

                }
                if (!isFull) SpawnRandom();
                else print("GameOver?");

            }

            else Instantiate(pieceTypes[0], spawnPoints[RNG].transform.position, spawnPoints[RNG].transform.rotation);
        }

        */
    }
}
