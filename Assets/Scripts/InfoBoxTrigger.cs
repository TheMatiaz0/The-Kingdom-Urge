using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoxTrigger : MonoBehaviour
{
    private GameObject infoBoxObject = null;

    void Start()
    {
        // infoBoxObject = GameObject.FindGameObjectWithTag("InfoBox");
    }

    private void OnMouseEnter()
    {
        Debug.Log("To działa!");
    }
}
