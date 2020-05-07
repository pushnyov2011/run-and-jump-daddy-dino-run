using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;


public class gameconroller : MonoBehaviour
{
   // public GameObject prefab_text;
    public int score;
    public Text Score_text;
    public float timeF;
    public Text panel_gamescore;
    public Text panel_score;
    public Text panel_best_score;
    public int clickedAnswer { get; private set; }
    public bool pauseActive =false;
    public bool loseActive = false;
    public GameObject panel;
    public GameObject imgage_load;
    AudioSource audio_source;
    public GameObject fonimage;
    public GameObject rain_space;
    SpriteRenderer fon;
    public int chahesomefting = 70;
    public int a;
    string adUnitId2 = "ca-app-pub-9974352663449666/8051990771";
    private BannerView bannerView2;
    private const string gameover = "ca-app-pub-9974352663449666/9222242849";
    private InterstitialAd ad;
    public int ads;



    // Start is called before the first frame update
    void Awake()
    {
        audio_source = GetComponent<AudioSource>();
        fon = fonimage.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        string appId = "ca-app-pub-9974352663449666~7812317627";
        MobileAds.Initialize(appId);
        this.RequestBanner2();

        if (!PlayerPrefs.HasKey("ads")) { PlayerPrefs.SetInt("ads", 0); }
        PlayerPrefs.SetInt("ads", PlayerPrefs.GetInt("ads")+1);
        ads = PlayerPrefs.GetInt("ads");




        //  Instantiate(prefab_text , transform.position, Quaternion.identity);

        //  fon.color = Color.red;
        PlayerPrefs.SetInt("L", 0);
        imgage_load.SetActive(false);
        score = 0;
        if (!PlayerPrefs.HasKey("bs")) { PlayerPrefs.SetInt("bs", score); }
    }

    // Update is called once per frame
    void Update()
    {
       // fon.color = new Color(0, 0, 0);
        // fon.color = Color.black;

        if (PlayerPrefs.GetInt("L") == 1) lose_panel();
        if (PlayerPrefs.GetInt("L") == 0)
        {
            if (PlayerPrefs.GetInt("bs") <= score) { PlayerPrefs.SetInt("bs", score); }
            Score_text.text = "score: " + score.ToString();
            timeF += Time.deltaTime;
            if (timeF >= 0.2)
            {

                if (pauseActive == false || loseActive == false)
                {
                    score++;
                    timeF = 0;

                }

            }
            if (score >= chahesomefting)

            {
                bool doing = true;
               
                    // fon.color = Color.white;
                    a = Random.Range(0, 7);
                


                if (a == 0) { fon.color = new Color(0, 0, 0); }
                else if (a == 1) { fon.color = new Color(255, 255, 255); }
                else if (a == 2) { fon.color = new Color(255, 0, 0); }
                else if (a == 3) { rain_space.SetActive(true); }
                else if (a == 5) { fon.color = new Color(31, 255, 0); }
                else if (a == 4) { rain_space.SetActive(false); }
                else if (a == 6) { rain_space.SetActive(true); }
                chahesomefting += 170;
                bannerView2.Destroy();
                this.RequestBanner2();
            }
        }

    }
    private void RequestBanner2()
    {
        //#if UNITY_ANDROID

        //#elif UNITY_IPHONE
        //            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        //#else
        //            string adUnitId = "unexpected_platform";
        //#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView2 = new BannerView(adUnitId2, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView2.LoadAd(request);
        bannerView2.Show();

    }
    public void lose_panel() { loseActive=true;
        //panel.SetActive(true);
        audio_source.Pause();
        panel_gamescore.text = "BEST GAME SCORE: " + 4965;
        panel_best_score.text = "YOUR BEST SCORE: " + PlayerPrefs.GetInt("bs");
        panel_score.text = "YOUR SCORE: " + score;
        //Time.timeScale = 0;
        panel.SetActive(true);

    }

    
       public void load_scene(int i)
    {
        imgage_load.SetActive(true);
        SceneManager.LoadScene(i);
        if (PlayerPrefs.GetInt("ads") >= 3)
        {
            PlayerPrefs.SetInt("ads", 0);
            //SceneManager.LoadScene(i);
            ad = new InterstitialAd(gameover);
            AdRequest request = new AdRequest.Builder().Build();
            ad.LoadAd(request);
            ad.OnAdLoaded += onAdLoad;
        }
    }
    public void onAdLoad(object sender, System.EventArgs args)
    {
        ad.Show();

    }
}

