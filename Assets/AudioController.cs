using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _timeBetweenScreams;
    [SerializeField] private bool _isPlayerAlive;
    void Start()
    {
        StartCoroutine(Scream());
    }

    private IEnumerator Scream()
    {
        while (_isPlayerAlive)
        {
            var index = Random.Range(0, _audioClips.Length);
            _audioSource.PlayOneShot(_audioClips[index]);
            yield return new WaitForSeconds(_audioClips[index].length + _timeBetweenScreams);
        }
    }
}
