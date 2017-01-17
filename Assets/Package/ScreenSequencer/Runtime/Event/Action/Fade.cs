
using UnityEngine;
using System.Collections;

namespace MaskAction
{
  public class Fade : IMask
  {
    public IEnumerator Open(Color color, float time)
    {
      MaskBehaviour.controller.color = color;
      MaskBehaviour.controller.amount = 1f;
      MaskBehaviour.controller.ChangeAlpha( 1f );

      float elapsedTime = 0f;

      while ( elapsedTime < 1f )
      {
        elapsedTime += ( Time.deltaTime / time );
        MaskBehaviour.controller.ChangeAlpha( 1f - elapsedTime );
        yield return null;
      }

      MaskBehaviour.controller.ChangeAlpha( 0f );
    }

    public IEnumerator Close(Color color, float time)
    {
      MaskBehaviour.controller.color = color;
      MaskBehaviour.controller.amount = 1f;
      MaskBehaviour.controller.ChangeAlpha( 0f );

      float elapsedTime = 0f;

      while ( elapsedTime < 1f )
      {
        elapsedTime += ( Time.deltaTime / time );
        MaskBehaviour.controller.ChangeAlpha( elapsedTime );
        yield return null;
      }

      MaskBehaviour.controller.ChangeAlpha( 1f );
    }
  }
}
