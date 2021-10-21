using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCompleate : MonoBehaviour
{
    [SerializeField] private Parts.PartNum partNum;

    public Parts.PartNum GetPartNum()
    {
        return partNum;
    }

    public void StartAuraua()
    {
        gameObject.SetActive(true);
        Debug.Log("Araura triggered");
    }
}
