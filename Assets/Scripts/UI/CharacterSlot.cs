using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSlot : MonoBehaviour
{
    [Header("Data")]
    public CharacterSelectSO CharacterData;

    [Header("Settings")]
    [SerializeField] private Image _icon;
    [SerializeField] private Button _selectButton;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private GameObject _lockIcon;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _infoText;
    

    void Start()
    {
        InitializeCharacterSlot();

        _infoText = GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>();
        if (_selectButton) _selectButton.onClick.AddListener(SelectCharacter);
    }

    private void InitializeCharacterSlot()
    {
        if (CharacterData)
        {
            _icon.sprite = CharacterData.CharacterSprite;
            _selectButton.interactable = CharacterData.IsUnlocked;
            _nameText.text = CharacterData.CharacterName;

            if (CharacterData.IsUnlocked)
            {
                _icon.color = new Color(1f, 1f, 1f, 1f);
                _lockIcon.SetActive(false);
            }
            else
            {
                _icon.color = new Color(1f, 1f, 1f, .7f);
                _lockIcon.SetActive(true);
            }
        }
    }

    private void SelectCharacter()
    {
        if (!CharacterData.IsUnlocked) return;

        _infoText.text = $"You have selected {CharacterData.CharacterName}";
    }
}
