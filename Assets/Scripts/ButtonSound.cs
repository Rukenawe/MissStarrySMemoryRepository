using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource source;

    public void OnPointerEnter(PointerEventData eventData)
    {
        source.Play();
    }
}