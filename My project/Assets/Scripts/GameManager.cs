using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton used to pass data around (Temp solution)
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Guitar data
    public static Strings[] STRINGS = new Strings[6];

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
    
        DontDestroyOnLoad(gameObject);

        instance = this;
    }
}
