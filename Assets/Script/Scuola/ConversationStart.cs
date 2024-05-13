using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//libreria per i dialoghi
using DialogueEditor;

public class ConversationStart : MonoBehaviour
{
    //script che avvia i dialoghi con i bulli Nicolas,Dutu e Gina
    [SerializeField] private NPCConversation myConversation;
    //posso interagire con il personaggio solo se non ho ancora superato la sua sfida
    private int livellosuperato;
    public GameObject bullo;
    public void Start()
    {
        if(bullo.name=="Nicolas")
        {
            livellosuperato = PlayerPrefs.GetInt("RaccogliOggetti");
            Debug.Log("Nicola" + livellosuperato);
        }
        if(bullo.name=="Dutu")
        {
            livellosuperato = PlayerPrefs.GetInt("PersonaPiange");
        }
        if(bullo.name=="Gina")
        {
            livellosuperato = PlayerPrefs.GetInt("ColpisciTasti");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        //aggiungere il tag al game object
        if (other.CompareTag("Studente"))
        {
            //è possibile dialogare solo se il relativo livello non è stato
            //superato(0) quando si preme il tasto F ha inizio il dialogo
            //se superato la variabile sarà ad 1
            if (Input.GetKeyDown(KeyCode.F)&&livellosuperato==0)
            {              
                ConversationManager.Instance.StartConversation(myConversation);
            }           
        }
    }
}
