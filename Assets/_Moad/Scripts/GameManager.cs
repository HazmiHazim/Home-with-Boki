using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text Question;

    public TMP_Text[] Ans;
   
    public int maxint, Minint;
    [HideInInspector]
   public int result;

    public GameObject Key;
    public static GameManager Instance;

    public TMP_Text ScoreTxt;
    int score;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

       

    }
    // Start is called before the first frame update
    void Start()
    {
        

        int num1, num2;
        num1 = Random.Range(1, Minint);
        num2 = Random.Range(1, maxint);
      
            result = num1 / num2;
            Question.text = num1 + " / " + num2 + " =  ?";
            int rand = Random.Range(0, Ans.Length);
            for(int i=0;i< Ans.Length; i++)
            {
                if(i != rand)
                {
                    Ans[i].text = Random.Range(Minint, maxint).ToString();
                }
                else
                {
                    Ans[i].text = result.ToString();
                }
            }
        
       
    }
    public void UpdateScore(int s)
    {
        score += 10;
        ScoreTxt.text = "score : " + score;
    }
  public void SpawnKey(Vector3 pos)
    {
        Instantiate(Key, pos, Quaternion.identity);
    }
}
