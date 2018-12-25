using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerController : MonoBehaviour {

    public static StateManagerController staticStateManager;
    // 0 = locked  1 = easy unlocked  2 = med unlocked 3 = hard unlocked 4 = impossible unlocked
    public int level1 = 1;
    public int level2 = 0;
    public int level3 = 0;
    public int level4 = 0;
    public int level5 = 0;
    public int level6 = 0;
    public int level7 = 0;
	
}
