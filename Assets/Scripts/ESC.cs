using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ESC : MonoBehaviour
{
    public Slider effectsVolumeSlider;
    public Slider musicVolumeSlider;
    public Toggle enableVFXToggle;
    public Toggle enableMusicToggle;

    public GameObject pauseMenuCanvas;

    private AudioMixer mixer;

    private bool isPaused = false;

    void Awake()
    {
        mixer = Resources.Load<AudioMixer>("MasterMixer");
        pauseMenuCanvas.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (isPaused)
        {
            float effectsVolumeValue = Mathf.Log10(effectsVolumeSlider.value) * 20f;
            mixer.SetFloat("EffectsVolume", effectsVolumeValue);

            float musicVolumeValue = Mathf.Log10(musicVolumeSlider.value) * 20f;
            mixer.SetFloat("MusicVolume", musicVolumeValue);

            bool vfxEnabled = enableVFXToggle.isOn;
            bool musicEnabled = enableMusicToggle.isOn;

            mixer.SetFloat("EffectsMute", vfxEnabled ? 0f : -80f);
            mixer.SetFloat("MusicMute", musicEnabled ? 0f : -80f);
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f; 
        pauseMenuCanvas.SetActive(isPaused); 
    }
}
