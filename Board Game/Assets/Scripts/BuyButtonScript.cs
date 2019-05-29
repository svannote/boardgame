using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class BuyButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!Property.bought)
        {
            Buy();
        }
    }

    public void Buy()
    {
        Property.bought = true;
    }
}
