using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Controller_Script : MonoBehaviour
{
    #region variaveis
    [SerializeField] private GameObject menu_pause;
    [SerializeField] private GameObject menu_creditos;
    [SerializeField] private Game_Controller_Script game_Controller_Script;
    [SerializeField] private Slider audio_slider_volume;
    [SerializeField] private Audio_Controller_Script audio;
    [SerializeField] private bool pause = false;
    public bool Pause { set { pause = value; } get { return pause; } }
    #endregion
    private void Start()
    {
        audio_slider_volume.value = AudioListener.volume;
        menu_pause.SetActive(false);
        menu_creditos.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Button_Pause();
        }
    }
    #region metodos
    public void Button_Pause()
    {
        if (menu_pause.activeSelf == true)
        {
            menu_creditos.SetActive(false);
            Pause = false;
            menu_pause.SetActive(false); 
        }
        else
        {
            Pause = true;
            menu_pause.SetActive(true);
        }
    }
    public void Button_Continuar()
    {
        menu_creditos.SetActive(false);
        Pause = false;
        menu_pause.SetActive(false);
    }
    public void Button_Creditos()
    {
        menu_creditos.SetActive(true);
    }
    public void Button_Sair()
    {
        Application.Quit();
    }
    public void set_volume()
    {
        audio.Audio_volume = audio_slider_volume.value;
    }
    public void Button_creditos_voltar()
    {
        menu_creditos.SetActive(false);
    }
    #endregion
}
