using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class BarTextDisplay : MonoBehaviour {
    private Slider slider;
    [SerializeField]
    private Text label;

    private void Awake() {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnValueChanged); //接收這個的值
    }

    private void OnValueChanged(float val) {
        val = Mathf.FloorToInt(val); //無條件捨去
        label.text = val + "/" + slider.maxValue;
    }
}
