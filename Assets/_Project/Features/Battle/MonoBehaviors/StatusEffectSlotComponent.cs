using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectSlotComponent : MonoBehaviour
{
    private string bgColorNone = "#787878";

    private string bgColorBuff = "#FF8D00";

    private string bgColorDebuff = "#1698B7";

    private string lineColorNone = "0x4F4F4F";

    private string lineColorBuff = "0xAB694A";

    private string lineColorDebuff = "0x195983";

    public GameObject self;

    public RawImage icon;

    public TextMeshProUGUI description;

    public RawImage backgroundColor;

    public RawImage lineTop;

    public RawImage lineBottom;

    private void setColors(string bg, string boarder)
    {
        Color col;
        ColorUtility.TryParseHtmlString(bg, out col);
        backgroundColor.color = col;
        ColorUtility.TryParseHtmlString(boarder, out col);
        lineTop.color = col;
        lineBottom.color = col;
    }

    public void setStatusEffect(StatusEffectSlot slot)
    {
        StatusEffect status = slot.statusEffect;
        switch (status.type)
        {
            case StatusEffectType.None:
                setColors (bgColorNone, lineColorNone);
                break;
            case StatusEffectType.Buff:
                setColors (bgColorBuff, lineColorBuff);
                break;
            case StatusEffectType.Debuff:
                setColors (bgColorDebuff, lineColorDebuff);
                break;
            default:
                self.SetActive(false);
                return;
        }
        icon.material.mainTexture = status.icon;
        description.text = slot.print();
    }
}
