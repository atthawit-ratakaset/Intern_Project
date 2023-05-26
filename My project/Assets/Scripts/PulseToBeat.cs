using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseToBeat : MonoBehaviour
{
    [SerializeField] bool _useTestBeat;
    [SerializeField] float _pulseSize = 1.15f;
    [SerializeField] float _returnSpeed = 5f;
    private Vector3 _startsize;

    void Start()
    {
        _startsize = transform.localScale;
        if (_useTestBeat) {
            StartCoroutine(TestBeat());
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _startsize, Time.deltaTime * _returnSpeed);
    }

    public void Pulse() {
        transform.localScale = _startsize * _pulseSize;
    }

    IEnumerator TestBeat() {
        while (true) {
            yield return new WaitForSeconds(1f);
            Pulse();
        }
    }
}
