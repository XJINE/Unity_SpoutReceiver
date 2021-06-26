using Klak.Spout;
using UnityEngine;

public class UnitySpoutReceiver : MonoBehaviour
{
    #region Field

    SpoutReceiver spoutReceiver;

    Rect       guiArea;
    Vector2Int guiAreaOffset = new Vector2Int(20, 20);

    #endregion Field

    private void Start()
    {
        this.spoutReceiver = FindObjectOfType<SpoutReceiver>();

        this.guiArea = new Rect(this.guiAreaOffset.x,
                                this.guiAreaOffset.y,
                                600,
                                Screen.height);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(this.guiArea);

        GUILayout.Label("Spout Source :");

        string[] sourceNames = SpoutManager.GetSourceNames();

        if (sourceNames != null && sourceNames.Length != 0)
        {
            int sourceIndex = Mathf.Max(0, System.Array.IndexOf(sourceNames, spoutReceiver.sourceName));

            sourceIndex = GUILayout.Toolbar(sourceIndex, sourceNames);

            Debug.Log(sourceIndex + " : " +sourceNames.Length);

            this.spoutReceiver.sourceName = sourceNames[sourceIndex];
        }


        if (this.spoutReceiver.receivedTexture != null)
        {
            GUILayout.Label("Source Resolution : " + 
                            this.spoutReceiver.receivedTexture.width + " x " +
                            this.spoutReceiver.receivedTexture.height);
        }

        GUILayout.Label("Receiver Resolution : " + Screen.width + "x" + Screen.height);

        bool fullScreenOn = Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen;

        Screen.fullScreenMode = GUILayout.Toggle(fullScreenOn, "FullScreen : " + fullScreenOn) ?
                                FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;

        bool vsyncOn = QualitySettings.vSyncCount == 1;

        QualitySettings.vSyncCount = GUILayout.Toggle(vsyncOn, "Vsync : " + vsyncOn) ? 1 : 0;

        GUILayout.Label("Frame Rate : " + Application.targetFrameRate);

        Application.targetFrameRate = (int)GUILayout.HorizontalSlider(Application.targetFrameRate, -1, 300);

        GUILayout.Label("FPS : " + FrameRateChecker.Instance.Fps);
        GUILayout.Label("AVG : " + FrameRateChecker.Instance.FpsAvg);

        GUILayout.EndArea();
    }
}