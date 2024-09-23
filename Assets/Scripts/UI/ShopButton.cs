using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoText;

    public void ResetInfoText()
    {
        _infoText.text = string.Empty;
    }
}
