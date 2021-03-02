using UnityEngine;

public class AnimClipSlot
{
    public AnimClip clip;

    public GameObject parent;

    public void play()
    {
        GameObject obj = new GameObject();
        obj.transform.parent = parent.transform;
        obj.AddComponent<AutoAnimationDestroy>().setTimer(clip.anim);
    }
}
