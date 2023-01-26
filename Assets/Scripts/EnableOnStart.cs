using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
    public GameObject toActivate;

    // Start is called before the first frame update
    void Start() {
        if ( toActivate != null) {
            toActivate.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
