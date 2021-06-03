using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus_Controller_Script : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject Menu_Pause;
    [SerializeField] private GameObject Menu_Creditos;
    [SerializeField] private bool Status_Pause = false;

    [Header("Game Controller")]
    [SerializeField] private Game_Controller_Script Game_Controller;

    [Header("Player")]
    [SerializeField] private Player_Script Player;
    [SerializeField] private Text Player_pontos;
    [SerializeField] private Text Player_vitorias;

    [Header("Dealer")]
    [SerializeField] private Dealer_Script Dealer;
    [SerializeField] private Text Dealer_pontos;
    [SerializeField] private Text Dealer_vitorias;

    [Header("Resultado")]
    [SerializeField] private GameObject Resultado;
    [SerializeField] private Text Resultado_text;
    [SerializeField] private Vector3 Resultado_pos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Menu_Creditos.SetActive(false);
        Menu_Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Status_Pause = Menu_Pause.activeSelf;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Button_Config();
        }

        Player_pontos.text = "Jogador: " + Player.Pontos;
        Player_vitorias.text = "Vitórias: " + Player.Vitorias;

        Dealer_pontos.text = "Banca: " + Dealer.Pontos;
        Dealer_vitorias.text = "Vitórias: " + Dealer.Vitorias;

        Resultado_text = Resultado.GetComponentInChildren<Text>();
    }

    public bool Get_Set_Status_Pause
    {
        get
        { 
            return Status_Pause;
        }

        set
        {
            Status_Pause = value;
        }
    }
    
    public void Set_Resultado(string resultado_text, Color color)
    {
        Resultado_text.color = color;
        Resultado_text.text = resultado_text;
        Instantiate(Resultado, transform.position + Resultado_pos, transform.rotation,transform);
    }

    public void Button_Config()
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
        Menu_Pause.SetActive(false);
    }

    public void Button_Creditos()
    {
        Menu_Creditos.SetActive(true);
    }

    public void Button_Novo_Jogo() 
    {
        Player.New_Game();
        Dealer.New_Game();
    }

    public void Button_Sair()
    {
        Application.Quit();
    }

    public void Button_Voltar()
    {
        Menu_Creditos.SetActive(false);
    }
}
