using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;

public class PcacheSqeuence : MonoBehaviour
{

    [Header("Play Setting")]
    public int index;
    [Range(1f, 90f)]
    public float frameRate;
    [Range(1f, 10f)]
    public int pCountMult;
    public bool loop;
    [Header("Import Setting")]
    public string folder;
    public string file;
    public int imin = 1;
    public int imax;
    
    public List<UnityEditor.VFX.Utils.PointCacheAsset> pca;
    private UnityEngine.Experimental.VFX.VisualEffect ve;
    // Start is called before the first frame update
    void Awake()
    {
        ve = GetComponent<UnityEngine.Experimental.VFX.VisualEffect>();

        imax = imin;
        UnityEditor.VFX.Utils.PointCacheAsset temp;
        while (temp = Resources.Load<UnityEditor.VFX.Utils.PointCacheAsset>(folder + "/" + file + imax.ToString()))
        {

            ++imax;
            pca.Add(temp);

            //Debug.Log(folder + "/" + file + imax.ToString() + ".pcache loaded");
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame\
    private float timer;
    void Update()
    {
        if (!gameObject.activeSelf) return;
        if (index > pca.Count)
        {
            if (loop) index = imin;
            else return;
        }
        timer += Time.deltaTime;
        if (timer > 1 / frameRate)
        {
            index++;
            timer = 0;
        }
        ve.SetFloat("pCount",pca[index].PointCount*pCountMult);
        ve.SetTexture("pos",pca[index].surfaces[0]);
        ve.SetTexture("color",pca[index].surfaces[1]);
    }
}
