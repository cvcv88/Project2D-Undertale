using System.Collections;
using UnityEngine;

public class RuinScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void SceneChange()
    {
        Manager.Scene.LoadScene("Battle");
    }
}
