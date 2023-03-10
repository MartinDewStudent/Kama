using UnityEngine;
using UnityEngine.UI;
using KamaLib;

[RequireComponent(typeof(Image))]
public class MPBar : MonoBehaviour
{
    private GameObject target;
    private Image bar;
    private ISkillComponent playerSkill;
    private int MPValueInt;
    [SerializeField] private Text MPValue;
    private void Awake()
    {
        MPValue = GameObject.Find("MP Value").GetComponent<Text>();
        target = GameObject.FindGameObjectWithTag("Main Character");
        playerSkill = target.GetComponent<ISkillComponent>();
        bar = GetComponent<Image>();
    }

    public void SetFill(float fillAmount)
    {
        bar.fillAmount = fillAmount;
    }

    public void SetColor(Color color)
    {
        bar.color = color;
    }

    private float AdjustCharacterSP()
    {
        return playerSkill.Sp / playerSkill.MaxSp;
    }
    private void LateUpdate()
    {
        SetFill(AdjustCharacterSP());
        MPValueInt = (int)(playerSkill.Sp);
        MPValue.text = $"{MPValueInt} / {playerSkill.MaxSp}";
    }
}