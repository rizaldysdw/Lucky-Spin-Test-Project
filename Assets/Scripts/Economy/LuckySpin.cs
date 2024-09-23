using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LuckySpin : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _diamondText;
    [SerializeField] private GameObject _gachaResultUI;

    [Header("Spin Wheel")]
    [SerializeField] private Button _spinWheelButton;
    [SerializeField] private Transform _wheelTransform;
    [SerializeField] private float _spinDuration = 5f;
    [SerializeField] private float _spinSpeed = 500f;
    private bool _isSpinning;

    [Header("Characters to Unlock")]
    [SerializeField] private CharacterSelectSO[] _commonCharacters;
    [SerializeField] private CharacterSelectSO[] _rareCharacters;
    [SerializeField] private CharacterSelectSO[] _epicCharacters;
    [SerializeField] private CharacterSelectSO[] _legendaryCharacters;

    private CharacterSelectSO[] _selectedCharactersPool;

    // Start is called before the first frame update
    void Start()
    {
        AssignUI();
        AssignCharactersPool();

        if (_coinText) GameManager.Instance.UpdateCoinText(_coinText);
        if (_diamondText) GameManager.Instance.UpdateDiamondText(_diamondText);
        if (_spinWheelButton) _spinWheelButton.onClick.AddListener(StartSpinWheel);
        if (_gachaResultUI) _gachaResultUI.SetActive(false);
    }

    private void AssignCharactersPool()
    {
        string rarity = GameManager.Instance.selectedRarity;

        // Set the character pool based on the selected rarity
        switch (rarity)
        {
            case "Common":
                _selectedCharactersPool = _commonCharacters;
                break;
            case "Rare":
                _selectedCharactersPool = _rareCharacters;
                break;
            case "Epic":
                _selectedCharactersPool = _epicCharacters;
                break;
            case "Legendary":
                _selectedCharactersPool = _legendaryCharacters;
                break;
        }
    }

    private void AssignUI()
    {
        _coinText = GameObject.Find("CoinText").GetComponent<Text>();
        _diamondText = GameObject.Find("DiamondText").GetComponent<Text>();
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void OnSpinWheelComplete()
    {
        _gachaResultUI.SetActive(true);
        _gachaResultUI.GetComponent<GachaResult>().UpdateGachaResultUI();
    }

    private void StartSpinWheel()
    {
        if (!_isSpinning)
        {
            StartCoroutine(Spin());
        }
    }

    private IEnumerator Spin()
    {
        _isSpinning = true;

        float elapsedTime = 0f;
        float currentSpinSpeed = _spinSpeed;

        while (elapsedTime < _spinDuration)
        {
            elapsedTime += Time.deltaTime;
            currentSpinSpeed = Mathf.Lerp(_spinSpeed, 0, elapsedTime / _spinDuration);
            _wheelTransform.Rotate(Vector3.back, currentSpinSpeed * Time.deltaTime);

            yield return null;
        }

        _isSpinning = false;
        OnSpinWheelComplete();
    }


    public CharacterSelectSO GetRandomCharacter()
    {
        // Randomly select a character from the current pool
        int randomIndex = Random.Range(0, _selectedCharactersPool.Length);
        CharacterSelectSO selectedCharacter = _selectedCharactersPool[randomIndex];

        // Unlock the selected character
        if (!selectedCharacter.IsUnlocked)
        {
            selectedCharacter.IsUnlocked = true;
            Debug.Log($"You unlocked: {selectedCharacter.CharacterName}!");
        }
        else
        {
            Debug.Log($"You already have: {selectedCharacter.CharacterName}. You got a duplicate.");
        }

        return selectedCharacter;
    }
}
