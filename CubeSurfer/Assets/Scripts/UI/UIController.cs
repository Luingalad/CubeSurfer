using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject CrystalImagePrefab;
    public Transform TargetImage;

    public TextMeshProUGUI CrystalCountText;

    public Slider DistanceSlider;

    public GameObject LevelEndUI;

    [Header("UI Elements")]
    public GameObject SucceedUI;
    public GameObject FailedUI;
    public GameObject StartUI;    

    #region Singleton

    public static UIController instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        CrystalCountText.text = GameController.instance.crystalCount.ToString();
    }

    public void UpdateCrystalCounter()
    {
        CrystalCountText.text = GameController.instance.crystalCount.ToString();
    }

    public void UpdateDistanceSlider(float value)
    {
        DistanceSlider.value = value;
    }

    public void SpawnCyrstalImage(Transform crystalLoc)
    {
        GameObject crystal = Instantiate(CrystalImagePrefab, transform);

        CrystalFly fly = crystal.GetComponent<CrystalFly>();
        fly.enabled = true;
        fly.StartSpriteFly(crystalLoc, TargetImage);

    }

    public void ShowEndGameUI(bool isSucceed, int EarnedCrystalCount, int Bonus)
    {
        if(isSucceed)
        {
            SucceedUI.SetActive(true);
            SucceedUI.GetComponent<GameSucceedPanel>().SetUIText(EarnedCrystalCount, Bonus);
        }
        else
        {
            FailedUI.SetActive(true);
        }
    }

    public void GameStart()
    {
        StartUI.SetActive(false);
        DistanceSlider.transform.parent.gameObject.SetActive(true);
    }

    public void RetryButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FailedUI.SetActive(false);
        StartUI.SetActive(true);
    }

    public void NextButtonClick()
    {
        //Çok sayıda level için gelecek level'ın yükleneceği yer.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SucceedUI.SetActive(false);
        StartUI.SetActive(true);
    }
}
