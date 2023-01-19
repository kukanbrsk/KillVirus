using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource sFX;
    [SerializeField] private AudioClip virusClip;
    [SerializeField] private AudioClip doctorClip;
    [SerializeField] private AudioClip buttonClip;

    public void PlayVirusSound()
    {
        sFX.clip = virusClip;
        sFX.Play();
    }

    public void PlayDoctorSound()
    {
        sFX.clip = doctorClip;
        sFX.Play();
    }

    public void PlayButtonSound()
    {
        sFX.clip = buttonClip;
        sFX.Play();
    }
}
