using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReloadProtection : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
