using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "NewBehaviourScript",
        menuName = "Unity-RPG/NewBehaviourScript",
        order = 0)
]
public class AnimClip : ScriptableObject
{
    public AnimationClip anim;

    public float speed;

    public bool defaultDuration;

    public float durationPercent;

    public float duration;

    public void play()
    {
    }
}
