using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dealer_Script : MonoBehaviour
{
    #region variaveis
    [SerializeField] private List<Carta_Script> cartas;
    [SerializeField] private int pontos = 0;
    [SerializeField] private int vitorias = 0;
    #endregion
    #region metodos
    public int Pontos { get { return pontos; } set { pontos = value; } }
    public int Vitorias { get { return vitorias; } set { vitorias = value; } }
    public Carta_Script Carta { get { return cartas[cartas.Count - 1]; } set { cartas.Add(value); } }
    public int carta_cont { get { return cartas.Count; } }
    public void Pontuação()
    {
        int i = 0;
        foreach (Carta_Script aux in cartas)
        {
            i += aux.Valores;
        }
        pontos = i;
    }
    public void Destroi_Cartas()
    {
        cartas = new List<Carta_Script>();
    }
#endregion
}
