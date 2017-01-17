
//------------------------------------------------------------
// 概要
// インターフェイスとして必要なため、引数は受け取るが一切使用しない。
//
//------------------------------------------------------------

using UnityEngine;
using System.Collections;

namespace MaskAction
{
  public class None : IMask
  {
    public IEnumerator Open(Color color, float time)
    {
      MaskBehaviour.controller.ChangeAlpha( 0f );
      yield return null;
    }

    public IEnumerator Close(Color color, float time)
    {
      MaskBehaviour.controller.amount = 1f;
      MaskBehaviour.controller.ChangeAlpha( 1f );
      yield return null;
    }
  }
}
