using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{

    [SerializeField]private QuestionData question;
    [SerializeField]private GameObject word;
    [SerializeField]private GameObject letter;
    [SerializeField]private LetterData[] Letters;
    [SerializeField]private Transform[] Words;
    [SerializeField]private char[] charArray;
    private int NoOfWords = 1;
    private int NoOfLetters = 0;




    [Header("Input_Field")]
    [SerializeField]private int WordIndex = 0;
    [SerializeField]private int LetterIndex =0;
    [SerializeField]private int LetterInitialIndex =0;
    
    private void SetQuestion()
    {
        
        for(int i = 0; i < question.answer.Length; i++){            //Counting Total numbers of letters and words in the sentance.
            if(question.answer[i] == ' ')
            {
                NoOfWords++;
            }
            else{
                NoOfLetters++;
            }
        }
        
        Words = new Transform[NoOfWords];                   // giving the size of the array for words;
        charArray = new char[NoOfLetters];       // Storing the question in the permanat array to compare later.
        Letters = new LetterData[NoOfLetters];              // giving the size of the array for Letters;
        Debug.Log("Words: " + Words.Length);
        Debug.Log("Letters: " + Letters.Length);

        NoOfWords=0;
        NoOfLetters=0;                                      // Resetting the values so that they can be used below;        

        GameObject init = Instantiate(word,this.transform); 
        Words[NoOfWords] = init.transform;
         
        for(int i = 0; i < question.answer.Length; i++)
        {
            // Debug.Log("i : " +i);
            // Debug.Log("start loop NoOfWords: " +NoOfWords);
            
            if(question.answer[i] == ' ')
            {
                NoOfWords++;
                GameObject obj = Instantiate(word,this.transform);
                Words[NoOfWords] = obj.transform;
            }
            else
            {
                charArray[NoOfLetters] = question.answer[i];
                GameObject obj = Instantiate(letter,Words[NoOfWords]);
                Letters[NoOfLetters] = obj.GetComponent<LetterData>();
                Letters[NoOfLetters].SetData('?');
                NoOfLetters++;
            }
            // Debug.Log("after loop NoOfWords: " +NoOfWords);
        }

    }
    #region Input


        int count1=0;
    public void SetInput(char c){
        if(count1 >= Words[WordIndex].childCount)
        {
            // Check();
            Debug.Log("Full");
        }else
        {
            Letters[LetterIndex].SetData(c);
            LetterIndex++;
            count1++;
            if(count1 >= Words[WordIndex].childCount){Check();}
        }
        Debug.Log(count1);
    }

    #endregion



    #region Check
    public void Check()
    {
        
        int count = 0;
        for(int i = LetterInitialIndex; i < Words[WordIndex].childCount+LetterIndex; i++)
        {
            Debug.Log("Letter "+Letters[i].GetData());
            Debug.Log("Chararray "+charArray[i]);
            Debug.Log("Count "+count);
            if(Letters[i].GetData() == charArray[i])
            {
                count++;
                if(count >= Words[WordIndex].childCount)
                {
                    ColorChange("Right");
                    WordIndex++;
                    LetterInitialIndex = LetterIndex;
                    count1 = 0;
                    if(WordIndex >= Words.Length)
                    {
                        Debug.Log("Finish");   // Winning panel goes here;
                    }
                    break;
                }
            }
            else if(Letters[i].GetData() != charArray[i])
            {
                ColorChange("Wrong");
                count1 = 0;
                LetterIndex = LetterInitialIndex;
                ResetQuestion();
                Debug.Log("Restet");
            }
        }
    }

    #endregion

    public void ResetQuestion(){
        for(int i = LetterInitialIndex; i < Words[WordIndex].childCount+LetterInitialIndex; i++)
        {
            Letters[i].SetData('?');
        }
    }
    public void ColorChange(string s)
    {
        for(int i = LetterInitialIndex; i < Words[WordIndex].childCount+LetterInitialIndex;i++)
        {
            Letters[i].GetComponent<Animator>().SetTrigger(s);
        }
    }


    private void Update() {
        if(Input.GetKeyDown(KeyCode.U)){SetInput('g');}
    }
    void Start()
    {
        // letter = word.gameObject.transform.GetChild(0).gameObject;
        SetQuestion();
    }
}

[System.Serializable]
public class QuestionData{
public string answer;
}