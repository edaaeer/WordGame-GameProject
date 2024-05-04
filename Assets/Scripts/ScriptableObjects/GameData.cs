using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]

public class GameData : ScriptableObject
{
    public string selectedCategoryName;
    public BoardData selectedBoardData;
}
