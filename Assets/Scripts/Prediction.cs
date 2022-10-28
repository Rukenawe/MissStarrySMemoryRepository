using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prediction : MonoBehaviour
{
    public TextMeshProUGUI predictionText;

   public void ButtonPrediction()
    {
        RandomPrediction();
    }
    
    public void RandomPrediction()
    {
        string[] first = new string[] { "Beware ", "Ask about ", "Stop complaining about ", "Start looking for ", "Feel ", "Follow ", "Get rid of ", "Face " };
        string randomFirst = first[Random.Range(0, first.Length)];
        string[] second = new string[] { "the fox ", "the stars ", "the badger ", "the bad friends ", "the planets ", "the tea ", "the government ", "the scientists " };
        string randomSecond = second[Random.Range(0, second.Length)];
        string[] third = new string[] { "crawling ", "fighting ", "swimming ", "whispering ", "dancing ", "trapped ", "hiding ", "traveling " };
        string randomThird= third[Random.Range(0, third.Length)];
        string[] fourth = new string[] { "in the fields", "in the skies", "in the fog", "at the mall", "at the library", "at your place", "in the afterlife", "online" };
        string randomFourth = fourth[Random.Range(0, fourth.Length)];

        predictionText.text = randomFirst + randomSecond + randomThird + randomFourth;
    }
}
