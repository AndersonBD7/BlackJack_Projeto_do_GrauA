using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Audio_Controller_Script : MonoBehaviour
{
    [SerializeField] private Image Audio_Button;
    [SerializeField] private Sprite Audio_On;
    [SerializeField] private Sprite Audio_Off;

    [SerializeField] private Slider Volume;
    private float Volume_aux = 0;

    [SerializeField] private AudioClip Audio_win;
    [SerializeField] private AudioClip Audio_loser;
    [SerializeField] private AudioClip Audio_flip_card;
    [SerializeField] private AudioSource Audio;

    void Start()
    {
        Volume.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = Volume.value;

        if (Volume.value == 0)
        {
            Audio_Button.sprite = Audio_Off;
        }
        else
        {
            Audio_Button.sprite = Audio_On;
        }
    }

    public void Button_Audio()
    {
        if (Volume.value == 0)
        {
            if (Volume_aux == 0)
            {
                Volume_aux = 1;
            }
            Volume.value = Volume_aux;
            Volume_aux = 0;
        }
        else
        {
            Volume_aux = Volume.value;
            Volume.value = 0;
        }
    }

    public void sound_loser()
    {
        Audio.PlayOneShot(Audio_loser);
    }

    public void sound_win()
    {
        Audio.PlayOneShot(Audio_win);
    }

    public void sound_flip_card()
    {
        Audio.PlayOneShot(Audio_flip_card);
    }
}
