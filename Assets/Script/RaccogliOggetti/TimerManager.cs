using System;
using System.Collections;
using System.Collections.Generic;
//libreria da includere per usare TextMeshProUGUI
using TMPro;
using UnityEngine;
//obbligatoria una TextMeshProUGUI
[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerManager : MonoBehaviour
{
    //script che decrementa il timer mano a mano che scorre il temp
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private string formatString = @"mm\:ss";
    public float timer = 20;
    public void Start()
    {
        
        timerText = GetComponent<TextMeshProUGUI>();
    }
  
    // Update is called once per frame
    public void Update()
    {
        
        //il tempo inizia a scorrere dopo che ho scelto la difficoltà e abilitato il timer
        //Se il tempo è scaduto, deve smettere di scorrere
        //Messo 1 perchè il timer essendo float non è mai 0 preciso
        if (timerText!=null&&timer>1&&timerText.isActiveAndEnabled)
        {
            
            timer -= Time.deltaTime;
            TimeSpan ts = TimeSpan.FromSeconds(timer);
            //il testo è uguale al valore del timer
            timerText.text = ts.ToString(formatString);
            //Debug.Log(timer);
        }
        
    }
}

