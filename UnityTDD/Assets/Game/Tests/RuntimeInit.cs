using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeInit : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    static void OnBeforeSplashScreen()
    {
        Debug.Log("Before SplashScreen is shown and before the first scene is loaded.");
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoad()
    {
        Debug.Log("First scene loading: Before Awake is called.");
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoad()
    {
        Debug.Log("First scene loaded: After Awake is called.");
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeInitialized()
    {
        Debug.Log("Runtime initialized: First scene loaded: After Awake is called.");
    }
}
