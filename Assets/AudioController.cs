using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip[] AttackClips;

    public AudioClip[] MoveClips;

    public AudioClip[] DeathClips;

    public AudioClip[] PlayerFootsteps;

    public AudioClip[] PlayerAttack;

    public AudioClip[] PlayerHurt;

    public AudioClip[] PlayerDeath;


    public static AudioClip[] attackClips;

    public static AudioClip[] moveClips;

    public static AudioClip[] deathClips;

    public static AudioClip[] playerFootsteps;

    public static AudioClip[] playerAttack;

    public static AudioClip[] playerHurt;

    public static AudioClip[] playerDeath;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
