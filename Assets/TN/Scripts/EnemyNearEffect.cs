using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EnemyNearEffect : MonoBehaviour
{
    public GameObject enemy = null;
    public float maxRange = 10f;

    public float grain = 10;
    public float chromaticAb = 10;


    public Grain grainLayer = null;
    public ChromaticAberration ChromaLayer = null;

    public PostProcessProfile pFile = null;

    private void Start()
    {
        grainLayer = pFile.GetSetting<Grain>();
        ChromaLayer = pFile.GetSetting<ChromaticAberration>();
        grainLayer.intensity.value = 0;
        ChromaLayer.intensity.value = 0;
    }

    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
        
        if (dist < maxRange)
        {
            //ChomaLayer.enabled.value = true;
            ChromaLayer.intensity.value = Mathf.Lerp(1, 0, dist / maxRange);

            //grainLayer.enabled.value = true;
            grainLayer.intensity.value = Mathf.Lerp(1, 0, dist/maxRange);
        }

    }
}
