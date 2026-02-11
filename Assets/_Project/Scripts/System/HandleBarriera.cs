using UnityEngine;

public class HandleBarriera : MonoBehaviour
{
    private CoinManager _coinManager;
    private bool _isTrigger = false;
    private BoxCollider _boxCollider;
    // Start is called before the first frame update
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _coinManager = new CoinManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isTrigger)
        {
            int coins;
            coins = _coinManager.Coins;

            if (coins == Utility._coinMax)
            {
                _boxCollider.isTrigger = true;
                _isTrigger = true;

            }

        }

    }
}
