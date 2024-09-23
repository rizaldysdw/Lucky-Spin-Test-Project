using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSelectData", menuName = "ScriptableObjects/CharacterSelect", order = 1)]
public class CharacterSelectSO : ScriptableObject
{
    [Header("Character")]
    public string CharacterName;
    public Sprite CharacterSprite;
    public bool IsUnlocked = false;
}
