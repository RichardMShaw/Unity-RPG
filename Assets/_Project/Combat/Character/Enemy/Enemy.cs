using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Combat/Enemy Character", order = 0)]
public class Enemy : Character
{
    [Header("Visuals")]
    public AnimationClip idle;
}
