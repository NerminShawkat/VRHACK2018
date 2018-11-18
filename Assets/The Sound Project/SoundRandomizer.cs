using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundRandomizer : MonoBehaviour {
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    Range _volume;
    [SerializeField]
    Range _time;

    IEnumerator Start()
    {
        while(true)
        {
            SFXManager.Instance.PlayClip(clips[Random.Range(0, clips.Length)], _volume.Value);
            yield return new WaitForSeconds(_time.Value);
        }
    }

}
[System.Serializable]
public class Range
{
    [SerializeField]
    float _min;
    [SerializeField]
    float _max;

    public float Value
    {
        get
        {
            return Random.Range(_min, _max);
        }
    }
}