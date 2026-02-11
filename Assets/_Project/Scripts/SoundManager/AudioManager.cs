using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Manager")]
    [SerializeField] private AudioClip _backgroundLevel;
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioClip _loseClip;

    [Header("Audio Manager")]
    [SerializeField] AudioMixer _mixer;

    private AudioSource _source = new AudioSource();
    // Start is called before the first frame update
    void Awake()
    {
        _source = GetComponent<AudioSource>();

        ChangeClip(_backgroundLevel);

    }

    public void ChangeClip(AudioClip clip)
    {
        _source.Stop();
        _source.loop = true;
        _source.clip = clip;
        _source.Play();
    }

    public void WinClip()
    {
        ChangeClip(_winClip);
    }

    public void LoseClip()
    {
        ChangeClip(_loseClip);
    }

    public void OnChangeVolume(float slider)
    {
        if (slider > 0.01f)
        {
            var volume = Mathf.Log10(slider) * 20;
            _mixer.SetFloat("Master", volume);
        }
        else
        {
            _mixer.SetFloat("Master", -80f);
        }


    }
}
