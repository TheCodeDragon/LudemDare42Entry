using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    //Game manager Link
    private GameManager GM;
    [Header("UI Config")]
    public Text TX_Value;
    public GameObject GO_Bar;
    private float maxBarLength;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        maxBarLength = GO_Bar.GetComponent<RectTransform>().rect.width;

    }
    // Update is called once per frame
    void Update () {
        //Grab the current health
        int UIValue = GM.IN_PlayerHealth;
        //Grab the max health
        int UIValueMax = GM.IN_PlayerMaxHealth;
        //Scale the bar along the X by the percentage
        GO_Bar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (maxBarLength / UIValueMax)*UIValue);
        //Update the text value.
        TX_Value.text = UIValue.ToString();
	}
}
