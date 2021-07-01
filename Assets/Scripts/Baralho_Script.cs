using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baralho_Script : MonoBehaviour
{
    [SerializeField] private Carta_Script[] baralho = new Carta_Script[52];
    [SerializeField] private List<int> cartas;

    public void Reset_game()
    {
        cartas = new List<int>();
    }

    private bool Carta_Repetida(int i)
    {
        foreach (int aux in cartas)
        {
            if (baralho[i].Id == aux)
            {
                return true;
            }
        }
        return false;
    }

    public Carta_Script Da_Carta(Base_Players_Script base_Players)
    {
        int i = 0;

        do
        {
            i = Random.Range(0, 51);
        } while (Carta_Repetida(i) == true);

        if (i <= 3)
        {
            base_Players.As_in_Hand++;
        }

        cartas.Add(baralho[i].Id);
        return baralho[i];
    }
}
