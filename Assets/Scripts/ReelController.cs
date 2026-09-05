using UnityEngine;

public class ReelController : MonoBehaviour
{
    [SerializeField] private Transform Symbols;
    [SerializeField] private float spinSpeed = 8f;
    private bool isSpinning = false;

    private Transform[] symbolObjects;

    public void Start()
    {
        symbolObjects = new Transform[Symbols.childCount];

        for (int i = 0; i < Symbols.childCount; i++)
        {
            symbolObjects[i] = Symbols.GetChild(i);
        }

    }

    public void startSpin()
    {
        isSpinning = true;
    }

    public void stopSpin()
    {
        isSpinning = false;
    }

    private void Update()
    {
        if (!isSpinning)
        {
            return;
        }

        MoveSymbols();

    }



    private void MoveSymbols()
    {
        foreach (Transform symbol in symbolObjects)
        {
            symbol.localPosition +=
                Vector3.down * spinSpeed * Time.deltaTime;

            if (symbol.localPosition.y < -2f)
            {
                Vector3 pos = symbol.localPosition;
                pos.y += 4f;
                symbol.localPosition = pos;
            }
        }
    }
}
