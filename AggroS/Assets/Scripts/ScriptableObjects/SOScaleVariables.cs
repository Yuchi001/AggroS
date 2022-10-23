using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Custom/ScaleVariableSet", fileName ="newScaleVariableSet")]
public class SOScaleVariables : ScriptableObject
{
    public List<SScaleSet> ScaleStats;
}

[System.Serializable]
public struct SScalePair
{
    public string name;
    public EPlayerStats stat;
    public int value;
}
[System.Serializable]
public struct SScaleSet
{
    public string name;
    public ESkillStats skill;
    public List<SScalePair> SkillValuePair;
}