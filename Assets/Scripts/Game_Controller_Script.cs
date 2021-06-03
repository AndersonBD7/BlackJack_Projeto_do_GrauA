using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller_Script : MonoBehaviour
{
    [SerializeField] private bool Stand = false;
    [SerializeField] private Vector3 Vez_pos = Vector3.zero;
    [SerializeField] private float Distance = 115;
    [SerializeField] int cont = 0;
    
    [Header("Baralho")]
    [SerializeField] private Baralho_Script Baralho;

    [Header("Carta")]
    [SerializeField] GameObject Carta_prefab;
    GameObject[] cartas_destruidas;
    Carta_Animation_Script carta_Animation;

    [Header("Player")]
    [SerializeField] private Player_Script Player;
    //private Vector2 Player_pos = Vector2.zero;

    [Header("Dealer")]
    [SerializeField] private Dealer_Script Dealer;
    //private Vector2 Dealer_pos = Vector2.zero;

    [Header("Menu")] 
    [SerializeField] private Menus_Controller_Script Menus_Controller;

    [Header("Audio")]
    [SerializeField] private Audio_Controller_Script Audio;

    // Start is called before the first frame update
    void Start()
    {
        Button_Reset();
    }

    public void Button_Hit(Base_Players_Script vez)
    {
        if(
            Player.Pontos < 21 && 
            Stand == false && 
            Menus_Controller.Get_Set_Status_Pause == false &&
            cont < 3
          )
        {
            Transform aux_transform = vez.transform;

            vez.Carta = Baralho.Da_Carta(vez);
            vez.Pontuação(); 

            Vector3 pos = Vez_pos;      

            carta_Animation = Instantiate(Carta_prefab, pos, aux_transform.rotation, aux_transform).GetComponent<Carta_Animation_Script>();
            carta_Animation.Id = vez.Carta.Id;

            Audio.sound_flip_card();

            Vez_pos.x += Distance;
          
            cont++;

            Ganhador(vez);
        }
    }

    public void Button_Stand()
    {
        if (Player.Pontos < 21 && Stand == false && Menus_Controller.Get_Set_Status_Pause == false)
        {
            Vez_pos = Dealer.transform.position;
            Vez_pos.x += Distance; 
            cont = 0;

            do
            {
                Button_Hit(Dealer);
            }
            while (Dealer.Pontos <= Player.Pontos);
            
            Stand = true;

            Ganhador(Dealer);
        }
    }

    public void Button_Reset()
    {
        if(Menus_Controller.Get_Set_Status_Pause == false)
        {
            Stand = false;
            cont = 0;

            Player.Reset_game();
            Dealer.Reset_game();
            Baralho.Reset_game();

            cartas_destruidas = GameObject.FindGameObjectsWithTag("Carta"); 
            foreach (GameObject aux in cartas_destruidas)
            {
                Destroy(aux);
            }
          
            cartas_destruidas = new GameObject[0];
          

            Vez_pos = Dealer.transform.position;
            Button_Hit(Dealer);
 
            Vez_pos = Player.transform.position;
            Button_Hit(Player); 
            cont = 1;
            Button_Hit(Player);

            cont = 1;
        }
    }

    void Ganhador(Base_Players_Script vez)
    {
        if (Stand == false)
        {
            if (Player.Pontos == 21)
            {
                Debug.Log("1");
                Stand = true;
                Player.Vitorias++;
                Menus_Controller.Set_Resultado("O Jogador\nGanhou", Color.yellow);
                Audio.sound_win();
            }

            if (Player.Pontos > 21)
            {
                Stand = true;
                Dealer.Vitorias++;
                Menus_Controller.Set_Resultado("A Banca\nGanhou", Color.red);
                Audio.sound_loser();
            }

            if (cont == 3 && vez == Player)
            {
                Button_Stand();
            }
        }
        else
        {
            if (Dealer.Pontos <= 21)
            {
                Stand = true;
                Dealer.Vitorias++;
                Menus_Controller.Set_Resultado("A Banca\nGanhou", Color.red);
                Audio.sound_loser();
            }
            else
            {
                Stand = true;
                Player.Vitorias++;
                Menus_Controller.Set_Resultado("O Jogador\nGanhou", Color.yellow);
                Audio.sound_win();
            }

            if (cont == 3 && vez == Dealer)
            {
                if (Player.Pontos > Dealer.Pontos) 
                {
                    Stand = true;
                    Player.Vitorias++;
                    Menus_Controller.Set_Resultado("O Jogador\nGanhou", Color.yellow);
                    Audio.sound_win();
                }
                if(Player.Pontos == Dealer.Pontos)
                {
                    Stand = true;
                    Player.Vitorias++;
                    Menus_Controller.Set_Resultado("Empate", Color.blue);
                    Audio.sound_win();
                }
            }
        }
    }
}
