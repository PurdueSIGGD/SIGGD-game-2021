using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelNameLoader : MonoBehaviour
{
    [SerializeField] private LevelCollection lvlCollection;
    [SerializeField] private TMPro.TMP_Text[] levelTitleTexts;
    [SerializeField] private TMPro.TMP_Text levelGroupTitleText;
    [SerializeField] private TMPro.TMP_Text actNumDisplay;
    [SerializeField] private UnityEvent<int> onActNumChange;
    private string theme;
    private int actNumber;
    private void OnEnable() {
        SetLevels("mines");
    }

    public void SetLevels(string theme) {
        this.theme = theme;
        var lvlMetas = lvlCollection.getThemeLevels(theme);

        levelGroupTitleText.text = "Chapter: " + theme;

        for (int i = 0; i < levelTitleTexts.Length && i < lvlMetas.Count; i++) {
            levelTitleTexts[i].text = "Act " + (i+1) + ": " + lvlMetas[i].title;
        }

    }
        
    public void SetActNumber(int num) {
        this.actNumber = num;
        this.actNumDisplay.text = "Act " + num + ":";
        onActNumChange.Invoke(actNumber);
    }
    public void StartAct() {
        var lvlMeta = lvlCollection.getLevel(this.theme, this.actNumber - 1);
        SceneManager.LoadScene(lvlMeta.sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
