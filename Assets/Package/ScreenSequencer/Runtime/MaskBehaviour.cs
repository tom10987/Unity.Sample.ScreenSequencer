
using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent( typeof( MaskController ) )]
public class MaskBehaviour : MonoBehaviour
{
  static MaskBehaviour _instance = null;
  public static bool exists { get { return _instance != null; } }

  void Awake()
  {
    if ( _instance == null ) { _instance = this; }
    if ( _instance != this ) { Destroy( this ); }
  }

  void OnDestroy()
  {
    if ( _instance == this ) { _instance = null; }
  }


  [SerializeField, Range(0.01f, 1f)]
  float _durationMin = 0.01f;

  [SerializeField, Range(1f, 10f)]
  float _durationMax = 5f;

  float ClampDuration(float duration)
  {
    return Mathf.Clamp( duration, _durationMin, _durationMax );
  }


  MaskController _mask = null;
  public static MaskController controller { get { return _instance._mask; } }

  /// <summary> 初期化以外では使用しない </summary>
  public void Setup(MaskType type, Color color, float duration)
  {
    if ( !exists ) { Awake(); }
    _mask = GetComponent<MaskController>();
    type.Open( color, duration );
  }


  IEnumerator _sequence = null;
  public static bool isPlaying { get { return _instance._sequence != null; } }

  public static void Open(MaskType type, Color color, float duration)
  {
    if ( isPlaying ) { return; }

    duration = _instance.ClampDuration( duration );
    _instance._sequence = type.Open( color, duration );

    _instance.StartCoroutine( _instance.UpdateMask() );
  }

  public static void Close(MaskType type, Color color, float duration)
  {
    if ( isPlaying ) { return; }

    duration = _instance.ClampDuration( duration );
    _instance._sequence = type.Close( color, duration );

    _instance.StartCoroutine( _instance.UpdateMask() );
  }


  IEnumerator UpdateMask()
  {
    yield return new WaitWhile( () => _sequence.MoveNext() );
    _sequence = null;
  }
}
