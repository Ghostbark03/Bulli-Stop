using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//librerie per serializzare
using System.IO;
using System;
//script che salva i dati che l' utente ha inserito in un file .json
public class SalvataggioDati : MonoBehaviour
{
  
    public void Salva()
    {
        //alloco in memoria l' oggetto di tipo salvataggio
        Salvataggio datisalva = new Salvataggio();
        datisalva.nome = PlayerPrefs.GetString("NomePlayer");
        datisalva.cognome= PlayerPrefs.GetString("CognomePlayer");
        datisalva.nazionalit‡ = PlayerPrefs.GetString("Nazionalit‡Player");
        datisalva.bullismo = PlayerPrefs.GetString("BullismoPlayer");
        datisalva.sesso = PlayerPrefs.GetString("SessoPlayer");

        string json = JsonUtility.ToJson(datisalva);
        //Scrivo il file mettendolo nella cartella dove sta l' applicazione
        File.WriteAllText(Application.persistentDataPath + "/dati.json",json);
        Debug.Log( "Writing file"+ Application.persistentDataPath);
    }
    
}
[Serializable]
public class Salvataggio
{
    public string nome;
    public string cognome;
    public string nazionalit‡;
    public string bullismo;
    public string sesso;
}
