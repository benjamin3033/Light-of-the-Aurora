using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartHolder : MonoBehaviour
{
    public GameManager manager;

    public EnemyNearEffect Enemynear;

    public Text partsText;

    public int Parts = 0;

    public GameObject Beam = null;

    public GameObject Enemy = null;

    [SerializeField] private List<Parts.PartNum> partList;


    private void Start()
    {
        partsText.text = "Parts " + Parts.ToString();
    }


    private void Awake()
    {
        partList = new List<Parts.PartNum>();
    }

    public void AddPart(Parts.PartNum partNum)
    {
        Debug.Log("added part" + partNum);
        partList.Add(partNum);
        Parts += 1;
        partsText.text = "Parts " + Parts.ToString();
    }

    public void RemovePart(Parts.PartNum partNum)
    {
        partList.Remove(partNum);
    }

    public bool ContainsPart(Parts.PartNum partNum)
    {
        return partList.Contains(partNum);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Parts>() != null)
        {
            Parts parts = collider.GetComponent<Parts>();
            if (parts != null)
            {
                AddPart(parts.GetPartNum());
                Destroy(parts.gameObject);
            }
        }

        if (collider.tag == "EndTrigger" && partList.Count >= 5)
        {
            collider.GetComponent<PartCompleate>().StartAuraua();
            Beam.SetActive(true);
            Enemy.SetActive(false);

            Enemynear.grainLayer.intensity.value = 0;
            Enemynear.ChromaLayer.intensity.value = 0;
        }

        if (collider.tag == "Enemy")
        {
            manager.GameFail();
        }
    }
}