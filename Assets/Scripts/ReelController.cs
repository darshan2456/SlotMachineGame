using UnityEngine;

public class ReelController : MonoBehaviour
{
    [SerializeField] private Transform Symbols;
    [SerializeField] private float spinSpeed = 8f;
    private int targetSymbol;
    private bool Spinning = false;

    private float stopPosition = 0f;

    private Transform[] symbolObjects;

    public void Start()
    {
        symbolObjects = new Transform[Symbols.childCount];

        for (int i = 0; i < Symbols.childCount; i++)
        {
            symbolObjects[i] = Symbols.GetChild(i);
        }

    }

    public void startSpin(int target)
    {
        targetSymbol = target;
        Spinning = true;
    }

    public void stopSpin()
    {
        Spinning = false;
    }

    public bool isSpinning()
    {
        return Spinning;
    }

    private void Update()
    {
        if (!Spinning)
        {
            return;
        }

        MoveSymbols();

    }



    private void MoveSymbols()
    {
        float previousTargetY = symbolObjects[targetSymbol].localPosition.y;

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

        float currentTargetY = symbolObjects[targetSymbol].localPosition.y;

        if(previousTargetY>stopPosition && currentTargetY <= stopPosition)
        {
            Vector3 pos = symbolObjects[targetSymbol].localPosition;
            pos.y = stopPosition;
            symbolObjects[targetSymbol].localPosition = pos;

            stopSpin();
        }
    }
}
