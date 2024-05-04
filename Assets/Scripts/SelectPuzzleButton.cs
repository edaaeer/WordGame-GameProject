using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPuzzleButton : MonoBehaviour
{
    public GameData gameData;
    public GameLevelData levelData;
    public Text categoryText;
    public Image progressBarFilling;


    private string gameSceneName = "GameScene";

    private bool _levelLocked;


    void Start()
    {
        _levelLocked = false;
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        UpdateButtonInformation();

        if (_levelLocked)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }

        button.interactable = true;
    }

    
    void Update()
    {
        
    }

    private void UpdateButtonInformation()
    {
        var currentIndex = -1;
        var totalBoard = 0;

        foreach(var data in levelData.data)
        {
            if(data.categoryName == gameObject.name)
            {
                currentIndex = DataSave.ReadCategoryCurrentIndexValues(gameObject.name);
                totalBoard = data.boardData.Count;

                if(levelData.data[0].categoryName == gameObject.name && currentIndex < 0)
                {
                    DataSave.SaveCategoryData(levelData.data[0].categoryName, 0);
                    currentIndex = DataSave.ReadCategoryCurrentIndexValues(gameObject.name);
                    totalBoard = data.boardData.Count;
                }
            }
        }

        if (currentIndex == -1)
            _levelLocked = true;

        categoryText.text = _levelLocked ? string.Empty : (currentIndex.ToString() + "/" + totalBoard.ToString());
        progressBarFilling.fillAmount = (currentIndex > 0 && totalBoard > 0) ? ((float) currentIndex / (float) totalBoard ) : 0f;

    }

    private void OnButtonClick()
    {
        gameData.selectedCategoryName = gameObject.name;
        SceneManager.LoadScene(gameSceneName);

    }
}
