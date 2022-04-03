using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YsoCorp;

public class CollectControl1 : MonoBehaviour
{
    bool trigger = false;
    bool finish = false;
    public List<GameObject> bagList;

    public Button restartButton;
    public Button nextLevelButton;

    public Image onClick;
    public Image onClickBackground;

    bool gameStart = false;

     void Start()
    {
        Time.timeScale = 1;
        Button restart = restartButton.GetComponent<Button>();
        Button nextLevel = nextLevelButton.GetComponent<Button>();

        restart.onClick.AddListener(RestartFunction);
        nextLevelButton.onClick.AddListener(NextLevelFunction);


    }



    void RestartFunction()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       YsoCorp.GameUtils.YCManager.instance.OnGameFinished(false);
    }

    void NextLevelFunction()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        YsoCorp.GameUtils.YCManager.instance.OnGameStarted(SceneManager.GetActiveScene().buildIndex + 1);
    }




    float distanceBags = 0.8f;
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (gameStart)
        {

      
        if (other.tag=="Collect")
        {
                Handheld.Vibrate();
            trigger = true;
            other.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            other.gameObject.tag = "Collected";
            bagList.Add(other.gameObject);
            other.gameObject.transform.parent = transform;
            /*
            for (int i = 1; i <= bagList.Count; i++)
            {
             bagList[bagList.Count-i].transform.position = transform.position + new Vector3(0, i*distanceBags, 3);
           
            }
            */

            for (int i = 1; i <= bagList.Count; i++)
            {
                bagList[bagList.Count - i].transform.position = transform.position + new Vector3(0,distanceBags*i,3);
         

            }
        }
        if (other.tag == "Truck")
        {
           
            finish = true;

            GetComponent<Swerve>().enabled = false;

            

           

            for (int i = 0; i < 5; i++)
            {
              
    
                bagList[i].transform.DOMove(other.transform.position, 0.5f);
               
                yield return new WaitForSeconds(0.1f);

             

            }
            yield return new WaitForSeconds(1);


                CheckBagsEnable();



        }

        if (other.tag == "Finish")
        {
            restartButton.gameObject.SetActive(true);
            nextLevelButton.gameObject.SetActive(true);
            GetComponent<Swerve>().enabled = false;
            Time.timeScale = 0;
           
        }
          }
    }

 

    void Update()
    {
        if (finish == true)
        {
            for (int i = 0; i < bagList.Count; i++)
            {

                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                bagList[i].transform.position = new Vector3(0, bagList[i].transform.position.y, bagList[i].transform.position.z);
            }

        }

        if (gameStart ==false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameStart = true;
                GetComponent<Movement>().enabled = true;
                GetComponent<Swerve>().enabled = true;

                onClick.enabled = false;
                onClickBackground.enabled = false;

            }
        }
     

        if (gameStart)
        {

       
        if (finish == false)
        {
                FollowBagsDelay();
        }

     

        if (trigger)
        {
           StartCoroutine(WaveEffect());
            trigger = false;
        }
        }
        else
        {
            GetComponent<Movement>().enabled = false;
            GetComponent<Swerve>().enabled = false;
        }
    }

    void FollowBagsDelay()
    {
        for (int i = 0; i < bagList.Count - 1; i++)
        {
            if (bagList[i].transform.parent != null)
            {
                bagList[i].transform.DOMoveX(bagList[i + 1].transform.position.x, 40 * Time.deltaTime);
            }
        }
    }
    IEnumerator WaveEffect()
    {

        for (int i = 1; i < bagList.Count + 1; i++)
        {
          
            var lastCup = bagList[bagList.Count - i];
            lastCup.transform.DOScale(30f, 0.125f);
            yield return new WaitForSeconds(0.1f);
            lastCup.transform.DOScale(25.0f, 0.125f);
    

        }

    }
  
    public void CheckBagsEnable()
    {
        for (var i = bagList.Count - 1; i > -1; i--)
        {
            if (bagList[i].activeSelf == false)
                bagList.RemoveAt(i);
        }
    }
}
