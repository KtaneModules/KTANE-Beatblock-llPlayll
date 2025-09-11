using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;

public class beatblock : MonoBehaviour
{
    [SerializeField] private KMBombInfo Bomb;
    [SerializeField] private KMAudio Audio;

    string[,] Charts = new string[100, 3]
    {
        { "La Di Da (Nightcore &\nCut Ver.)", "Baracuda", "Piger" },
        { "Cold Green Eyes", "Station Earth (ft. Roos Denayer)", "_Play_" },
        { "Historia (Cut Ver.)", "CHiCO with HoneyWorks", "Piger" },
        { "Metel", "Dope17, KVESTAR", "Ratøri" },
        { "Quaver (Cut ver.)", "dj TAKA", "Piger" },
        { "I Wanna Be A Machine", "The Living Tombstone", "_Play_" },
        { "risuyu krov'yu", "ANGUISH, hxvvxn & billboards", "Ratøri" },
        { "Los! Los! Los! (Cut Ver.)", "Yuuichi Yagi", "Piger" },
        { "Eu Li Na Biblia (Cut Ver.)", "Aline Barros", "Piger" },
        { "Zetsubou plantation\n(Cut Ver.)", "Yousei Teikoku", "Piger" },
        { "satori de pon!", "goreshit", "Piger" },
        { "FLYING OUT TO THE SKY", "Camellia feat. (a lot of names)", "Piger" },
        { "Tensei Redemption", "Shinigiwa Satellite", "Piger" },
        { "Armed and Ready", "Jeff Williams feat. Casey Lee", "Piger" },
        { "MURDER PLOT", "KORDHELL", "Piger" },
        { "Cat Loving", "Kashii Moimi feat. KAFU (Remix by\nkageminori)", "Ratøri" },
        { "NOSE RING (forlornly\nTechno Remix)", "Lil Peep, forlornly", "Ratøri, Piger" },
        { "Der Wald (kors k Remix)", "エレハモニカ", "Piger" },
        { "Cats", "The Living Tombstone", "Random22" },
        { "DUELING WINDS", "KEY AFTER KEY", "DerpyNub" },
        { "In Darkness", "NoteBlock", "CountryballsEU" },
        { "Lost in Translation", "nitsua", "Starcat_JP" },
        { "Options", "Frums", "3CGaming" },
        { "Shoot 'em Up", "Tsunku", "abugida" },
        { "Your Best Nightmare", "Toby Fox", "Toatd" },
        { "Lustre", "Camellia", "lalafk" },
        { "Pyromania", "ime44", "Bean" },
        { "BIG SHOT", "Toby Fox", "Flecha Da Foxy" },
        { "Seimeisei Syndrome", "Camellia", "himych" },
        { "Space Invaders", "Teminite & MDK", "Piger vs. himych" },
        { "BIKE", "tanger", "Flecha Da Foxy" },
        { "Otonoke", "Creepy Nuts", "Cytruss" },
        { "Ouais Ouais (ft. SlyLeaf)", "LemKuuja", "Starcat_JP" },
        { "Poison AND÷OR\nAffection", "LeaF", "DIYDamian" },
        { "My Bread was Burnt to\na Crisp", "picdo", "audrNa" },
        { "Pico Pico Adventure", "Mr. Asyu", "JustAnAmpharos" },
        { "Bucket of Wet Slop\n*grins*", "bubbyclub / joooleeeaaa", "Random22" },
        { "Duck song", "Ducks artist", "Qkie" },
        { "Exit the earth's\natomosphere", "Camellia", "Cytruss" },
        { "Harumachi Clover", "Will Stetson", "Piger" },
        { "Whatsapp Drip Car", "Leng December", "owaloid" },
        { "bits of sharp plastic", "LilyNiku", "Coz the Bunny" },
        { "anybody can find love\n(except you.)", "hkmori", "Random22" },
        { "death by amen", "Virtual Riot", "DPS2004" },
        { "Dune Eternal", "Heaven Pierce Her", "Charter" },
        { "Enemy Retreating", "UTY Team", "Something" },
        { "Feel good", "Syn Cole", "Matheo000" },
        { "Fire4Fun", "Jhariah", "Sploky" },
        { "Gravity Falls theme", "Brad Breeck", "Waxy" },
        { "Hero", "Mili", "MediocrePancake" },
        { "I can't sing a love song", "Kessoku Band", "Aylary" },
        { "INTERNET YAMERO", "Aiobahn feat. KOTOKO", "riversideee" },
        { "Mental Chainsaw", "Kairiki Bear", "JustAnAmpharos" },
        { "Nightmare", "RJ Pasin", "OblivionAXiS" },
        { "Oyasmy", "seatrus", "lalafk" },
        { "Pandora Palace", "Toby Fox", "pois" },
        { "Phantom", "Wyldfyre1 & F-777", "Matheo000" },
        { "Reincarnation Apple", "PinocchioP", "himych" },
        { "Remedy + Retribution", "Undertale Yellow Team", "Monkeygogobeans,Country & Eshan" },
        { "Scarlet Forest", "Toby Fox", "xSophchii" },
        { "Seventh Heaven", "Inoha", "lalafk" },
        { "slopinator", "DawnAndNight", "DawnAndNight" },
        { "Ta1lsD003 G2961 remix\n(modified)", "Ta1lsD0ll, G2961", "ItsKirby69" },
        { "Wink", "Azari ft. Rosu", "himych" },
        { "YONA YONA DANCE", "Akiko Wada", "Rivot" },
        { "Eek!", "Surasshu", "Frogballoon" },
        { "It's Raining Somewhere\nElse", "Toby Fox", "Something" },
        { "Chaos King", "Toby Fox", "Spookeegie" },
        { "Final Duet", "Pedro Silva", "Something" },
        { "RUN!", "S.Agerbæk-Larsen & T.Jørgensen", "Whenpigfly666" },
        { "(The) Red * Room", "Camellia", "Ratøri" },
        { "This Future (we didn't\nexpect)", "Camellia", "H.I.P.E." },
        { "Brawl Breaks", "3R2", "Piger & himych" },
        { "First Town Of This\nJourney", "Camellia", "himych" },
        { "Trigger (Zekk Remix)", "Dustwoxx", "himych" },
        { "You are the Miserable", "t+pazolite", "rand06, Piger" },
        { "Galaxy Collapse", "Kurokotei", "CIS Community" },
        { "The Empress", "UNDEAD CORPORATION", "Ratøri, Piger" },
        { "1,2,3,4!", "Cansol", "Cytruss" },
        { "A Rhythm Gamer's\nWorst Nightmare", "Return2Nothing", "Random22" },
        { "Ävril -Flicka i krans-", "Rigël Theatre", "Bekko" },
        { "Bling-Bang-Bang-Born", "Creepy Nuts", "Lux" },
        { "Bunny Panic!!!", "3R2", "Piger" },
        { "BUTCHER VANITY", "FLAVOR FOLEY", "owaloid" },
        { "BUTT3RFLi3S >w<", "milkypossum", "Ratøri & Piger" },
        { "Calamity Fortune", "LeaF", "Merfmo" },
        { "Embraced by the Flame", "UNDEAD CORPORATION", "Piger" },
        { "Endless Tewi-Ma Park", "IOSYS", "Random22" },
        { "Flamewall", "Camellia", "bliss" },
        { "Gold Dust - Fox\nStevenson Remix\n(Cut Ver.)", "DJ Fresh", "Piger" },
        { "hip shop", "Toby Fox", "Flecha Da Foxy" },
        { "Idol", "YOASOBI", "Nic" },
        { "icantbelieveiletyougetaway", "aldn", "Cytruss" },
        { "Igaku", "原口沙輔", "Piger" },
        { "Isolation", "NightHawk22", "PhilG [Zeni]" },
        { "Lavie (Tsukino Cover)", "すりぃ", "Piger" },
        { "MAYDAY feat. Laura\nBrehm (Cut Ver.)", "TheFatRat", "Piger" },
        { "On Little Cat Feet", "Nightmargin", "Piger" },
        { "Samama Festival!\n(katagiri bootleg)", "Mrs. GREEN APPLE", "_Play_" },
        { "Stereo Sayan 3D\n(Cut ver.)", "fartwad", "Piger" }
    };

    [SerializeField] KMSelectable Overlay;
    [SerializeField] SpriteRenderer OverlayRenderer;
    [SerializeField] Sprite[] OverlaySprites;
    [SerializeField] KMSelectable BG;
    [SerializeField] SpriteRenderer BGRenderer;
    [SerializeField] Sprite[] BGSprites;
    [SerializeField] TextMesh[] ChartInfo; // Song Name, Author, Charter

    int GenChartCount = 8;

    int genChart;
    List<int> selectionCharts = new List<int>();
    int selectedChart = 0;

    static int ModuleIdCounter = 1;
    int ModuleId;
    private bool ModuleSolved;

    void Awake()
    {
        ModuleId = ModuleIdCounter++;
        Overlay.OnHighlight += delegate () { OverlayRenderer.sprite = OverlaySprites[1]; };
        Overlay.OnHighlightEnded += delegate () { OverlayRenderer.sprite = OverlaySprites[0]; };
        BG.OnInteract += delegate () { CycleBG(); return false; };
        Overlay.OnInteract += delegate () { Submit(); return false; };
    }

    void CycleBG()
    {
        if (ModuleSolved) return;
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, BG.transform);
        BG.AddInteractionPunch();
        selectedChart++;
        selectedChart %= GenChartCount;
        BGRenderer.sprite = BGSprites[selectionCharts[selectedChart]];
    }

    void Submit()
    {
        if (ModuleSolved) return;
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, BG.transform);
        Overlay.AddInteractionPunch();
        if (selectionCharts[selectedChart] == genChart)
        {
            Log($"Submitted {LogChartName(selectionCharts[selectedChart])}, which is correct. Module Solved!");
            ModuleSolved = true;
            GetComponent<KMBombModule>().HandlePass();
        }
        else
        {
            Log($"Submitted {LogChartName(selectionCharts[selectedChart])}, which is incorrect. Strike! Regenerating the module...");
            GetComponent<KMBombModule>().HandleStrike();
            Generate();
        }
    }

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        genChart = Rnd.Range(0, Charts.Length / 3);
        for (int i = 0; i < 3; i++) ChartInfo[i].text = Charts[genChart, i];
        ChartInfo[0].fontSize = genChart == 92 ? 65 : 80; // icantbelieveiletyougetaway edge case
        ChartInfo[1].transform.localPosition = new Vector3(-0.0405f, 0.0151f, -0.0392f + -0.0131f * Charts[genChart, 0].Count(x => x == '\n'));

        selectionCharts = new List<int>();
        selectionCharts.Add(genChart);
        for (int i = 0; i < GenChartCount - 1; i++)
        {
            int addChart = Rnd.Range(0, Charts.Length / 3);
            while (selectionCharts.Contains(addChart)) addChart = Rnd.Range(0, Charts.Length / 3);
            selectionCharts.Add(addChart);
        }
        selectionCharts = selectionCharts.Shuffle();
        BGRenderer.sprite = BGSprites[selectionCharts[0]];
        selectedChart = 0;
        Log($"Answer chart - {LogChartName(genChart)}.");
        Log($"Selectable charts, in order - {selectionCharts.Select(x => LogChartName(x)).Join(", ")}.");
    }

    string LogChartName(int n)
    {
        return Charts[n, 0].Replace('\n', ' ');
    }

    void Log(string arg)
    {
        Debug.Log($"[Beatblock #{ModuleId}] {arg}");
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use <!{0} cycle (#)> to cycle the background once (or, optionally, # times). Use <!{0} play> or <!{0} submit> to press the Play button.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string Command)
    {
		var commandArgs = Command.ToUpperInvariant().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        if (commandArgs.Length < 1 || commandArgs.Length > 2) yield return "sendtochatmessage Invalid command!";
        else
        {
            switch (commandArgs[0])
            {
                case "CYCLE":
                    int cycleCount = 1;
                    if (commandArgs.Length == 2)
                    {
                        if (int.TryParse(commandArgs[1], out cycleCount))
                        {
                            if (cycleCount < 1)
                            {
                                yield return "sendtochatmessage Invalid cycle count!";
                                yield break;
                            }
                        }
                        else
                        {
                            yield return "sendtochatmessage Invalid cycle count!";
                            yield break;
                        }
                    }
                    yield return null;
                    for (int i = 0; i < cycleCount; i++)
                    {
                        BG.OnInteract();
                        yield return new WaitForSeconds(0.1f);
                    }
                    break;
                case "PLAY":
                case "SUBMIT":
                    if (commandArgs.Length != 1)
                    {
                        yield return "sendtochatmessage Invalid command!";
                        yield break;
                    }
                    else
                    {
                        yield return null;
                        Overlay.OnInteract();
                    }
                    break;
                default:
                    yield return "sendtochatmessage Invalid command!";
                    yield break;
            }
        }
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        yield return null;
        while (selectionCharts[selectedChart] != genChart)
        {
            BG.OnInteract();
            yield return new WaitForSeconds(0.1f);
        }
        Overlay.OnInteract();
    }
}
