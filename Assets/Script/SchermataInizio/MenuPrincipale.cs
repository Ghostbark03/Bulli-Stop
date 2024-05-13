using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//libreria per usare lo SceneManager
using UnityEngine.SceneManagement;

public class MenuPrincipale : MonoBehaviour
{
    
    public void CaricaSchermatainizio()
    {
        SceneManager.LoadScene("Schermatainizio");
    }
    //Quando dalla scena schermataInizio viene cliccato il bottone Inizia si accede all' inserimento dei dati
    public void CaricaInserimentoDati()
    {
        SceneManager.LoadScene("InserisciDati");
    }
    //Metodo chiamato dal bottone avanti sulla scena Inserimento Nome
    public void CaricaScuola()
    {
        SceneManager.LoadScene("Scuola");
    }
    //quando viene cliccato bottone opzioni le carica
    public void CaricaOpzioni()
    {
        SceneManager.LoadScene("Opzioni");
    }
    public void CaricaCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    //Quando viene cliccato bottone esci il gioco viene chiuso
    public void Esci()
    {
        Application.Quit();
    }
    //quando dalla scena credits si clicca il bottone si torna alla schermata principale
    public void Credits()
    {
        SceneManager.LoadScene("Schermatainizio");
    }
    //quando dalla scena InserisciNome si clicca il bottone si inizia l' introduzione
    public void Introduzione()
    {
        SceneManager.LoadScene("Introduzione");
    }
    //se il giocatore accetta la sfida verrà caricata la scena del minigioco
    public void CaricaRaccogliOggetti()
    {
        SceneManager.LoadScene("RaccogliOggetti");
    }
    public void CaricaPersonaPiange()
    {
        SceneManager.LoadScene("PersonaPiange");
    }
    public void CaricaColpisciTasti()
    {
        SceneManager.LoadScene("ColpisciTasti");
    }
}
