using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Queue<AnimClip> clips;

    private float waitTime = 0f;

    private float timer = 0f;

    private bool isPlaying;

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                if (clips.Count == 0)
                {
                    isPlaying = false;
                    //Send Event that says it's done playing animations.
                }
                AnimClip clip = clips.Dequeue();
                clip.play();
                if (clip.defaultDuration == true)
                {
                    waitTime = clip.anim.length;
                }
                else if (clip.durationPercent > 0)
                {
                    waitTime = clip.anim.length * clip.durationPercent;
                }
                else if (clip.duration > 0)
                {
                    waitTime = clip.duration;
                }
                else
                {
                    waitTime = 0f;
                }

                timer = 0f;
            }
        }
    }

    public void skip()
    {
        clips.Clear();
        waitTime = 0f;
    }
}
