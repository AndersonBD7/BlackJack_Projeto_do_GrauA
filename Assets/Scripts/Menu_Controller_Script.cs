using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu_Controller_Script : MonoBehaviour
{
    [SerializeField] private GameObject Game;
    [SerializeField] private GameObject Menu_Pause;
    [SerializeField] private GameObject Menu_Creditos;
    [SerializeField] private GameObject start;
    public bool Status_Pause = false;
    [Header("Game Controller")]
    [SerializeField] private Game_Controller_Script Game_Controller;
    [Header("Dealer")]
    [SerializeField] private Dealer_Script dealer;
    [SerializeField] private Text dealer_pontos;
    [SerializeField] private Text dealer_vitorias;
    [Header("Player")]
    [SerializeField] private Player_Script player;
    [SerializeField] private Text player_pontos;
    [SerializeField] private Text player_vitorias;
    [Header("Resultado")]
    [SerializeField] private GameObject Resultado;
    [SerializeField] private Text Resultado_text;
    [SerializeField] private Vector3 Resultado_pos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);
        Game.SetActive(false);
        Menu_Pause.SetActive(false);
        Menu_Creditos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Status_Pause = Menu_Pause.activeSelf;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Button_Pause();
        }
        player_pontos.text = "Jogador : " + player.pontos.ToString();
        player_vitorias.text = "Vitórias : " + player.vitorias.ToString();
        dealer_pontos.text = "Banca : " + dealer.pontos.ToString();
        dealer_vitorias.text = "Vitórias : " + dealer.vitorias.ToString();
    }
    public void Set_Resultado(string resultado_text, Color color)
    {
        Resultado_text.color = color;
        Resultado_text.text = resultado_text;
        Instantiate(Resultado, transform.position + Resultado_pos, transform.rotation, transform);
    }
    public void Button_Start()
    {
        start.SetActive(false);
        Game.SetActive(true);
        Game_Controller.Button_Benning();
    }
    public void Button_Pause()
    {
        if (Menu_Pause.activeSelf == false)
        {
            Menu_Pause.SetActive(true);
        }
        else
        {
            Menu_Pause.SetActive(false);
            Menu_Creditos.SetActive(false);
        }
    }
    public void Button_Continue()
    {
        Menu_Creditos.SetActive(false);
        Menu_Pause.SetActive(false);
    }
    public void Button_New_Game()
    {
        player.New_Game();
        dealer.New_Game();
        Menu_Creditos.SetActive(false);
        Menu_Pause.SetActive(false);
        Game.SetActive(false);
        start.SetActive(true);
    }
    public void Reset_Game()
    {
        Menu_Creditos.SetActive(false);
        Menu_Pause.SetActive(false);
        Game.SetActive(false);
        start.SetActive(true);
    }
    public void Button_Credits()
    {
        Menu_Creditos.SetActive(true);
    }
    public void Button_Back()
    {
        Menu_Creditos.SetActive(false);
    }
    public void Button_Exit()
    {
        Application.Quit();
    }
}
