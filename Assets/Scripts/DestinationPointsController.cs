using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPointsController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] destPointsNonStatic;
    public static Transform[] destPoints;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Start()
    {
        destPoints = destPointsNonStatic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
