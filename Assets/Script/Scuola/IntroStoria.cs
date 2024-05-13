using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//Script che disabilita il testo sull' intro dopo che il giocatore ha cliccato il bottone
//Inoltre abilita le scritte del punteggio e altri dati
public class IntroStoria : MonoBehaviour
{
    
    public TextMeshProUGUI introStoria;
    public TextMeshProUGUI score;
    public TextMeshProUGUI record;
    public TextMeshProUGUI datiGiocatore;
    public Button introButton;
    public void buttonGioca()
    {
        introButton.gameObject.SetActive(false);
        introStoria.gameObject.SetActive(false);
        score.gameObject.SetActive(true);
        record.gameObject.SetActive(true);
        datiGiocatore.gameObject.SetActive(true);
        //abilito il gioco con i movimenti del personaggio
        PlayerPrefs.SetInt("gioco", 1);
    }
}
