using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSelector : MonoBehaviour
{
    public GameData CurrentGameData;
    public GameLevelData levelData;


    void Awake()
    {
        SelectSequentalBoardData();
    }

    private void SelectSequentalBoardData()
    {
        foreach(var data in levelData.data)
        {
            if(data.categoryName == CurrentGameData.selectedCategoryName)
            {
                var boardIndex = DataSave.ReadCategoryCurrentIndexValues(CurrentGameData.selectedCategoryName);

                if(boardIndex < data.boardData.Count)
                {
                    CurrentGameData.selectedBoardData = data.boardData[boardIndex];
                }
                else
                {
                    var randomIndex = Random.Range(0, data.boardData.Count);
                    CurrentGameData.selectedBoardData = data.boardData[randomIndex];
                }
            }
        }
    }


}
