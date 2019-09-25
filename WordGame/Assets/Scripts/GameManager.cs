using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Vuforia;
public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [SerializeField] Transform question_parent;
    [SerializeField] Animator clearPromtAnim;
    [SerializeField] GameObject[] questionPanels;

    private GameObject _currentLoadedQuestion;
    private Animator _currentQuestionAnim;
    public int currentTrackerCount = 0;
    public int qIndex = 0;
    [SerializeField]private int count;

    //For Reference
    public Question currentQuestion;
    [SerializeField] TextMeshProUGUI debugText;

    public int matchFoundCount;
    private int wrongIndex = 0;

    [Header("Score")]
    //Score 
    [SerializeField] TextMeshProUGUI playerOneText;
    [SerializeField] TextMeshProUGUI playerTwoText;

    Animator playerOneAnim, playerTwoAnim;
    private int playerOneScore, playerTwoScore;

    //Focusing fix
    [HideInInspector]public bool isFocusDone = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _currentLoadedQuestion = Instantiate(questionPanels[qIndex], question_parent);
        _currentQuestionAnim = _currentLoadedQuestion.GetComponent<Animator>();
        //_currentQuestionAnim.Play("OnScreen");
        currentQuestion = _currentLoadedQuestion.GetComponent<Question>();
        //count = currentQuestion.hiddenWords.Count;

        playerOneAnim = playerOneText.gameObject.transform.parent.GetComponent<Animator>();
        playerTwoAnim = playerTwoText.gameObject.transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            LoadNextQuestion();


        debugText.text = "OnScreen Tracker Count: " + currentTrackerCount.ToString();

        //dui number fix
        if(Input.GetKeyDown(KeyCode.A))
        {
            playerOneAnim.StopPlayback();
            playerOneAnim.Play("ScoreInc");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerTwoAnim.StopPlayback();
            playerTwoAnim.Play("ScoreInc");
        }

    }

    public void LoadNextQuestion()
    {
        StartCoroutine(WaitToLoadNextQuestion());
    }

    IEnumerator WaitToLoadNextQuestion()
    {
        yield return new WaitForSeconds(0.5f);
        clearPromtAnim.Play("OnScreen");
        yield return new WaitForSeconds(0.5f);
        Destroy(_currentLoadedQuestion.gameObject);

        while (currentTrackerCount > 0)
        {
            yield return 0;
        }

        

        if (currentTrackerCount <= 0)
        {
            yield return new WaitForSeconds(0.5f);
            clearPromtAnim.Play("OffScreen");

            
            yield return new WaitForSeconds(0.5f);
            

            qIndex++;
            if (qIndex >= questionPanels.Length)
                qIndex = 0;

            matchFoundCount = 0;
            wrongIndex = 0;
            
            _currentLoadedQuestion = Instantiate(questionPanels[qIndex], question_parent);
            currentQuestion = _currentLoadedQuestion.GetComponent<Question>();
            //count = currentQuestion.hiddenWords.Count;
            _currentQuestionAnim = _currentLoadedQuestion.GetComponent<Animator>();
            _currentQuestionAnim.Play("OnScreen");
        }
       
    }

    public void CheckInput(string input, int playerIndex)
    {
        count = currentQuestion.hiddenWords.Count;
        for (int i = 0; i < count; i++)
        {
            if (input == currentQuestion.hiddenWords[i]) ////////MATCH FOUND!!
            {
                currentQuestion.FoundAtPosition(currentQuestion.hideIndex[i + matchFoundCount] - 1);
                matchFoundCount++;
                print("match");


                SoundManager.instance.PlayRightAnsSound();


                //Score Count
                if(playerIndex == 0)
                {
                    playerOneScore++;
                    playerOneText.text = "P1: " + playerOneScore;
                    playerOneAnim.Play("ScoreInc");
                }
                else
                {
                    playerTwoScore++;
                    playerTwoText.text = "P2: " + playerTwoScore;
                    playerTwoAnim.Play("ScoreInc");
                }

                currentQuestion.hiddenWords.Remove(input);
                if (currentQuestion.hiddenWords.Count <= 0)
                    LoadNextQuestion();
                return;
            }

        }
        currentQuestion.FoundWrongAns(wrongIndex, input);
        wrongIndex++;

        SoundManager.instance.PlayWrongAnsSound();
    }

    public void TriggerFocus()
    {
        if(!isFocusDone)
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
            isFocusDone = true;
        }
    }
}
