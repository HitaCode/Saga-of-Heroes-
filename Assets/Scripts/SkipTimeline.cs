using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SkipTimeline : MonoBehaviour
{
    public PlayableDirector playableDirector;  
    public Button skipButton;                  

    void Start()
    {
        skipButton.onClick.AddListener(SkipTimelineFunction);
    }

    void SkipTimelineFunction()
    {
        playableDirector.time = playableDirector.duration;
        playableDirector.Evaluate();  
        playableDirector.Stop();    
    }
}
