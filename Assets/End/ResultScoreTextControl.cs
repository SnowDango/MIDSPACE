using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace Yukidango.BarrageShooting.End
{
    public class ResultScoreTextControl : MonoBehaviour
    {
        private string text;

        public void setTextData(string text)
        {
            this.text = text;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            
            this.GetComponent<Text>().color = Color.cyan;
            this.GetComponent<Text>().text = this.text;

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
