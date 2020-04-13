using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.Experimental.VFX.VisualEffect))]
[ExecuteInEditMode]
public class PcacheSqeuence : MonoBehaviour
{

    [Header("Play Setting")]
    public int index;
    [Range(0f, 10f)]
    public float playspeed;
    public float frameRate;
    public int pCountMult;
    public bool loop;
    [Header("Import Setting")]
    public string folder;
    public string file;
    public bool checkFolder;
    public int imin = 1;
    public int imax;
    
    public List<UnityEditor.VFX.Utils.PointCacheAsset> pca;
    private UnityEngine.Experimental.VFX.VisualEffect ve;
    // Start is called before the first frame update
    void LoadFiles()
    {
        pca.Clear();
        imax = imin;
        UnityEditor.VFX.Utils.PointCacheAsset temp;
        while (temp = Resources.Load<UnityEditor.VFX.Utils.PointCacheAsset>(folder + "/" + file + imax.ToString()))
        {

            ++imax;
            pca.Add(temp);

            //Debug.Log(folder + "/" + file + imax.ToString() + ".pcache loaded");
        }
    }

    // Update is called once per frame\
    private float timer;
    private float waitTime;
    void Update()
    {
        if (ve == null)
        {
            ve = GetComponent<UnityEngine.Experimental.VFX.VisualEffect>();
        }
        if (checkFolder)
        {
            LoadFiles();
            checkFolder = false;
        }
        if (!gameObject.activeSelf) return;
        if (index > pca.Count)
        {
            if (loop) index = imin;
            else return;
        }
        timer += Time.deltaTime *playspeed;
        waitTime = 1/ frameRate;
        if (timer>= waitTime)
        {
            timer -= waitTime;
            index++;

        }


        index = Mathf.Clamp(index, imin, imax-1);
        ve.SetFloat("pCount",pca[index].PointCount*pCountMult);
        ve.SetTexture("pos",pca[index].surfaces[0]);
        ve.SetTexture("color",pca[index].surfaces[1]);
    }
}
