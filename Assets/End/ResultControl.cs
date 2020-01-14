using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yukidango.BarrageShooting.Boss;
using Yukidango.BarrageShooting.DataBase;

namespace Yukidango.BarrageShooting.End
{
    public class ResultControl : MonoBehaviour
    {
        private GameObject result;
        private DataFormat[] data = new DataFormat[10];
        public GameObject textPrefab;

        // Start is called before the first frame update
        void Start()
        {

            result = GameObject.Find("result");
            result.GetComponent<Text>().color = Color.yellow;
            Debug.Log(BossController.HitPoint.hitPoint.ToString());
            if (BossController.HitPoint.hitPoint <= 0)
            {
                result.GetComponent<Text>().text = "finish";
            }
            else
            {
                result.GetComponent<Text>().text = "BadEnd";
            }
            
            GameObject rank = GameObject.Find("Rank");
            rank.GetComponent<Text>().color = Color.red;
            rank.GetComponent<Text>().text = "Ranking Top 10";

            var content = GameObject.Find("Content");
            
            data = DataControll.getDb();
            for (int i = 0; i < data.Length; i++)
            {
                GameObject _text = Instantiate (textPrefab, content.transform);
                string textData = "Rank" + i.ToString() + " score:" + data[i].score  +" date:" + data[i].date;
                ResultScoreTextControl r = _text.GetComponent<ResultScoreTextControl>();
                r.setTextData(textData);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("TileDisplay");
                ScoreCount.score = 0;
            }
        }

    }
}
