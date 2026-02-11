using UnityEngine;

public class HandlePortal : MonoBehaviour
{
    static bool _showPortal = false;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (_showPortal)
        {
            gameObject.SetActive(true);
        }
    }

    public void ShowPortal()
    {
        _showPortal = true;
    }
}
