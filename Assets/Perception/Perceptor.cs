using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptor : MonoBehaviour
{
    public class PerceptionEvent
    {
        public enum senses { VISION, SOUND };
        public enum types { NEW, LOST };
        public enum threatLvls { FRIEND, SUS, THREAT}
        public GameObject gObj;
        public senses sense;
        public types type;
        public threatLvls threatLvl;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
