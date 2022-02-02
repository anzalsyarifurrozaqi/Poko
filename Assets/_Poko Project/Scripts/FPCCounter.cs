using UnityEngine;
using TMPro;

public class FPCCounter : MonoBehaviour
{
    public TextMeshProUGUI FPSText;

    private float _currentFpsTime;
    private float _fpsCounter;
    private float _fpsShowPeriod = 1f;

    private void Update()
    {
        _currentFpsTime = _currentFpsTime + Time.deltaTime;
        _fpsCounter = _fpsCounter + 1;
        if (_currentFpsTime > _fpsShowPeriod)
        {
            FPSText.text = $"FPS : {_fpsCounter}";
            _currentFpsTime = 0;
            _fpsCounter = 0;
        }        
    }
}
