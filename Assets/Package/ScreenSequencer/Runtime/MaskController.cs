
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DisallowMultipleComponent]
public class MaskController : MonoBehaviour
{
  [SerializeField]
  Image _image = null;


  public Color color
  {
    get { return _image.color; }
    set { _image.color = value; }
  }

  public void ChangeAlpha(float alpha)
  {
    Color color = _image.color;
    color.a = Mathf.Clamp01( alpha );
    _image.color = color;
  }


  Coroutine _sequence = null;
  public bool isPlaying { get { return _sequence != null; } }

  public void BlendColor(Color color, float duration)
  {
    if ( isPlaying ) { return; }

    if ( duration < 0.01f ) { duration = 0.01f; }
    _sequence = StartCoroutine( Blend( color, duration ) );
  }

  public IEnumerator Blend(Color color, float duration)
  {
    float elapsedTime = 0f;
    Color start = _image.color;

    while ( elapsedTime < 1f )
    {
      elapsedTime += ( Time.deltaTime / duration );
      _image.color = Color.Lerp( start, color, elapsedTime );

      yield return null;
    }

    _image.color = color;
    _sequence = null;
  }


  public float amount
  {
    get { return _image.fillAmount; }
    set { _image.fillAmount = value; }
  }

  public int origin
  {
    get { return _image.fillOrigin; }
    set { _image.fillOrigin = value; }
  }

  public Image.FillMethod method
  {
    get { return _image.fillMethod; }
    set { _image.fillMethod = value; }
  }
}
