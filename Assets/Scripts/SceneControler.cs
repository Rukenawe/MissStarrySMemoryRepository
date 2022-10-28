using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneControler : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 6;
    public const float offsetX = 2f;
    public const float offsetY = 3.25f;

    public float progress = 0f;
    public Image fillingImage;
    public GameObject buttonNextLVL;

    public Transform fireworks;
    public GameObject fireworksEffect;

    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if(i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    public TextMeshProUGUI largeText;
    public IEnumerator CheckMatch()
    {
        if(_firstRevealed.id == _secondRevealed.id)
        {
            SliderValue();

            FeedbackFireworks();

            string[] dialogues = new string[] { "No... not quite...", "Go on, go on...", "WAIT! Oh, no, sorry, go on...", "Let me see, let me see, let me see...", "Almost there...", "Let the cards speak...", "Trust the cards...", "The cards never lie, honey!", "Ooh, did you feel it?", "Pay attention...", "Nice!", "Alright, yes!", "Makes sense...", "Of course!", "Hahaha, okay, honey, alright...", "Come on, come on, come on!", "Feel. The power. OF THE CARDS!", "Yes!" };
            string randomDialogues = dialogues[Random.Range(0, dialogues.Length)];
            largeText.text = randomDialogues;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

    public void SliderValue()
    {
        progress++;
        fillingImage.fillAmount = progress / 6f;

        if(progress >= 6f)
        {
            buttonNextLVL.SetActive(true);
        }
    }

    public void FeedbackFireworks()
    {
        GameObject effect = (GameObject)Instantiate(fireworksEffect, fireworks.position, Quaternion.identity);
        Destroy(effect, 5f);
    }
}
