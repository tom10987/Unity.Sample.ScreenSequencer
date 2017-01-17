
using UnityEngine;
using System.Collections;

namespace MaskAction
{
  public class Wipe : IMask
  {
    public IEnumerator Open(Color color, float time)
    {
      MaskBehaviour.controller.color = color;
      MaskBehaviour.controller.amount = 1f;
      MaskBehaviour.controller.origin = 0;
      MaskBehaviour.controller.ChangeAlpha( 1f );

      float elapsedTime = 0f;

      while ( elapsedTime < 1f )
      {
        elapsedTime += ( Time.deltaTime / time );
        MaskBehaviour.controller.amount = Mathf.Clamp01( 1f - elapsedTime );
        yield return null;
      }

      MaskBehaviour.controller.amount = 0f;
    }

    public IEnumerator Close(Color color, float time)
    {
      MaskBehaviour.controller.color = color;
      MaskBehaviour.controller.amount = 0f;
      MaskBehaviour.controller.origin = 1;
      MaskBehaviour.controller.ChangeAlpha( 1f );

      float elapsedTime = 0f;

      while ( elapsedTime < 1f )
      {
        elapsedTime += ( Time.deltaTime / time );
        MaskBehaviour.controller.amount = Mathf.Clamp01( elapsedTime );
        yield return null;
      }

      MaskBehaviour.controller.amount = 1f;
    }
  }
}
