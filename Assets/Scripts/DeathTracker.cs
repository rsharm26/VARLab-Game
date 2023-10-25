using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTracker : MonoBehaviour {
    [SerializeField]
    private int deaths = 0;

    public void IncrementDeaths() {
        deaths++;
    }

    public int GetDeaths() {
        return deaths;
    }
}
