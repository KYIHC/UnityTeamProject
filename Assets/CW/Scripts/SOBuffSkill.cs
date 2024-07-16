using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOBuffSkill : ScriptableObject
{
    public float PlusStat;
    public float CoolTime;
    public float duration;

    public string animationName;
    public Sprite SkillIcon;
}
