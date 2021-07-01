using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Players_Script : MonoBehaviour
{
    [SerializeField] private List<Carta_Script> cartas;
    public int pontos = 0;
    public int vitorias = 0;
    [SerializeField] private int as_in_Hand = 0;

    public int Pontos
    {
        get
        {
            return pontos;
        }

        set
        {
            pontos = value;
        }
    }

    public int Vitorias
    {
        get
        {
            return vitorias;
        }

        set
        {
            vitorias = value;
        }
    }

    public int As_in_Hand
    {
        get
        {
            return as_in_Hand;
        }
        set
        {
            as_in_Hand = value;
        }
    }

    public Carta_Script Carta
    {
        get
        {
            return cartas[cartas.Count - 1];
        }

        set
        {
            cartas.Add(value);
        }
    }

    public int Carta_cont
    {
        get
        {
            return cartas.Count;
        }
    }

    public void Pontuação()
    {
        int i = 0;
        foreach (Carta_Script aux in cartas)
        {
            i += aux.Valores;
        }
        pontos = i;

        if (as_in_Hand > 0)
        {
            for (int j = 0; j < as_in_Hand; j++)
            {
                if (pontos > 21)
                {
                    pontos -= 10;
                }
            }
        }
    }

    public void Reset_game()
    {
        cartas = new List<Carta_Script>();
        as_in_Hand = 0;
        pontos = 0;
    }

    public void New_Game()
    {
        Reset_game();
        vitorias = 0;
    }
}
