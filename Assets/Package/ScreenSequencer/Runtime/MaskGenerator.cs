
//------------------------------------------------------------
// 概要
// シーン開始直後にプレハブを自発的にインスタンス化する。
// インスタンス化されたオブジェクトは、シーンを跨いでも基本的に削除しない。
//
//------------------------------------------------------------

using UnityEngine;

public class MaskGenerator : ScriptableObject
{
#if UNITY_EDITOR
  [UnityEditor.MenuItem("Custom Assets/Create Mask Generator")]
  static void CreateAsset()
  {
    var asset = CreateInstance<MaskGenerator>();
    UnityEditor.ProjectWindowUtil.CreateAsset( asset, "NewMaskGenerator.asset" );
  }
#endif

  [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
  static void LoadAsset()
  {
    if ( MaskBehaviour.exists ) { return; }

    // TIPS:
    // プレハブのあるフォルダの変更を想定して、保守コスト削減のため LoadAll() を使用する。
    // 削除されない限り初回のみの動作なので、パフォーマンスへの影響は少ないと考えた。
    var resource = Resources.LoadAll<MaskGenerator>("")[0];
    var instance = Instantiate( resource._prefab );
    DontDestroyOnLoad( instance );

    instance.Setup( resource._type, resource._color, resource._duration );
  }

  [SerializeField]
  MaskBehaviour _prefab = null;


  [Space( 10 )]
  [Header("起動時のマスク動作、色、動作速度")]

  [SerializeField]
  MaskType _type = MaskType.None;

  [SerializeField]
  Color _color = Color.black;

  [SerializeField, Range(0.01f, 5f)]
  float _duration = 1f;
}
