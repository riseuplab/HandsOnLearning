using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Question : MonoBehaviour
{

    [Header("Fillup these fields")]
    [SerializeField] string word;
    [SerializeField] Sprite image;
    public int[] hideIndex;


    [Space]
    [Space]

    [SerializeField] GameObject[] ansBoxes;
    [SerializeField] TextMeshProUGUI[] ansTexts;
    [SerializeField] TextMeshProUGUI[] wrongAnsTexts;
    [SerializeField] Image[] fillImages;
    [SerializeField] Image centerImage;

    //private Image fillerSprite;

    public bool startCounting = false;
    public List<string> hiddenWords = new List<string>();

    private void Awake()
    {
        

        for (int i = 0; i < hideIndex.Length; i++)
        {
            fillImages[hideIndex[i] - 1].gameObject.SetActive(true);

            //hiddenChars[i] = word.Substring(hideIndex[i - 1], 1);
            hiddenWords.Add(word.Substring(hideIndex[i] - 1, 1));
        }

        

        Setup();
    }

    /*private void Update()
    {
        if (startCounting)
        {
            for (int i = 0; i < hideIndex.Length; i++)
            {
                fillImages[hideIndex[i] - 1].fillAmount -= (Time.deltaTime) / GamePlayManager.instance.revealTime;
            }
        }
    }*/

    public void Setup()
    {
        centerImage.sprite = image;

        for (int i = 0; i < ansBoxes.Length; i++)
        {
            ansBoxes[i].SetActive(false);
        }
        for (int i = 0; i < word.Length; i++)
        {
            ansBoxes[i].SetActive(true);
            ansTexts[i].text = word.Substring(i, 1);
        }
    }

    public void FoundAtPosition(int index)
    {
        
            fillImages[index].enabled = false;
            fillImages[index].gameObject.transform.parent.GetComponent<Image>().color = Color.green;
        
    }

    public void FoundWrongAns(int index, string input)
    {
        
            wrongAnsTexts[index].text = input.ToString();
            wrongAnsTexts[index].gameObject.transform.parent.GetComponent<Image>().color = Color.red;

       
    }

}
