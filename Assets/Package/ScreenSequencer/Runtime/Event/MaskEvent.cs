
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class MaskEvent
{
  public static IEnumerator Open(this MaskType mode, Color color, float time)
  {
    return _events[ (int)mode ].Open( color, time );
  }

  public static IEnumerator Close(this MaskType mode, Color color, float time)
  {
    return _events[ (int)mode ].Close( color, time );
  }


  static readonly List<IMask> _events = new List<IMask>
  {
    new MaskAction.None(),
    new MaskAction.Fade(),
    new MaskAction.Wipe(),
  };
}
