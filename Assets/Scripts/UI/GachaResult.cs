using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaResult : MonoBehaviour
{
    [SerializeField] private LuckySpin _luckySpin;

    [Header("UI")]
    [SerializeField] private Image _characterIcon;
    [SerializeField] private TextMeshProUGUI _characterNameText;
    [SerializeField] private TextMeshProUGUI _congratulationText;

    public void UpdateGachaResultUI()
    {
        CharacterSelectSO unlockedCharacter = _luckySpin.GetRandomCharacter();
        _characterIcon.sprite = unlockedCharacter.CharacterSprite;
        _characterNameText.text = unlockedCharacter.CharacterName;

        string message = $"You got {unlockedCharacter.CharacterName}";
        _congratulationText.text = message;
    }
}
