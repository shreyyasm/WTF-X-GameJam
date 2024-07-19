using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private char data;
    [SerializeField]private TMP_Text Wordtext;

        private void Awake()
        {
            Wordtext = GetComponent<TMP_Text>();
        }
        public void SetData(char data){
            Wordtext.text = data + "";
            this.data = data;
        }
        public char GetData(){
            return this.data;
        }
}
