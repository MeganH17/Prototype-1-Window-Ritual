using UnityEngine;

public class SpaceStateManager : MonoBehaviour
{
    // 拖入场景里的 SerialController 对象
    public SerialController serial;

    [Header("Distance thresholds")]
    public float farThreshold = 50f;    // State 0: Absent
    public float nearThreshold = 25f;   // State 2: Engage

    // 当前状态 0 / 1 / 2
    private int currentState = 0;
    public int CurrentState => currentState;

    void Start()
    {
        if (serial == null)
            Debug.LogWarning("SerialController not assigned!");
        else
            Debug.Log("SpaceStateManager started.");
    }

    // ✅ Ardity 真正会调用的方法
    public void OnMessageArrived(string data)
    {
        if (string.IsNullOrEmpty(data)) return;

        Debug.Log($"OnMessageArrived raw data: {data}");

        if (float.TryParse(data, out float distance))
        {
            Debug.Log($"Parsed distance: {distance}");

            UpdateState(distance);

            Debug.Log($"CurrentState = {currentState}");
        }
        else
        {
            Debug.LogWarning($"Parse failed: {data}");
        }
    }

    // ✅ 用来消除 Ardity 的 SendMessage 警告
    public void OnConnectionEvent(bool success)
    {
        Debug.Log($"Serial connection: {success}");
    }

    // 状态判定逻辑
    void UpdateState(float distance)
    {
        if (distance > farThreshold)
            currentState = 0;      // Absent
        else if (distance > nearThreshold)
            currentState = 1;      // Approach
        else
            currentState = 2;      // Engage
    }

    // 不再轮询
    void Update() { }
}