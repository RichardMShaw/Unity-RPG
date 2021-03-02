using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAnimationDestroy : MonoBehaviour
{
    public bool isPlaying = false;

    public float waitTime = 0f;

    public float timer = 0f;

    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                isPlaying = false;
                Destroy (gameObject);
            }
        }
    }

    public void setTimer(AnimationClip clip)
    {
        waitTime = clip.length;
        timer = 0f;
        isPlaying = true;
    }
}
