using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Piece Manager", menuName = "Custom stuff")]
public class PieceManager : ScriptableObject
{
    public List<GameObject> playerPieces;

    public List<GameObject> enemyPieces;
}
