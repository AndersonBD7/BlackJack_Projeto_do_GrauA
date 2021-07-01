using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Naipes
{
    Copas,
    Espadas,
    Ouro,
    Paus
}
[CreateAssetMenu(fileName = "Nova Carta", menuName = "Carta")]
public class Carta_Script : ScriptableObject
{
    [SerializeField] private int valores = 0;
    [SerializeField] private Naipes naipe = Naipes.Copas;
    [SerializeField] private int id = 0;

    public int Valores
    {
        get
        {
            return valores;
        }

        set
        {
            valores = value;
        }
    }

    public Naipes Naipe
    {
        get
        {
            return naipe;
        }

        set
        {
            naipe = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

}
