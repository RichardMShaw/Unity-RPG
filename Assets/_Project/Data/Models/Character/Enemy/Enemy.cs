using UnityEngine;
using UnityEngine.Animations;

[
    CreateAssetMenu(
        fileName = "New Enemy",
        menuName = "Database/Enemy",
        order = 0)
]
public class Enemy : Character
{
    [Header("Visuals")]
    public AnimatorOverrideController animator;
}
