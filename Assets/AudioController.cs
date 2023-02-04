using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip[] AttackClips;

    public AudioClip[] MoveClips;

    public AudioClip[] DeathClips;

    public static AudioClip[] attackClips;

    public static AudioClip[] moveClips;

    public static AudioClip[] deathClips;

    // Start is called before the first frame update
    void Awake()
    {
        attackClips = AttackClips;
        moveClips = MoveClips;
        deathClips = DeathClips;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
