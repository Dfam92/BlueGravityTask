using UnityEngine;

public class SfxAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] AudioClip coinCollectSfx;
    [SerializeField] AudioClip clickButtonSfx;
    [SerializeField] AudioClip clickBuySfx;
    [SerializeField] AudioClip clickSellSfx;
    [SerializeField] AudioClip selectClothSfx;
    [SerializeField] AudioClip errorSfx;
    [SerializeField] float sfxVolume;

    public void PlaySfx(AudioClip clip, float value)
    {
        if (sfxAudioSource != null)
        {
            sfxAudioSource.pitch = Random.Range(1, 1.2f);
            sfxAudioSource.PlayOneShot(clip, value);
        }

    }

    public void PlayCoinCollect()
    {
        PlaySfx(coinCollectSfx, sfxVolume);
    }

    public void PlayClickButton()
    {
        PlaySfx(clickButtonSfx, sfxVolume);
    }

    public void PlayClickBuy()
    {
        PlaySfx(clickBuySfx, sfxVolume);
    }

    public void PlayClickSell() 
    {
        PlaySfx(clickSellSfx, sfxVolume);
    }

    public void PlaySelectCloth()
    {
        PlaySfx(selectClothSfx, sfxVolume);
    }

    public void PlayError()
    {
        PlaySfx(errorSfx, sfxVolume);
    }
}
