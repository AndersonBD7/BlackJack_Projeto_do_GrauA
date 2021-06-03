using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta_Animation_Script : MonoBehaviour
{

    [SerializeField] private Sprite[] Carta_Naipes = new Sprite[4];
    [SerializeField] private Text Carta_numero;
    [SerializeField] private Text Carta_numero2;
    [SerializeField] private Image Carta_image;
    [SerializeField] private int id = 0;

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

    // Start is called before the first frame update
    void Start()
    {
        Carta_numero = GetComponentInChildren<Text>();
        Carta_image = GetComponentInChildren<Image>();
    }

    public void Set_Carta()
    {
        if (id <= 13)
        {
            Carta_image.sprite = Carta_Naipes[0];
            Carta_numero.color = Color.red;
        }
        else if (id >= 14 && id <= 26)
        {
            Carta_image.sprite = Carta_Naipes[1];
            Carta_numero.color = Color.black;
            id -= 13;
        }
        else if (id >= 27 && id <= 39)
        {
            Carta_image.sprite = Carta_Naipes[2];
            Carta_numero.color = Color.red;
            id -= (2 * 13);
        }
        else
        {
            Carta_image.sprite = Carta_Naipes[3];
            Carta_numero.color = Color.black;
            id -= (3 * 13);
        }
        switch (id)
        {
            case 1:
                Carta_numero.text = "A";
                break;
            case 11:
                Carta_numero.text = "J";
                break;
            case 12:
                Carta_numero.text = "Q";
                break;
            case 13:
                Carta_numero.text = "K";
                break;
            default:
                Carta_numero.text = id.ToString();
                break;
        }
        Carta_numero2.text = Carta_numero.text;
        Carta_numero2.color = Carta_numero.color;
    }
}
