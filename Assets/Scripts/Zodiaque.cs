using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zodiaque : MonoBehaviour
{
    public Image signe;
    public Button button;
    public int alpha = 255;
    public int beta = 0;

    public void OnMouseEnter()
    {
        signe.color = new Color(0f, 0f, 0f, alpha);  
    }

    public void OnMouseExit()
    {
        signe.color = new Color(0f, 0f, 0f, beta);
    }
}
