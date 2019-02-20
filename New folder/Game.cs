using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Game : Singleton<Game>
{
    [SerializeField] AudioMixerSnapshot m_gameAudio;
    [SerializeField] AudioMixerSnapshot m_pauseAudio;
    void Start()
    {
		AudioManager.Instance.Play("Music");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) m_pauseAudio.TransitionTo(0.5f);
        if (Input.GetKeyDown(KeyCode.O)) m_gameAudio.TransitionTo(0.5f);
    }
}
