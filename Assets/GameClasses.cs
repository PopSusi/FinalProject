using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public enum LevelType
    {
        Desert,
        Forest,
        Stone
    };
    protected static LevelType SelectedLevel = LevelType.Forest;
}
public class Damageable : MonoBehaviour //Game Class for Enemies and Players
{
    //ASSUME COMMENTS START WITH "ALL OBJECTS HAVE [TYPE]
    public SpriteRenderer spriteControls; //Sprites, Name is normalized here
    public Animator animControls; //Animator, Name is normalized here
    public AnimatorOverrideController myAnims;
    public float attackDelay = 5; //Every {[}attackSpeed} Seconds
    public float speed = 5; //Default Move Speed
    protected bool faceLeft;
    public enum EDamage
    {
        Physical, Ranged, Magic
    }
    public float HP = 100; //
    public bool dead;

    public virtual void TakeDamage(float incomingDamage, EDamage type)
    {
        HP -= incomingDamage;
        switch (type)
        {
            case EDamage.Ranged:
                spriteControls.color += Color.black;
                break;
            case EDamage.Magic:
                spriteControls.color += Color.blue;
                break;
            case EDamage.Physical:
            default:
                spriteControls.color += Color.red;
                break;
        }
    }

    public virtual void InitializeComponents()
    {
        spriteControls = GetComponent<SpriteRenderer>();
        animControls = GetComponent<Animator>();
        animControls.runtimeAnimatorController = myAnims;
    }
}
