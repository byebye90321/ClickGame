using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacede : MonoBehaviour {
    private static GameFacede instance;
    public static GameFacede GetInstance() {
        if (instance == null)
        { //第一次被呼叫的時候
            instance = GameObject.FindObjectOfType<GameFacede>();
            if (instance == null)
            {
                throw new System.Exception("GameFacede不存在於場景中，請在場景中添加喔喔喔"); //報錯
            }
        }
        return instance;
    }

    public StageData[] stageDatas;
}
