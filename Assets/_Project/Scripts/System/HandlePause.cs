using UnityEngine;
using UnityEngine.SceneManagement;

public class HandlePause : MonoBehaviour
{
    [Header("Setting UI")]
    [SerializeField] GameObject _uiPause;
    [SerializeField] GameObject _uiWin;
    [SerializeField] GameObject _uiLose;
    [SerializeField] GameObject _uiOption;
    [SerializeField] GameObject _player;


    Camera _cam;
    LifeController _lifeController;
    AudioManager _audioManager;

    bool _stopSystem = false;
    void Awake()
    {
        _cam = Camera.main;

        _uiPause.SetActive(false);
        _uiWin.SetActive(false);
        _uiLose.SetActive(false);
        _uiOption.SetActive(false);
        _lifeController = _player.GetComponent<LifeController>();
        _audioManager = GetComponent<AudioManager>();

    }

    private void Start()
    {
        EnableSystem();
    }
    // Update is called once per frame
    void Update()
    {
        if (_stopSystem) return;
        if (_player == null) return;
        CheckLose();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_uiPause.activeInHierarchy)
            DisableSystem();
            _uiPause.SetActive(true);
        }
    }
    public void OnResumeClick()
    {

        EnableSystem();
    }

    public void OnExitGame()
    {
        SceneManager.LoadScene(Utility._sceneIntro);
    }

    public void OnOptionClick()
    {
        _uiPause.SetActive(false);
        _uiOption.SetActive(true);
    }

    public void CheckLose()
    {
      
        if (!_lifeController.IsAlive() || _player.transform.position.y <= Utility._limitMeterUnderGround)
        {
            OnLoseLevel();
        }
    }

    public void DisableSystem()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 0f;
        _cam.GetComponent<CameraOrbit>().enabled = false;

    }

    public void EnableSystem()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = !Cursor.visible;

        _uiPause.SetActive(false);

        Time.timeScale = 1f;
        _cam.GetComponent<CameraOrbit>().enabled = true;

    }
    public void OnRestartClick()
    {
        SceneManager.LoadScene(Utility._sceneLevel1);
    }

    public void OnReturnClick()
    {
        _uiOption.SetActive(false);
        _uiPause.SetActive(true);

    }

    public void OnWinLevel()
    {
        Time.timeScale = 0f;
        _uiWin.SetActive(true);
        DisableSystem();

        _audioManager.WinClip();
        _stopSystem = true;
    }

    public void OnLoseLevel()
    {
        Time.timeScale = 0f;
        _uiLose.SetActive(true);
        DisableSystem();

        _audioManager.LoseClip();
        _stopSystem = true;
    }


}

