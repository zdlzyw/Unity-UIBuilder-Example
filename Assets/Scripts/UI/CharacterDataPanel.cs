using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterDataPanel : VisualElement
{
    readonly TemplateContainer templateContainer;
    readonly List<VisualElement> statsContainer;
    bool HasEnter = false;
    public new class UxmlFactory : UxmlFactory<CharacterDataPanel> { }
    public CharacterDataPanel()
    {
        templateContainer = Resources.Load<VisualTreeAsset>("CharacterDataPanel").Instantiate();
        templateContainer.style.flexGrow = 1.0f;
        hierarchy.Add(templateContainer);
    }

    public CharacterDataPanel(CharacterData characterData): this()
    {
        userData = characterData;
        templateContainer.Q<Label>("Name").text = characterData.CharacterName;
        templateContainer.Q<VisualElement>("Avata").style.backgroundImage = characterData.CharacterAvataImage;
        statsContainer = templateContainer.Query<VisualElement>("Stat").ToList();
        UpdateCharacterStats(statsContainer);
        /* 自定义操纵器
        Clickable leftClickManipulator = new Clickable(OnClickLeft);
        templateContainer.AddManipulator(leftClickManipulator);

        Clickable rightClickManipulator = new Clickable(OnClickRight);
        rightClickManipulator.activators.Add(new ManipulatorActivationFilter()
        {
            button = MouseButton.RightMouse,
        });
        templateContainer.AddManipulator(leftClickManipulator);
        templateContainer.AddManipulator(rightClickManipulator);
        */
        MouseEvent();
    }
    /*
    private void OnClickLeft()
    {
        ((CharacterData)userData).CharacterLevel++;
        UpdateCharacterStats(statsContainer);
    }
    private void OnClickRight()
    {
        ((CharacterData)userData).CharacterLevel--;
        UpdateCharacterStats(statsContainer);
    }
    */
    private void MouseEvent()
    {
        // 注册时间
        templateContainer.RegisterCallback<MouseDownEvent>(OnClicked);
        templateContainer.RegisterCallback<MouseEnterEvent>(OnMouseEnter);
        templateContainer.RegisterCallback<MouseLeaveEvent>(OnMouseLeave);
    }

    private void OnClicked(MouseDownEvent evt)
    {
        if(evt.button == 0)
        {
            ((CharacterData)userData).CharacterLevel++;
        }
        else if(evt.button == 1)
        {
            ((CharacterData)userData).CharacterLevel--;
        }
        UpdateCharacterStats(statsContainer);
    }

    private void OnMouseLeave(MouseLeaveEvent evt)
    {
        if (HasEnter)
        {
            templateContainer.style.top = 0;
        }
        HasEnter = false;
    }

    private void OnMouseEnter(MouseEnterEvent evt)
    {
        if (!HasEnter)
        {
            templateContainer.style.top = -30;
        }
        HasEnter=true;
    }

    private void UpdateCharacterStats(List<VisualElement> statsContainer)
    {
        var characterData = (CharacterData)userData;

            SetCharacterStats(statsContainer[0], "等级", characterData.CharacterLevel);
            SetCharacterStats(statsContainer[1], "行动力", characterData.CharacterStats.speed);
            SetCharacterStats(statsContainer[2], "HP", characterData.CharacterStats.maxhp);
            SetCharacterStats(statsContainer[3], "MP", characterData.CharacterStats.maxmp);
            SetCharacterStats(statsContainer[4], "攻击力", characterData.CharacterStats.attack);
            SetCharacterStats(statsContainer[5], "防御力", characterData.CharacterStats.defense);
    }
    private void SetCharacterStats(VisualElement item, string statName, int statValue)
    {
        item.Query<Label>().AtIndex(0).text = statName;
        item.Query<Label>().AtIndex(1).text = statValue.ToString();
    }
}

