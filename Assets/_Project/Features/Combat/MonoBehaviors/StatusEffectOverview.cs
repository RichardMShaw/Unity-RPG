using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectOverview : MonoBehaviour
{

    public GameObject buffPrefab;
    public GameObject debuffPrefab;
    public GameObject typelessPrefab;
    public GameObject temp;

    public GameObject passives;
    public void setTemp(List<TempStatusEffectSlot> list){
        GameObject[] children = new GameObject[temp.transform.childCount];
        foreach(Transform child in temp.transform){
            Destroy(child.gameObject);
        }
        int len = list.Count;
        for(int i = 0; i < len; i++){
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
