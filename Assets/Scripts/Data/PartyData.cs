using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PartyData"), fileName = ("PartyData_"))]
public class PartyData : ScriptableObject
{
    [SerializeField] List<CharacterData> characterDataList;
    public List<CharacterData> CharacterDataList => characterDataList;
}
