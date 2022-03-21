using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Collection", menuName = "Level Collection")]
public class LevelCollection : ScriptableObject
{
    [SerializeField] private List<LevelMeta> levels;
    
    // sorted by priority, descending
    public List<LevelMeta> getThemeLevels(string targetTheme) {
        var matchedLvls = levels.FindAll((meta) => meta.theme.Equals(targetTheme));
        matchedLvls.Sort((m1, m2) => -1 * m1.priority.CompareTo(m2.priority));
        return matchedLvls;
    }

    public LevelMeta getLevel(string theme, int position) {
        var levels = getThemeLevels(theme);
        return levels[position];
    }
}

[System.Serializable]
public class LevelMeta {
    public string title;
    public string sceneName;
    public string theme;
    public string description;
    [Range(0, 10)]
    public int priority = 10;
}