using TMPro;
using UnityEngine;
using Zenject;

public class GameCurrencyUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _currencyText;
    
    private GameCurrency _gameCurrency;
    private const string CurrencyKey = "Currency: ";
    
    [Inject]
    private void Construct(GameCurrency currency)
    {
        _gameCurrency = currency;
    }
    
    private void Awake()
    {
        SetCurrencyText();
    }

    private void OnEnable()
    {
        _gameCurrency.OnCurrencyChanged += SetCurrencyText;
    }

    private void OnDisable()
    {
        _gameCurrency.OnCurrencyChanged -= SetCurrencyText;
    }

    private void SetCurrencyText()
    {
        _currencyText.text = CurrencyKey + _gameCurrency.Coins;
    }
}
