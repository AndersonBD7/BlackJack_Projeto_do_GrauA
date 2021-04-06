using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Carta_Animation_Script : MonoBehaviour
{
    #region variaveis
    [SerializeField] private Animator animator;
    [SerializeField] private Text carta_texto;
    [SerializeField] private Image carta_img;
    private string aux_carta_texto;
    private Sprite aux_carta_img;
    #endregion
    #region metodos
    public void set(string texto, Sprite img)
    {
        aux_carta_texto = texto;
        aux_carta_img = img;
        animator.Play("rot carta");
    }
    public void Animation_Rot_Valores()
    {
        carta_texto.text = aux_carta_texto;
        carta_img.sprite = aux_carta_img;
    }
    #endregion
}
