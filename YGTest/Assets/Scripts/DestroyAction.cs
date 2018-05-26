using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour {
    public System.Action DestroyA;
    private void OnDestroy()
    {
        if (DestroyA != null)
            DestroyA();
    }
}
