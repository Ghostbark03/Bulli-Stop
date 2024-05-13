using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class visualizzaDati : MonoBehaviour
{
    //script che visualizza nome e cognome del giocatore
    public TextMeshProUGUI nomeEcognomeText;
    // Start is called before the first frame update
    public  void Start()
    {
        
        nomeEcognomeText = GetComponent<TextMeshProUGUI>();
        nomeEcognomeText.text = "Benvenuto " + PlayerPrefs.GetString("NomePlayer","") + " " + PlayerPrefs.GetString("CognomePlayer", "");
    }
}
