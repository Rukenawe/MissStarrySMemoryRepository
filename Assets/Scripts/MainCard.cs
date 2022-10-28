using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
    [SerializeField] private GameObject Card_Back;
    [SerializeField] private SceneControler controler;

    public void OnMouseDown()
    {
        if (Card_Back.activeSelf && controler.canReveal)
        {
            Card_Back.SetActive(false);
            controler.CardRevealed(this);
        }
    }

    private int _id;
    public int id
    {
        get{ return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    
    public void Unreveal()
    {
        Card_Back.SetActive(true);
    }
}
