
using UnityEngine;
using System.Collections;

public enum MaskType
{
  None,
  Fade,
  Wipe,
}

public interface IMask
{
  IEnumerator Open(Color color, float time);
  IEnumerator Close(Color color, float time);
}
