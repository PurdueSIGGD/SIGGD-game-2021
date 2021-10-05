using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    private static readonly string[] levelNames = {
        "level_a",
        "bunny_level",
        "running_level",
        "bunny_level2",
    };

    public void NextLevel() {
        var levelIndex = System.Array.FindIndex(levelNames, (s) => s.Equals(SceneManager.GetActiveScene().name));
        SceneManager.LoadScene(levelNames[levelIndex + 1]);
    }
}
