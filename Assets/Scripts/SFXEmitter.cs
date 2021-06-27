using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXEmitter : MonoBehaviour
{
    [SerializeField] List<AudioClip> SoundEffects;
    [SerializeField] float Interval = 2f;

    AudioSource LinkedSource;
    float NextEffectTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        LinkedSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        NextEffectTime -= Time.deltaTime;

        // time to play audio?
        if (NextEffectTime <= 0)
        {
            var selectedEffect = SoundEffects[Random.Range(0, SoundEffects.Count)];

            LinkedSource.PlayOneShot(selectedEffect);

            NextEffectTime = Interval + selectedEffect.length;
        }
    }
}
