using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private Intervals[] _intervals;

    private void Awake() {
        // _audioSource = GameControl.instance.musicSong;
    }

    private void Update() {
        foreach (Intervals interval in _intervals) {
            float sampledTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalLength(bpm)));
            interval.CheckForNewInterval(sampledTime);
        }
    }

[System.Serializable]
public class Intervals {
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval;

    public float GetIntervalLength(float bpm) {
        return 60f / (bpm * _steps);
    }

    public void CheckForNewInterval (float interval) {
        if (Mathf.FloorToInt(interval) != _lastInterval) {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }
    }
}

}
