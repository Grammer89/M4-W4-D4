using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Setting Timer")]
    [SerializeField] TMP_Text _textTimer;
    [SerializeField] float _timer;

    [Header("Event UI Lose")]
    [SerializeField] UnityEvent _OnLoseLevel;

    private float _timerResidue;
    private bool _gameOver;
    private void Awake()
    {
        _timerResidue = _timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver) return;

        if (MenageTimeOver()) return;

        MenageTimeDisplay();
    }

    bool MenageTimeOver()
    {
        _timerResidue -= Time.deltaTime;

        if (_timerResidue < 0f)
        {
            _gameOver = true;
            _OnLoseLevel.Invoke();
            return _gameOver;
        }

        return _gameOver;
    }

    public void MenageTimeDisplay()
    {

        int min = Mathf.FloorToInt(_timerResidue / 60);
        int sec = Mathf.FloorToInt(_timerResidue % 60);

        _textTimer.SetText(min.ToString("00") + ":" + sec.ToString("00"));
    }

}
