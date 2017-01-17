
シーン切り替えとかに使えそうな遷移処理

* `Canvas` と `Image` を使用
* シェーダーとか `ImageEffect` は未使用

---

`RuntimeInitializeOnLoadMethod` で、シーン読み込み時にプレハブを生成します。  
シーンに配置する必要はありません。

---

**使い方**

~~~
void Start()
{
  MaskBehaviour.Open( MaskType.Fade, Color.white, 1f );
}
~~~
