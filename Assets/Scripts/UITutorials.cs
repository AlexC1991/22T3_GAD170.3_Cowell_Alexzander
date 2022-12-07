
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{


    public class UITutorials : MonoBehaviour
    {
        [Header("Text")]
        [SerializeField] private Text helpFulHints;
        [SerializeField] private Text timeOrWave;
        [SerializeField] private Text textTutorial1;
        [SerializeField] private Text textTutorial2;
        [SerializeField] private Text textTutorial3;
        [SerializeField] private Text textTutorial4;
        [SerializeField] private Text textroom2Tutorial;
        [SerializeField] private Text healthNumber;

        [Header("'Other' Scripts")]
        [SerializeField] private EnemyKillColor enemies;
        [SerializeField] private InTangable inTang;
        [SerializeField] private InTangable inTang2;
        [SerializeField] private RM2 roomWall2;
        [SerializeField] private WaterTrigger waterT;

        [Header("Canvas GameObjects")]
        [SerializeField] private GameObject timeOrWaveUI;
        [SerializeField] private GameObject tutorial1;
        [SerializeField] private GameObject tutorial2;
        [SerializeField] private GameObject tutorial3;
        [SerializeField] private GameObject tutorial4;
        [SerializeField] private GameObject room2Tutorial;

        private int healthN;
        private int randomQuotes;
        private float countDownQuote = 10;
        private float countDownHold;
        private int quote1 = 1;
        private int quote2 = 2;
        private int quote3 = 3;
        private int quote4 = 4;
        private int quote5 = 5;
        private bool timeDone = true;
        private bool timeStart = true;
        private bool reCheck = true;
        private bool reCheckAgain = true;
        private bool popUI = false;
        [HideInInspector]
        public bool destroyGO = false;
        

        void Start()
        {
            healthN = 15;
            countDownHold = countDownQuote;
            popUI = false;
            Time.timeScale = 0;
            Tutorial1Screen1();
            healthNumber.text = "Health: " + healthN.ToString();
            
        }

        
        void Update()
        {

            if (waterT.waterHit == true)
            {
                Debug.Log("Water is hit");
                healthN -= 1;
                healthNumber.text = "Health: " + healthN.ToString();
            }

            if (roomWall2.room2Interact == true)
            {
                Room2Tutorial();
            }

            

            if (reCheck == true)
            {
                AlwaysCheck();
            }
            else
            {
                FirstCheck();
            }

            if (reCheckAgain == true)
            {
                FirstCheck();
            }
            else
            {
                SecondCheck();
            }          

            randomQuotes = Random.Range(1, 5);

            if (randomQuotes == 1)
            {
                randomQuotes = quote1;
            }
            if (randomQuotes == 2)
            {
                randomQuotes = quote2;
            }
            if (randomQuotes == 3)
            {
                randomQuotes = quote3;
            }
            if (randomQuotes == 4)
            {
                randomQuotes = quote4;
            }
            if (randomQuotes == 5)
            {
                randomQuotes = quote5;
            }

            

            //  ///  ///  /// /// /// //

           

            if (timeStart == true)
            {
                QuoteStartCount();

                if (timeDone == true)
                {
                    if (randomQuotes == quote1)
                    {
                        helpFulHints.text = "Move Using W,A,S,D Keys".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote2)
                    {
                        helpFulHints.text = "Use Space to Jump".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote3)
                    {
                        helpFulHints.text = "You have to activate a blue ORB to make the enemies 'BLUE' ".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote4)
                    {
                        helpFulHints.text = "There is a 'Bonus Room' but you need 30 points to unlock it!".ToString();
                        timeDone = false;
                    }
                    if (randomQuotes == quote5)
                    {
                        helpFulHints.text = "Did you See the Boss yet? ;D".ToString();
                        timeDone = false;
                    }
                }
                
            }  if (popUI == true)
            {
                timeOrWaveUI.SetActive(true);
                timeOrWaveUI.GetComponent<CanvasGroup>().alpha = 1;
                timeOrWaveUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            if (inTang.timerSS == false)
            {
                popUI = false;

                if (popUI == false)
                {
                    timeOrWaveUI.SetActive(false);
                    timeOrWaveUI.GetComponent<CanvasGroup>().alpha = 0;
                    timeOrWaveUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
                
            }
        }

        private void QuoteStartCount()
        {
            if (timeStart == true)
            {
                
                countDownQuote -= (1) * Time.fixedDeltaTime;
                QuoteCounter();
            }
        }
        private void QuoteCounter()
        {                    
            if (countDownQuote <= 0)
            {
                countDownQuote = countDownHold;
                timeDone = true;
            }
            
        }

        private void FirstCheck()
        {
            if (inTang.playerIsClose == true)
            {
                ButtonT();
                timeStart = false;               
            }
            else if (inTang2.playerIsClose == true)
            {
                ButtonT();
                timeStart = false;                
            }
            else if (enemies.closeToMe == true)
            {
                ButtonE();
                timeStart = false;                
            }
            
            reCheckAgain = false;
           
        }

        private void SecondCheck()
        {
            if (inTang.playerIsClose == false)
            {
                timeStart = true;
                
            }
            else if (enemies.closeToMe == false)
            {
                timeStart = true;
                
            }
            else if (inTang.timerSS == false)
            {
                timeStart = true;
                
            }
            else if (inTang.timeWolf == false)
            {
                timeStart = true;
                
            }
            else if (inTang2.playerIsClose == false)
            {
                timeStart = true;
                
            }
            reCheck = true;
        }

        private void AlwaysCheck()
        {
             if (inTang.timeWolf == true){
                CountDownTime();
                timeStart = false;
                popUI = true;
            }
             else if (inTang.timerSS == true){
                CountDownTime();
                timeStart = false;
                popUI = true;
            }
            reCheck = false;
            reCheckAgain = true;
        }
        private void ButtonE()
        {
            helpFulHints.text = "Press 'E' To Turn Enemies Blue".ToString();
        }
        private void ButtonT()
        {
            helpFulHints.text = "Press 'E' To Turn The Pillers Visible".ToString();
        }
        private void CountDownTime()
        {
            timeOrWave.text = "Time Limit: " + inTang.timer.ToString("F0");
        }
        private void CountDownWave()
        {
            helpFulHints.text = "Wave Round: ".ToString();
        }

        public void Tutorial1Screen1()
        {
            
            textTutorial1.text = "Hello & Welcome to The Wonder Wall. \n " + "In this game you will be inside of a dungeon in space and to get out you will need to complete all 4 rooms".ToString();
            
            tutorial1.GetComponent<CanvasGroup>().alpha = 1;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = true;
            tutorial1.GetComponent<CanvasGroup>().interactable = true;

            tutorial2.GetComponent<CanvasGroup>().alpha = 0;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial2.GetComponent<CanvasGroup>().interactable = false;

            tutorial3.GetComponent<CanvasGroup>().alpha = 0;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial3.GetComponent<CanvasGroup>().interactable = false;

            tutorial4.GetComponent<CanvasGroup>().alpha = 0;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial4.GetComponent<CanvasGroup>().interactable = false;

        }
        public void Tutorial1Screen2()
        {
            textTutorial2.text = "On the bottom of your screen will be the UI read out \n " + "Left and right are what you make of it and the middle are suggestions or interactions".ToString();

            tutorial1.GetComponent<CanvasGroup>().alpha = 0;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial1.GetComponent<CanvasGroup>().interactable = false;

            tutorial2.GetComponent<CanvasGroup>().alpha = 1;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = true;
            tutorial2.GetComponent<CanvasGroup>().interactable = true;

            tutorial3.GetComponent<CanvasGroup>().alpha = 0;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial3.GetComponent<CanvasGroup>().interactable = false;

            tutorial4.GetComponent<CanvasGroup>().alpha = 0;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial4.GetComponent<CanvasGroup>().interactable = false;
        }
        public void Tutorial1Screen3()
        {
            textTutorial3.text = "In each room there will be different hazards like water or space of which will kill you instantly and another which just spawns enemies to try and kill you".ToString();
           
            tutorial1.GetComponent<CanvasGroup>().alpha = 0;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial1.GetComponent<CanvasGroup>().interactable = false;

            tutorial2.GetComponent<CanvasGroup>().alpha = 0;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial2.GetComponent<CanvasGroup>().interactable = false;

            tutorial3.GetComponent<CanvasGroup>().alpha = 1;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = true;
            tutorial3.GetComponent<CanvasGroup>().interactable = true;

            tutorial4.GetComponent<CanvasGroup>().alpha = 0;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial4.GetComponent<CanvasGroup>().interactable = false;
        }
        public void Tutorial1Screen4()
        {
            textTutorial4.text = "You can collect coins which will open doors and add points to your total score. \n " + "If you hit a blue orb with E you can turn enemies blue which than you can kill like Pac Man :D" .ToString();

            tutorial1.GetComponent<CanvasGroup>().alpha = 0;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial1.GetComponent<CanvasGroup>().interactable = false;

            tutorial2.GetComponent<CanvasGroup>().alpha = 0;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial2.GetComponent<CanvasGroup>().interactable = false;

            tutorial3.GetComponent<CanvasGroup>().alpha = 0;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial3.GetComponent<CanvasGroup>().interactable = false;

            tutorial4.GetComponent<CanvasGroup>().alpha = 1;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = true;
            tutorial4.GetComponent<CanvasGroup>().interactable = true;
        }

        public void EndOfTutorial()
        {
            tutorial1.GetComponent<CanvasGroup>().alpha = 0;
            tutorial1.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial1.GetComponent<CanvasGroup>().interactable = false;

            tutorial2.GetComponent<CanvasGroup>().alpha = 0;
            tutorial2.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial2.GetComponent<CanvasGroup>().interactable = false;

            tutorial3.GetComponent<CanvasGroup>().alpha = 0;
            tutorial3.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial3.GetComponent<CanvasGroup>().interactable = false;

            tutorial4.GetComponent<CanvasGroup>().alpha = 0;
            tutorial4.GetComponent<CanvasGroup>().blocksRaycasts = false;
            tutorial4.GetComponent<CanvasGroup>().interactable = false;

            Time.timeScale = 1;
        }

        private void Room2Tutorial()
        {            
            room2Tutorial.GetComponent<CanvasGroup>().alpha = 1;
            room2Tutorial.GetComponent<CanvasGroup>().blocksRaycasts = true;
            room2Tutorial.GetComponent<CanvasGroup>().interactable = true;
            textroom2Tutorial.text = "You made it to room 2! :D. \n" + "In this room you will have to use the 2 purple buttons to activate the bridge. Once you have done so you have 35 seconds to get to the other block. Collect all coins to open the next room!".ToString();
        }

        public void Room2TutorialOver()
        {
            room2Tutorial.SetActive(false);
            destroyGO = true;
        }
    }
}
