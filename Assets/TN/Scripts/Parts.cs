using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    [SerializeField] private PartNum partNum;

    public enum PartNum
    {
        Part_1,
        Part_2,
        Part_3,
        Part_4,
        Part_5
    }

    public PartNum GetPartNum()
    {
        return partNum;
    }
}
