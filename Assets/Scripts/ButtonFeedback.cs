using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFeedback : MonoBehaviour
{
    public GameObject fireworksEffect;
    public Transform fireworks;
    
    public void FeedbackFireworks()
    {
        GameObject effect = (GameObject)Instantiate(fireworksEffect, fireworks.position, Quaternion.identity);
        Destroy(effect, 5f);
    }
}
