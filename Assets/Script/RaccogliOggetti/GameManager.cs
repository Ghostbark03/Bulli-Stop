using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//libreria che servirà per far ripartire la scena cliccando il bottone restart
using UnityEngine.SceneManagement;
//libreria che serve per usare i bottoni e altri elementi UI
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Game Manager per il minigioco RaccogliOggetti
    //Tempo massimo che rappresenta l' inizio del gioco(in secondi)
    //Ricordarsi di cambiare eventualmente anche il timer presente in TimeManager, sia nello script
    //che nell' inspector
    [SerializeField] public float maxTime=20;
    public float timer;
    private float _punteggioMassimo=3;
    private int _miopunteggio;
    //lista con gli oggetti da cliccare sul minigioco
    public List<GameObject> cliccaoggetti;
    private float spawnRate = 1.0f;
    //booleano serve così l' update non svolge più volte le stesse operazioni
    public bool vinto = false;
    public bool perso = false;
    public TextMeshProUGUI punteggioText;
    public TextMeshProUGUI GameOver;
    public Button restartGame;
    public TextMeshProUGUI WinText;
    public Button EsciLivello;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI moraleText;
    public AudioSource winAudioSource;
    public AudioSource gameOverAudioSource;
    //oggetto che contiene il titolo e i bottoni per i livelli di difficoltà
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        //il tempo iniziale è quello massimo, non lo metto su start game sennò il timer parte a 0 e mi
        //dice che ho perso
        timer = maxTime;
        
    }
    //il gioco parte dopo che ho scelto la difficoltà
    public void StartGame(int difficoltà)
    {
        Debug.Log("Start game");
        punteggioText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        StartCoroutine(SpawnTarget());
        //cerco l' oggetto tramite tag PunteggioText
        punteggioText = GameObject.FindGameObjectWithTag("PunteggioText").GetComponent<TextMeshProUGUI>();
        punteggioText.text = "Punteggio: 0";
        //tolgo il titolo e i bottoni difficoltà quando inizia il gioco
        titleScreen.gameObject.SetActive(false);
        //più il numero spawnRate è piccolo più gli oggetii spawnano velocemente
        spawnRate /= difficoltà;
    }
    // Update is called once per frame
    void Update()
    {
        if(timerText.isActiveAndEnabled)
        {
            //ogni secondo il tempo cala
            timer -= Time.deltaTime;
            if (timer <= 0 && vinto == false && perso == false)
            {
                //Controllo il punteggio, se è almeno il 60% di quello massimo ho vinto, altrimenti ho perso
                float punteggiominimo = (_punteggioMassimo / 100) * 60;
                if (_miopunteggio < punteggiominimo)
                {
                    LoseLevel();
                }
                else
                {
                    WinLevel();
                }
            }
        }
               
    }
    //Co routine che esegue operazioni frame per frame senza bloccare le altre funzioni del gioco
    IEnumerator SpawnTarget()
    {
        //Se la partita è finita non devono più spawnare oggetti
        while(vinto==false&&perso==false)
        {
            //deve aspettare i secondi pari a spawnRate prima di eseguire i compiti
            yield return new WaitForSeconds(spawnRate);
            //istanzio un oggetto di tipo casuale tramite random
            int index = Random.Range(0, cliccaoggetti.Count);
            Instantiate(cliccaoggetti[index]);
        }
    }
    //aggiorno punteggio in base al valore dell' oggetto
    public void AggiornaPunti(int punteggio)
    {
        //incremento il punteggio se ho colpito gli oggetti giusti
        _miopunteggio += punteggio;
        punteggioText.text = "Punteggio "+_miopunteggio;
    }
    public void WinLevel()
    {
        Debug.Log("Hai vinto con il punteggio di"+_miopunteggio);
        vinto = true;
        WinText.gameObject.SetActive(true);
        EsciLivello.gameObject.SetActive(true);
        moraleText.gameObject.SetActive(true);
        //servirà per aggiornare il punteggio principale ricaricata la scena scuola
        PlayerPrefs.SetInt("RaccogliOggetti", 1);
        winAudioSource.gameObject.SetActive(true);
        winAudioSource.Play();
    }
    public void LoseLevel()
    {
        Debug.Log("Hai perso con il punteggio di"+_miopunteggio);
        perso = true;      
        //abilito la scritta gameover ricordarsi di associarla sull' inspector, via codice non si può 
        //cercarla con GetComponent perchè non è abilitata
        GameOver.gameObject.SetActive(true);
        //idem per il bottone
        restartGame.gameObject.SetActive(true);
        //servirà per aggiornare il punteggio principale ricaricata la scena scuola
        PlayerPrefs.SetInt("esitopartita", 0);
        gameOverAudioSource.gameObject.SetActive(true);
        gameOverAudioSource.Play();

    }
    //metodo che serve per far ripartire la scena cliccando il bottone restart
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
