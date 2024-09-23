using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterListButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoText;

    public void ResetInfoText()
    {
        _infoText.text = string.Empty;
    }
}
