using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flash : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup myCG;

    [SerializeField]
    public GameObject white;
    [SerializeField]
    private GameObject black;

    private bool flash = false;
    private bool blind = false;

    void Update()
    {
        if (flash)
        {
            myCG.alpha = myCG.alpha - Time.deltaTime/2;
            if (myCG.alpha <= 0)
            {
                myCG.alpha = 0;
                flash = false;
            }
        }

        if (blind)
        {
            myCG.alpha = myCG.alpha + Time.deltaTime/2;
            if(myCG.alpha >= 1)
            {
                myCG.alpha = 1;
            }
        }
    }

    public void FlashPlayer()
    {
        white.SetActive(true);
        black.SetActive(false);

        flash = true;
        myCG.alpha = 1;
    }

    public void BlindPlayer(string color)
    {
        if(color == "white")
        {
            white.SetActive(true);
            black.SetActive(false);
        } else
        {
            white.SetActive(false);
            black.SetActive(true);
        }
        blind = true;
    }
}
