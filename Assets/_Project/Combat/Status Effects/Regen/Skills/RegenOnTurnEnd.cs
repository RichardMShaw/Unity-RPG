using UnityEngine;
// [
//     CreateAssetMenu(
//         fileName = "RegenOnTurnEnd",
//         menuName = "SingleEffect",
//         order = 0)
// ]
public class RegenOnTurnEnd : Skill
{
    public override void use(CharacterSlot caster, CharacterSlot target)
    {
        Debug.Log("This is a Regen Skill. It dose Regen stuff.");
    }
}
