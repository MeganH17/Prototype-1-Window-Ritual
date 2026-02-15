using UnityEngine;

public class WindowController : MonoBehaviour
{
    // 拖入 SpaceStateManager 对象
    public SpaceStateManager stateManager;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (stateManager == null)
            Debug.LogWarning("WindowController: SpaceStateManager not assigned!");
        else
            Debug.Log("WindowController started, StateManager assigned.");
    }

    void Update()
    {
        if (stateManager == null) return;

        // 每帧读取当前状态
        int state = stateManager.CurrentState;
        Debug.Log($"WindowController Update: CurrentState = {state}");

        switch (state)
        {
            case 0:
                StateAbsent();
                break;
            case 1:
                StateApproach();
                break;
            case 2:
                StateEngage();
                break;
        }
    }

    void StateAbsent()
    {
        rend.material.color = Color.green;
        Debug.Log("StateAbsent: Color set to green");
    }

    void StateApproach()
    {
        rend.material.color = Color.blue;
        Debug.Log("StateApproach: Color set to blue");
    }

    void StateEngage()
    {
        rend.material.color = Color.red;
        Debug.Log("StateEngage: Color set to red");
    }
}