using UnityEngine;

// [
//     CreateAssetMenu(
//         fileName = "RegenOnTurnEnd",
//         menuName = "SingleEffect",
//         order = 0)
// ]
public class RegenOnTurnEnd : Skill
{
    public override void effect(CharacterSlot caster, CharacterSlot target)
    {
        Debug.Log("This is a Regen Skill. It does Regen stuff.");
    }
}
