using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InserisciDati : MonoBehaviour
{
    //Script che chiede l' inserimento del nome e del cognome e abilta bottone per andare sull' introduzione
    public TMP_InputField inputFieldnome;
    public TMP_InputField inputFieldCognome;
    public Button ButtonAvanti;
    public bool inserimentoNome=false;
    public bool inserimentoCognome=false;
    public bool inserimentoNazionalità = false;
    public bool inserimentoBullismo = false;
    public bool inserimentoSesso = false;
    public TMP_Dropdown DropdownNazionalità;
    public TMP_Dropdown DropdownBullismo;
    public TMP_Dropdown DropdownSesso;
    public TextMeshProUGUI AvvisoText;
    public void Start()
    {
        //Il bottone è visibile solo quando sono stati inseriti nome e cognome
        ButtonAvanti.gameObject.SetActive(false);
        //metto a 0 così i dati di partite precedenti vengono persi
        PlayerPrefs.SetInt("gioco", 0);
        PlayerPrefs.SetInt("RaccogliOggetti", 0);
        PlayerPrefs.SetInt("PersonaPiange", 0);
        PlayerPrefs.SetInt("ColpisciTasti", 0);
    }
    private void Update()
    {
        //se  i metodi sono stati chiamati e i campi sono stati compilati abilito il bottone
        if (inserimentoNome == true && inserimentoCognome == true && inserimentoNazionalità == false&&inserimentoBullismo==false&&inserimentoSesso==false)
        {
            ButtonAvanti.gameObject.SetActive(true);
            AvvisoText.gameObject.SetActive(false);
            //seleziono le opzioni di default così se non seleziona nessuna opzione si
            //prendono quelle di default
            PlayerPrefs.SetString("NazionalitàPlayer", "Italia");
            PlayerPrefs.SetString("BullismoPlayer", "Si");
            PlayerPrefs.SetString("SessoPlayer", "Maschio");
        }
        
    }

    public void InsertName(string nome)
    {
        
        nome = inputFieldnome.text;
        if(!string.IsNullOrWhiteSpace(nome))
        {
            //controllo che l' utente non abbia solamente cliccato l' input field
            //senza scrivere niente
            if(nome!= "Inserisci il tuo nome")
            {
                inserimentoNome = true;
                Debug.Log("Nome:" + nome);
                //salvo nome e cognome nelle preferenze
                PlayerPrefs.SetString("NomePlayer", nome);
            }
                
        }
        
    }
    public void InsertCognome(string cognome)
    {
        cognome = inputFieldCognome.text;
        if(!string.IsNullOrWhiteSpace(cognome))
        {
            if(cognome!= "Inserisci il tuo cognome")
            {
                inserimentoCognome = true;
                Debug.Log("Cognome:" + cognome);
                PlayerPrefs.SetString("CognomePlayer", cognome);
            }
            
            
        }
        
    }
    public void InsertNazionalità()
    {
        //ricavo l' opzione selezionata tramite il suo indice
        //value è l' indice dell' opzione selezionata
        int indice = DropdownNazionalità.value;
        string nazionalità = DropdownNazionalità.options[indice].text;
        Debug.Log("Nazionalità: " + nazionalità);
        PlayerPrefs.SetString("NazionalitàPlayer", nazionalità);
        inserimentoNazionalità = true;
        
    }
    public void InsertBullismo()
    {
        //ricavo l' opzione selezionata tramite il suo indice
        //value è l' indice dell' opzione selezionata
        int indice = DropdownBullismo.value;
        string bullismo = DropdownBullismo.options[indice].text;
        Debug.Log("Bullismo: " + bullismo);
        PlayerPrefs.SetString("BullismoPlayer", bullismo);
        inserimentoBullismo = true;
    }
    public void InsertSesso()
    {
        //ricavo l' opzione selezionata tramite il suo indice
        //value è l' indice dell' opzione selezionata
        int indice = DropdownSesso.value;
        string sesso = DropdownSesso.options[indice].text;
        Debug.Log("Sesso: " + sesso);
        PlayerPrefs.SetString("SessoPlayer", sesso);
        inserimentoSesso = true;
    }
}
