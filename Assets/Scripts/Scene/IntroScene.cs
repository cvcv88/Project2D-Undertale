using System.Collections;
using UnityEngine;

public class IntroScene : BaseScene
{
    bool waitCheck = false;
    bool skipCheck = false;

    private void Start()
    {
        StartCoroutine(LoadingRoutine());
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return new WaitForSeconds(55f);
        waitCheck = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
            skipCheck = true;
        if (waitCheck || skipCheck)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Manager.Scene.LoadScene("Ruin");
                waitCheck = false;
            }
        }
    }
}
