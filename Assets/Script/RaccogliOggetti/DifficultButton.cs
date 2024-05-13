using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//libreria per usare i bottoni e gli altri elementi grafici
using UnityEngine.UI;
//script che gestisce la difficolt� del gioco nella scena RaccogliOggetti
public class DifficultButton : MonoBehaviour
{
    private Button button;
    private GameManager GameManager;
    public int Difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        //quando viene cliccato controllo la difficolt�, il listener aspetta che venga cliccato il bottone
        button.onClick.AddListener(SetDifficulty);
        //trovo l' oggetto GameManager presente nella scena
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    //Metodo che gestisce la difficolt� privato perch� serve solo in questa classe
    private void SetDifficulty()
    {
        Debug.Log(gameObject.name + " cliccato ");
        GameManager.StartGame(Difficulty);
        
        
    }
}
