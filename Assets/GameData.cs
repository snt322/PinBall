using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    private List<DefaultSettingDef> settingArray = new List<DefaultSettingDef>(10);

    public List<DefaultSettingDef>  Setting
    {
        get
        {
            return settingArray;
        }
        set
        {
            this.settingArray = value;
        }
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PushSetting()
    {

    }

    DefaultSettingDef PopSetting()
    {
        int num = settingArray.Count;
        DefaultSettingDef tmpV = settingArray[num];
        settingArray.RemoveAt(num);


        return tmpV;
    }


}
