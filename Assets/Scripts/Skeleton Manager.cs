using UnityEngine;
using UnityEngine.UI;

public class SkeletonManager : MonoBehaviour
{
    [SerializeField] private int ATK;
    [SerializeField] private int HP;
    [SerializeField] private SpriteRenderer handL;
    [SerializeField] private SpriteRenderer armLup;
    [SerializeField] private SpriteRenderer armLdwn;
    [SerializeField] private SpriteRenderer eyes;
    [SerializeField] private SpriteRenderer skull;
    [SerializeField] private SpriteRenderer ribbs;
    [SerializeField] private SpriteRenderer legLup;
    [SerializeField] private SpriteRenderer legLdwn;
    [SerializeField] private SpriteRenderer footL;
    [SerializeField] private SpriteRenderer pelv;
    [SerializeField] private SpriteRenderer spine;
    [SerializeField] private SpriteRenderer legRup;
    [SerializeField] private SpriteRenderer legRdwn;
    [SerializeField] private SpriteRenderer handR;
    [SerializeField] private SpriteRenderer armRup;
    [SerializeField] private SpriteRenderer armRdwn;
    [SerializeField] private SpriteRenderer footR;
    [SerializeField] private SpriteRenderer skull_back;
    [SerializeField] private SpriteRenderer weapon;
    [SerializeField] private Skeleton skeleton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handL.sprite = skeleton.handL;
        handL.color = skeleton.skColor;

        handR.sprite = skeleton.handR;
        handR.color = skeleton.skColor;

        armLup.sprite = skeleton.armLup;
        armLup.color = skeleton.skColor;

        armRup.sprite = skeleton.armRup;
        armRup.color = skeleton.skColor;

        armLdwn.sprite = skeleton.armLdwn;
        armLdwn.color = skeleton.skColor;

        armRdwn.sprite = skeleton.armRdwn;
        armRdwn.color = skeleton.skColor;

        legLup.sprite = skeleton.legLup;
        legLup.color = skeleton.skColor;

        legRup.sprite = skeleton.legRup;
        legRup.color = skeleton.skColor;

        legLdwn.sprite = skeleton.legLdwn;
        legLdwn.color = skeleton.skColor;

        legRdwn.sprite = skeleton.legRdwn;
        legRdwn.color = skeleton.skColor;

        footL.sprite = skeleton.footL;
        footL.color = skeleton.skColor;

        footR.sprite = skeleton.footR;
        footR.color = skeleton.skColor;

        eyes.sprite = skeleton.eyes;
        eyes.color = skeleton.skColor;

        skull.sprite = skeleton.skull;
        skull.color = skeleton.skColor;

        ribbs.sprite = skeleton.ribbs;
        ribbs.color = skeleton.skColor;

        pelv.sprite = skeleton.pelv;
        pelv.color = skeleton.skColor;

        spine.sprite = skeleton.spine;
        spine.color = skeleton.skColor;

        ATK = skeleton.attack;
        HP = skeleton.hp;

        if(skeleton.weapon)
        {
            weapon.sprite = skeleton.weapon;
            weapon.color = skeleton.skColor;
        }

        if(skeleton.skull_back)
        {
            skull_back.sprite = skeleton.skull_back;
            skull_back.color = skeleton.skColor;
        }
    }
}
