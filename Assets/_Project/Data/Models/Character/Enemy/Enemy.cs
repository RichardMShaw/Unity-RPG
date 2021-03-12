using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Database/Enemy", order = 0)]
public class Enemy : Character
{
    [Header("Visuals")]
    public AnimationClip idle;
}
