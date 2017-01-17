
using UnityEngine;
using System.Collections;

public class _TEST : MonoBehaviour
{
  [SerializeField]
  MaskType _type = MaskType.None;

  [SerializeField]
  Color _color = Color.black;

  [SerializeField, Range(0.01f, 5f)]
  float _duration = 1f;


  IEnumerator Start()
  {
    MaskBehaviour.Open( _type, _color, _duration );
    yield return new WaitWhile( () => MaskBehaviour.isPlaying );
    yield return new WaitForSeconds( 1f );
    MaskBehaviour.Close( _type, _color, _duration );
  }
}
