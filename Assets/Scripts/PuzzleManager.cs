using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleManager : MonoBehaviour
{
    public XRSocketInteractor redSocket;
    public XRSocketInteractor greenSocket;
    public XRSocketInteractor blueSocket;

    public UnityEvent onPuzzleComplete;

    private bool puzzleCompleted = false;

    public void CheckPuzzleState()
    {
        if (puzzleCompleted) return;

        bool redCorrect = redSocket.selectTarget != null && redSocket.selectTarget.CompareTag("RedCube");
        bool greenCorrect = greenSocket.selectTarget != null && greenSocket.selectTarget.CompareTag("GreenCube");
        bool blueCorrect = blueSocket.selectTarget != null && blueSocket.selectTarget.CompareTag("BlueCube");

        if (redCorrect && greenCorrect && blueCorrect)
{
    puzzleCompleted = true;
    Debug.Log("✅ Puzzle Completed!");
    onPuzzleComplete.Invoke();
}

    }
}
