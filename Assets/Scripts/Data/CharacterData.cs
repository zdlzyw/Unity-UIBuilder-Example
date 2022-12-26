using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("CharacterData"), fileName = ("Avata_"))]
public class CharacterData : ScriptableObject
{
    [SerializeField] Texture2D characterAvataImage;
    [SerializeField] string characterName;
    [SerializeField, Range(1, CharacterMaxLeven)] int characterStartLevel = 1;
    [SerializeField] CharacterStatsData characterStatsData;
    int characterLevel;
    const int CharacterMaxLeven = 10;
    public Texture2D CharacterAvataImage => characterAvataImage;
    public string CharacterName => characterName;
    public int CharacterLevel
    {
        get => characterLevel;
        set
        {
            if (characterLevel == value || value is < 1 or > CharacterMaxLeven) return;
            characterLevel = value;
        }
    }
    public CharacterStats CharacterStats => characterStatsData.GetCharacterCurrentLevelStats(characterLevel);
    private void OnEnable()
    {
        characterLevel = characterStartLevel;
    }
}
