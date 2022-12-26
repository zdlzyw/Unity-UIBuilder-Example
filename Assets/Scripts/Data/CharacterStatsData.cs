using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/CharacterStatsData"), fileName = ("CharacterStatsData_"))]
public class CharacterStatsData : ScriptableObject
{
    [SerializeField] TextAsset statsCSV;
    [SerializeField] List<CharacterStats> characterStatsList;

    private void OnValidate()
    {
        if (!statsCSV) return;
        characterStatsList.Clear();
        string[] textInLines = statsCSV.text.Split('\n');
        for(int lineIndex = 3; lineIndex < textInLines.Length-1; lineIndex++)
        {
            string[] statsValues = textInLines[lineIndex].Split(',');
            CharacterStats currentLevelStats = new CharacterStats();
            currentLevelStats.speed = int.Parse(statsValues[1]);
            currentLevelStats.maxhp = int.Parse(statsValues[2]);
            currentLevelStats.maxmp = int.Parse(statsValues[3]);
            currentLevelStats.attack = int.Parse(statsValues[4]);
            currentLevelStats.defense = int.Parse(statsValues[5]);
            characterStatsList.Add(currentLevelStats);
        }
    }
    public CharacterStats GetCharacterCurrentLevelStats(int level)
    {
        return characterStatsList[level - 1];
    }
}
