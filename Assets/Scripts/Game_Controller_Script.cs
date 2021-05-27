using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game_Controller_Script : MonoBehaviour
{
    #region variaveis
    [SerializeField] private Baralho_Script baralho;
    bool stand = false;
    [Header("Player")]
    [SerializeField] private Player_Script player;
    private Text player_texto;
    Vector2 player_pos = Vector2.zero;
    [Header("Dealer")]
    [SerializeField] private Dealer_Script dealer;
    private Text dealer_texto;
    Vector2 dealer_pos = Vector2.zero;
    [Header("Carta")]
    [SerializeField] private GameObject carta_prefab;
    [SerializeField] private float distancia = 100;
    private Carta_Animation_Script carta_animation;
    GameObject[] cartas_destruidas;
    [Header("Resultado")]
    [SerializeField] private GameObject resultado;
    [SerializeField] private Text resultado_texto;
    [Header("Game Menu")]
    [SerializeField] private Menu_Controller_Script menu;
    [Header("Audio Script")]
    [SerializeField] Audio_Controller_Script audio;
    #endregion
    void Start()
    {
        carta_animation = carta_prefab.GetComponent<Carta_Animation_Script>();
        player_texto = player.GetComponentInChildren<Text>();
        player_texto.text = "Player: " + player.Pontos;
        dealer_texto = dealer.GetComponentInChildren<Text>();
        dealer_texto.text = "Player: " + dealer.Pontos;
        resultado_texto = resultado.GetComponent<Text>();
        Button_New_Game();
    }
    #region Metodos
    public void Button_Hit(bool vez)
    {
        if (player.Pontos < 21 && stand == false && menu.Pause==false)
        {
            Vector2 pos;
            Transform aux_transform;            audio.sound_flip_card(); 

            Carta_Script aux = baralho.Carta;
            if (vez)
            {
                pos = player_pos;
                player_pos.x += distancia;
                aux_transform = player.transform;
                player.Carta = aux;
                player.Pontuação();
                player.Pontos = verifica_as(player.Pontos);
            }
            else
            {
                pos = dealer_pos;
                dealer_pos.x += distancia;
                aux_transform = dealer.transform;
                dealer.Carta = aux;
                dealer.Pontuação();
                dealer.Pontos = verifica_as(dealer.Pontos);
            }
            carta_animation = Instantiate(carta_prefab, pos, aux_transform.rotation, aux_transform).GetComponent<Carta_Animation_Script>();
            carta_animation.set((aux.Nome + "\nValor: " + aux.Valores.ToString()), aux.Imagem_carta);
            Ganhador();
        }
    }
    public void Button_New_Game()
    {
        if (menu.Pause == false)
        {
            Destroi_Cartas();
            player_pos = player.transform.position;
            dealer_pos = dealer.transform.position;
            player.Pontos = 0;
            dealer.Pontos = 0;
            stand = false;
            Button_Hit(false);
            Button_Hit(true);
            Button_Hit(true);
        }
    }
    public void Button_Stand()
    {
        if (player.Pontos < 21 && stand == false && menu.Pause == false)
        {
            baralho.Is_as = 0;
            do
            {
                Button_Hit(false);
                dealer.Pontuação();
            }
            while (dealer.Pontos <= player.Pontos);
            stand = true;
            Ganhador();
        }
    }
    public void Ganhador()
    {
        if (stand == false)
        {
            if (player.Pontos == 21)
            {
                stand = true;
                player.Vitorias++;
                resultado_texto.color = Color.yellow;
                resultado_texto.text = "Player Wins";
                Instantiate(resultado, transform);
                audio.sound_win();
            }
            if (player.Pontos > 21)
            {
                stand = true;
                dealer.Vitorias++;
                resultado_texto.color = Color.red;
                resultado_texto.text = "Dealer Wins";
                Instantiate(resultado, transform);
                audio.sound_loser();
            }
        }
        else
        {
            if (dealer.Pontos <= 21)
            {
                if (dealer.Pontos > player.Pontos)
                {
                    dealer.Vitorias++;
                    resultado_texto.color = Color.red;
                    resultado_texto.text = "Dealer Wins";
                    Instantiate(resultado, transform);
                    audio.sound_loser();
                }
            }
            else
            {
                player.Vitorias++;
                resultado_texto.color = Color.yellow;
                resultado_texto.text = "Player Wins";
                Instantiate(resultado, transform);
                audio.sound_win();
            }
        }
        player_texto.text = "Player: " + player.Pontos + "\nVitorias:  " + player.Vitorias;
        dealer_texto.text = "Dealer: " + dealer.Pontos + "\nVitorias:  " + dealer.Vitorias;
    }
    void Destroi_Cartas()
    {
        cartas_destruidas = GameObject.FindGameObjectsWithTag("Carta");
        foreach (GameObject aux in cartas_destruidas)
        {
            Destroy(aux);
        }
        cartas_destruidas = new GameObject[0];
        player.Destroi_Cartas();
        dealer.Destroi_Cartas();
        baralho.Destroi_Cartas();
    }
    int verifica_as(int pontos)
    {
        if (baralho.Is_as > 0)
        {
            for (int i = 0; i < baralho.Is_as; i++)
            {
                if (pontos > 21)
                {
                    pontos -= 10;
                }
            }
        }
        return pontos;
    }
    public void Button_New_Game_menu()
    {
        menu.Button_Continuar();
        Button_New_Game();
    }
    #endregion
}
