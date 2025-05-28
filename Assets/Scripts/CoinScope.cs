using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CoinScope : MonoBehaviour
{
    [SerializeField] Text coinScopeText;
    [SerializeField] Text finishCoinScopeText;
    private float currentCoinScope = 0;

    private EventBus eventBus;

    private void Start()
    {
        while (eventBus == null)
        {
            eventBus = FindObjectOfType<EventBus>();
        }
        eventBus?.AddCoin.AddListener(AddCoins);

        AddCoins(0);
    }

    private void AddCoins(float coins)
    {
        currentCoinScope += coins;
        UpdateCoinScope();
    }

    private void UpdateCoinScope()
    {
        coinScopeText.text = currentCoinScope.ToString();
        finishCoinScopeText.text = currentCoinScope.ToString();
    }
}
