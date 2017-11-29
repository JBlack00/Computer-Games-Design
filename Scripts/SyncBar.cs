using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Liminal Space
/// This script is attached to the Synchronisation Bar UI within the canvas.
/// This increases the syncValue and increases the SyncBar UI slider.
/// </summary>

public class SyncBar : MonoBehaviour
{
    public Slider SynchronisationBar;
    public int syncValue;

	// Use this for initialization
	void Start ()
    {
        syncValue = 0;
        SynchronisationBar = GameObject.Find("SynchronisationBar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        SetSyncValue();
    }

    public void SetSyncValue()
    {
        SynchronisationBar.value = syncValue;//Sets the sync slider UI to the sync value amount
    }
    //Called from the SyncTrigger script
    public void Sync()
    {
        syncValue += 1;//Increases value on the slider
    }
}
