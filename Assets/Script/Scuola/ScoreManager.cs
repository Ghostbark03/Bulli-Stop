using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//includerla per usare textmeshpro
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Così si può chiamare il metodo SceltaPunti anche da altri script
    public static ScoreManager instance;
    //punteggio del giocatore in quella partita
    public TMP_Text ScoreText;
    //punteggio massimo raggiunto
    public TMP_Text RecordText;
    public int Score=0;
    public int Record=0;
    public GameObject WinScreen;
    public void Start()
    {
        //controllo esito dei minigiochi
        int esitogioco = PlayerPrefs.GetInt("esitopartita");
        if (esitogioco == 1)
        {
            AggiornaPunti();
        }
        ScoreText.text = Score.ToString() + "POINTS";
        //Se il punteggio record viene superato viene aggiornato e salvato per le partite successive
        if (Record < Score)
        {
            PlayerPrefs.SetInt("highscore", Score);
        }
        else
        {
            RecordText.text = "HIGHSCORE:" + Record.ToString();
        }
    }
    //istanza script prima che venga chiamato lo start
    private void Awake()
    {
        instance = this;
    }
    public void Update()
    {
        //se il gioco è vinto allora compare il finale della storia
        if(Score==30)
        {
            WinScreen.gameObject.SetActive(true);
        }
    }
    public void AggiornaPunti()
    {
        Score += 10;
        
    }
    
}
