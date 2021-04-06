using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Resultado_Script : MonoBehaviour
{
    [SerializeField] private float life = 3;
    void Start()
    {
        Destroy(gameObject, life);
    }
}
