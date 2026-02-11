using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Setting Coin Manager")]
    [SerializeField] TextMeshProUGUI _textTimer;
    [SerializeField] GameObject _gameObjectPortal;
    private int coins;

    public int Coins
    {
        get { return coins; }
        set { coins += value; }
    }

    // Start is called before the first frame update

    public void ChangeViewCoins(int coin)
    {

        coins += coin;
        _textTimer.SetText(coins.ToString());

        if (coins == Utility._coinMax)
        {
            _gameObjectPortal.SetActive(true);
        }
    }



}
