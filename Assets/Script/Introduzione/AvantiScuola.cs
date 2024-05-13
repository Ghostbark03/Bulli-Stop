using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvantiScuola : MonoBehaviour
{
    //Script che abilita il bottone avanti per passare alla scena della Scuola
    //Aspetta tot secondi per essere attivato in modo che l' utente prima legga l' introduzione e poi passi alla scena
    //successiva
    // Start is called before the first frame update
    public Button buttonAvanti;
    void Start()
    {
        buttonAvanti.enabled=false;
        StartCoroutine(AbiltaBottone());
        

    }

    IEnumerator AbiltaBottone()
    {
        yield return new WaitForSeconds(20f);
        buttonAvanti.enabled = true;
    }
}
