using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Baralho_Script : MonoBehaviour
{
    #region variaveis
    [SerializeField] private Carta_Script[] baralho = new Carta_Script[52];
    [SerializeField] private List<string> cartas;
    [SerializeField] private int is_as = 0;
    public int Is_as { get { return is_as; } set { is_as = value; } }
    #endregion
    #region metodos
    public Carta_Script Carta
    {
        get
        {
            int i = 0;
            do
            {
                i = Random.Range(0, 51);
            } while (Carta_Repetida(i) == true);

            if (i >= 48)
            {
                is_as++;
            }
            cartas.Add(baralho[i].Nome);
            return baralho[i];
        }
    }
    public void Destroi_Cartas()
    {
        cartas = new List<string>();
        is_as = 0;
    }
    private bool Carta_Repetida(int i)
    {
        foreach (string aux in cartas)
        {
            if (baralho[i].Nome == aux)
            {
                return true;
            }
        }
        return false;
    }
    #endregion
}
