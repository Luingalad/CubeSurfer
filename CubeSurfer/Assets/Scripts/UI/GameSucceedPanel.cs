using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSucceedPanel : MonoBehaviour
{
    public TextMeshProUGUI CrystalText;
    public TextMeshProUGUI BonusText;

    public void SetUIText(int CrystalCount, int Bonus)
    {
        CrystalText.text = CrystalCount.ToString();
        BonusText.text = Bonus + "X";
    }

}
