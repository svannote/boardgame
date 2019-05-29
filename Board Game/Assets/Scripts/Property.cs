using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour
{
    public static bool bought = false;

    void Update()
    {
        if (bought)
        {
            if (RollDie.whosTurn == 1)
            {
                ///make graphic
            }
        }
    }
    
}
