using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    
    public AudioClip[] AttackClips;

    public AudioClip[] MoveClips;

    public AudioClip[] DeathClips;

    public AudioClip[] HitClips;

    public AudioClip[] LungeClips;

    public AudioClip[] PlayerFootsteps;

    public AudioClip[] PlayerAttack;

    public AudioClip[] PlayerHurt;

    public AudioClip[] PlayerDeath;

    public AudioClip[] DamagedTreeLoop;

    public AudioClip[] RootRepair;

    public AudioClip[] RootRepairComplete;

    public AudioClip[] Heal;

    public AudioClip[] Music;


    public static AudioClip[] attackClips;

    public static AudioClip[] moveClips;

    public static AudioClip[] deathClips;

    public static AudioClip[] hitClips;

    public static AudioClip[] lungeClips;

    public static AudioClip[] playerFootsteps;

    public static AudioClip[] playerAttack;

    public static AudioClip[] playerHurt;

    public static AudioClip[] playerDeath;

    public static AudioClip[] damagedTreeLoop;

    public static AudioClip[] rootRepair;

    public static AudioClip[] rootRepairComplete;

    public static AudioClip[] heal;

    public static AudioClip[] music;

    // Start is called before the first frame update
    void Awake()
    {
        attackClips = AttackClips;
        moveClips = MoveClips;
        deathClips = DeathClips;
        playerFootsteps = PlayerFootsteps;
        playerAttack = PlayerAttack;
        playerHurt = PlayerHurt;
        playerDeath = PlayerDeath;
        hitClips = HitClips;
        lungeClips = LungeClips;
        damagedTreeLoop = DamagedTreeLoop;
        rootRepair = RootRepair;
        rootRepairComplete = RootRepairComplete;
        heal = Heal;
        music = Music;
    }
}
