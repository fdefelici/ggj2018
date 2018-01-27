using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( fileName = "new Audio", menuName = "Sounds")]
public class SoundsList : ScriptableObject
{
    public AudioClip Jump;
    public AudioClip TakeDisturbation;
    public AudioClip Hurt;
    public AudioClip ChangePosition;
    
}
