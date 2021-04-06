using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Controller_Script : MonoBehaviour
{
    #region variaveis
    [Header("Audio Controu")]
    [Range(0, 1)]
    [SerializeField] private float audio_volume = 0;
    [SerializeField] private AudioClip audio_win;
    [SerializeField] private AudioClip audio_loser;
    [SerializeField] private AudioClip audio_flip_card;
    [SerializeField] private AudioSource audio_som;
    [SerializeField] private Image audio_image;
    [SerializeField] private Sprite audio_image_on;
    [SerializeField] private Sprite audio_image_off;
    //[SerializeField] private GameObject audio_slider;
    private float audio_volume_aux = 0;
    public float Audio_volume { set { audio_volume = value; } get { return audio_volume; } }
    #endregion
    void Start()
    {
        audio_volume = AudioListener.volume;
    }
    void Update()
    {
        Audio_Status();
    }
    #region metodos
    void Audio_Status()
    {
        AudioListener.volume = audio_volume;
        if (audio_volume == 0)
        {
            audio_image.sprite = audio_image_off;
        }
        else
        {
            audio_image.sprite = audio_image_on;
        }
    }
    public void Button_Audio()
    {
        if (audio_volume == 0)
        {
            audio_volume = audio_volume_aux;
            audio_volume_aux = 0;
        }
        else
        {
            audio_volume_aux = audio_volume;
            audio_volume = 0;
        }
    }
    public void sound_loser()
    {
        audio_som.PlayOneShot(audio_loser);
    }
    public void sound_win()
    {
        audio_som.PlayOneShot(audio_win);
    }
    public void sound_flip_card()
    {
        audio_som.PlayOneShot(audio_flip_card);
    }
    #endregion
}
