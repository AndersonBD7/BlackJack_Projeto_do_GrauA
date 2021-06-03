using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Automatic_Script : MonoBehaviour
{
    [SerializeField] private float Time_Destroy = 0;
    
    public void Auto_Destroy()
    {
        Destroy(gameObject, Time_Destroy);
    }
}
