using Sonity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public SoundEvent youDidIt;
    public SoundEvent talkFig;
    public SoundEvent talkBroccoli;
    public SoundEvent talkBird;
    public SoundEvent talkCat;
    public SoundEvent talkMouse;
    public SoundEvent walkFigCement;
    public SoundEvent walkFigGrass;
    public SoundEvent kidnapBroccoli;
    public SoundEvent pianoFull;
    public SoundEvent piano1;
    public SoundEvent piano2;
    public SoundEvent piano3;
    public SoundEvent piano4;
    public SoundEvent piano5;


    // and more

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            // normally you would also call DoNotDestroyOnLoad here, but since this is attached to the Sonity manager, and the Sonity manager can do that on its own, we don't have to call DoNotDestroyOnLoad. We probably should though, since it would be cleaner code, and I wouldn't have had to explain this bit right here.
        }
    }
}
