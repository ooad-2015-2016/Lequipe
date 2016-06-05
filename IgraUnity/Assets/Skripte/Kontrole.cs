using UnityEngine;
using System.Collections;


public class Kontrole : MonoBehaviour {
    float brzina_skretanja_h = 5.0f;
    float brzina_skretanja_v = 2.5f;
    float leftConstraint;
    float rightConstraint;
    float upConstraint;
    float downConstraint;
    int bodovi = 0;
    int nivo = 1;
    public Glumac1 obicni_glumac1;
	public Glumac1 obicni_glumac2;
	public Glumac1 obicni_glumac3;
	public Glumac1 obicni_glumac4;
	public Glumac1 obicni_glumac5;
	public Glumac1 obicni_glumac6;
	public Glumac1 obicni_glumac7;
	public Glumac1 obicni_glumac8;
	public Glumac1 obicni_glumac9;
	public Glumac1 obicni_glumac10;
    public Oskar oskar;

    Glumci glumci_klasa;


    ArrayList glumci = new ArrayList();

    int broj = 0;

    // Use this for initialization
    void Start () {
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.0f, 0.0f, 0.0f)).x + 1;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.0f, 0.0f, 0.0f)).x - 1;
        downConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 0.0f, 0.0f)).y + 1;
        upConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 1.0f, 0.0f)).y - 1;
        transform.position = new Vector2(Screen.width / 2, Screen.height * 0.494f);


        glumci_klasa = new Glumci();
        glumci_klasa.obicni_glumac1 = obicni_glumac1;
        glumci_klasa.obicni_glumac2 = obicni_glumac2;
        glumci_klasa.obicni_glumac3 = obicni_glumac3;
        glumci_klasa.obicni_glumac4 = obicni_glumac4;
        glumci_klasa.obicni_glumac5 = obicni_glumac5;
        glumci_klasa.obicni_glumac6 = obicni_glumac6;
        glumci_klasa.obicni_glumac7 = obicni_glumac7;
        glumci_klasa.obicni_glumac8 = obicni_glumac8;
        glumci_klasa.obicni_glumac9 = obicni_glumac9;
        glumci_klasa.obicni_glumac10 = obicni_glumac10;
        glumci_klasa.downConstraint = downConstraint;

        glumci = new ArrayList();
        Invoke("DodajOskar", 5.0f);


        while (glumci.Count < nivo * 10)
        {
            broj = broj % 10;
            broj++;

            Glumac novo = glumci_klasa.napraviGlumca(broj);

            glumci.Add(novo);            
        }

        Physics.IgnoreLayerCollision(9, 9);
    }

    void DodajOskar()
    {
        Oskar novi = (Oskar)Instantiate(oskar, new Vector3(Random.Range(leftConstraint, rightConstraint), Random.Range(downConstraint, upConstraint), -5), Quaternion.identity);
        Invoke("BrisiOskar", 7.5f);
        Invoke("DodajOskar", 10.0f);
    }

    void BrisiOskar()
    {
        Destroy(GameObject.Find("oskar(Clone)"));
    }
	
	// Update is called once per frame
	void Update () {
        Time.fixedDeltaTime = 0.02f;
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftConstraint)
        {
            transform.Translate(Vector2.left * Time.deltaTime * brzina_skretanja_h);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightConstraint)
        {
            transform.Translate(Vector2.right * Time.deltaTime * brzina_skretanja_h);
        }

        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < upConstraint)
        {
            transform.Translate(Vector2.up * Time.deltaTime * brzina_skretanja_v);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > downConstraint)
        {
            transform.Translate(Vector2.down * Time.deltaTime * brzina_skretanja_v);
        }

        foreach (Glumac g in glumci)
        {
            if(g.Gotov())
            {
                if (Random.value > g.vjerovatnoca)
                    g.Postavi();
            }
        }


    }

    void OnGUI()
    {
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperLeft;

        GUI.Label(new Rect(10, 10, 150, 150), System.String.Format("<color=black><size=20>Vaš nivo je: {0}\nA bodovi su: {1}</size></color>", nivo, bodovi));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "oskar(Clone)")
        {
            Destroy(col.gameObject);
            bodovi++;
            if ((bodovi & (bodovi - 1)) == 0)
            {
                ++nivo;
                GameObject.Find("Pozadina").GetComponent<Skrol>().brzina += 0.1f;
                broj = broj % 10;
                broj++;
                glumci.Add(glumci_klasa.napraviGlumca(broj));
                broj = broj % 10;
                broj++;
                glumci.Add(glumci_klasa.napraviGlumca(broj));
                broj = broj % 10;
                broj++;
                glumci.Add(glumci_klasa.napraviGlumca(broj));

                foreach (Glumac g in glumci)
                    g.Ubrzaj();
            }

        }
        else if (col.gameObject.name.Substring(0, 6) == "Glumac")
        {
            if (System.Math.Abs(transform.position.x - col.transform.position.x) < 0.8f)
            {
                var log = GameObject.Find("Logika");
                log.GetComponent<Pauza>().Kraj();
            }
        }
        
    }

    public class Glumci
    {
        public Glumac1 obicni_glumac1;
        public Glumac1 obicni_glumac2;
        public Glumac1 obicni_glumac3;
        public Glumac1 obicni_glumac4;
        public Glumac1 obicni_glumac5;
        public Glumac1 obicni_glumac6;
        public Glumac1 obicni_glumac7;
        public Glumac1 obicni_glumac8;
        public Glumac1 obicni_glumac9;
        public Glumac1 obicni_glumac10;

        public float downConstraint; 



        public Glumac napraviGlumca(int i)
        {
            if (i == 1)
                return (Glumac1)Instantiate(obicni_glumac1, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else if (i == 2)
                return (Glumac1)Instantiate(obicni_glumac2, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else if (i == 3)
                return (Glumac1)Instantiate(obicni_glumac3, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else if (i == 4)
                return (Glumac1)Instantiate(obicni_glumac4, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else if (i == 5)
                return (Glumac1)Instantiate(obicni_glumac5, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else if (i == 6)
                return (Glumac1)Instantiate(obicni_glumac6, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else if (i == 7)
                return (Glumac1)Instantiate(obicni_glumac7, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else if (i == 8)
                return (Glumac1)Instantiate(obicni_glumac8, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else if (i == 9)
                return (Glumac1)Instantiate(obicni_glumac9, new Vector3(0, downConstraint, 0), Quaternion.identity);
            else
                return (Glumac1)Instantiate(obicni_glumac10, new Vector3(0, downConstraint, 0), Quaternion.identity);
        }
    }

}
