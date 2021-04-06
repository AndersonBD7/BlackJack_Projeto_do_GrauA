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
    #region variaveis
    [SerializeField] private string nome = "Sem Nome";
    [SerializeField] private int valores = 0;
    [SerializeField] private Naipes naipe = Naipes.Copas;
    [SerializeField] private Sprite imagem;
    #endregion 
    #region metodos
    public string Nome { get { return nome; } set { nome = value; } }
    public int Valores { get { return valores; } set { valores = value; } }
    public Naipes Naipe { get { return naipe; } set { naipe = value; } }
    public Sprite Imagem_carta { get { return imagem; } set { imagem = value; } }
    #endregion
}
