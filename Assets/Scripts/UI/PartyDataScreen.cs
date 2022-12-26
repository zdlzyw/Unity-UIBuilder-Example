using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PartyDataScreen : MonoBehaviour
{
    [SerializeField] PartyData partyData;
    VisualElement root;
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement bodyContainer = root.Q<VisualElement>("BodyContainer");
        bodyContainer.Clear();
        foreach(var character in partyData.CharacterDataList)
        {
            VisualElement item = new CharacterDataPanel(character);
            item.style.flexBasis = Length.Percent(25.0f);
            bodyContainer.Add(item);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            root.style.display = root.style.display == DisplayStyle.Flex ? DisplayStyle.None : DisplayStyle.Flex;
        }
    }
}
