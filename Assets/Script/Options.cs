using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Slider bgmSlider;  // Referensi ke slider BGM
    public Slider sfxSlider;  // Referensi ke slider SFX
    public AudioSource bgmSource; // Referensi ke AudioSource untuk BGM

    private float bgmVolume = 1f;
    private float sfxVolume = 1f;

    void Start()
    {
        // Load volume yang tersimpan
        bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;

        // Set initial volume BGM
        bgmSource.volume = bgmVolume;

        // Tambahkan listener ke slider untuk mengubah volume secara real-time
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // Mengatur volume BGM
    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        bgmSource.volume = bgmVolume;
        PlayerPrefs.SetFloat("BGMVolume", bgmVolume); // Simpan pengaturan
    }

    // Mengatur volume SFX
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume); // Simpan pengaturan
    }

    // Fungsi untuk kembali ke Main Menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
