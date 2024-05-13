using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script per la vittoria del giocatore quando ha superato tutti i livelli
public class GameManagerScuola : MonoBehaviour
{
    public GameObject WinScreen;
    public AudioSource winAudioSource;
    // Update is called once per frame
    void Update()
    {
        //prendo le informazioni per sapere se ho superato i livelli
        if(PlayerPrefs.GetInt("RaccogliOggetti") == 1&& PlayerPrefs.GetInt("PersonaPiange")==1&&PlayerPrefs.GetInt("ColpisciTasti")==1)
        {
            WinScreen.gameObject.SetActive(true);
            winAudioSource.gameObject.SetActive(true);
            winAudioSource.Play();

        }
    }
}
