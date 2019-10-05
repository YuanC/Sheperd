using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBarkTest : MonoBehaviour
{
    private void Start()
    {
        EventManager.StartListening("BARK", Baa);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("BARK", Baa);
    }

    private void Baa() 
    {
        print("BAAAAAAAA");
    }
}
