using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistruggiParticelle : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        //1 � il tempo in secondi  dopo il quale le particelle vengono distrutte
        Destroy(gameObject, 1);
    }
    private void Update()
    {
        
    }
}