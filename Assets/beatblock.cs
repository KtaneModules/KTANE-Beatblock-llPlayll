using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;
using UnityEngine.UI;

public class beatblock : MonoBehaviour
{
    [SerializeField] private KMBombInfo Bomb;
    [SerializeField] private KMAudio Audio;

    string[,] Charts =
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
        { "Seimeisei Syndrome", "かめりあ", "himych" },
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
        { "Someone Special", "tomatoism", "himych" },
        { "ONIGIRI FREEWAY", "OISHII", "pois" },
        { "Ravers Fantasy", "Tune Up", "Piger + BetaFail" },
        { "Flower Dance", "DJ OKAWARI", "lotus" },
        { "BPM=RT", "t+pazolite", "Random22" },
        { "PUSH UR T3MPRR", "femtanyl", "lalafk" },
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
        { "Stereo Sayan 3D\n(Cut ver.)", "fartwad", "Piger" },
        { "Flow", "Creo", "TGTM + Piger" },
        { "Honestly", "THØRNS", "thatguytheman" },
        { "Naruto", "snickerman7", "Panzerfaust" },
        { "The mario", "The mario", "The mario" },
        { "March of the Profane", "Danny Baranowsky", "Gotchfutchian" },
        { "Point and Click", "MEMODEMO x AQUASINE", "Cytruss & Piger" },
        { "Rabbit Hole", "DECO*27", "Bekko" },
        { "Vampire", "Deco*27", "thefinals" },
        { "World's End Valentine", "OMORI OST", "Sparking Circuits" },
        { "Leather Teeth (Beat\nJuggle)", "Carpenter Brut", "DawnAndNight" },
        { "Otis", "chipzel", "Charter" },
        { "GUARDIAN", "Toby Fox", "pois" },
        { "Death By AI: Lone\nSurvivor - Main Theme", "flowerhead", "Lux" },
        { "wish i could care less", "fizzd (ft. Yeo)", "DragonIvanRussia" },
        { "Ievan Polkka", "Eino Kettunen (C. Hatsune Miku)", "" },
        { "Charlie's Absolution", "Flecha Da Foxy", "Random22" },
        { "Daydream", "Cloudier", "PGO6973" },
        { "Im From Another\nDimension", "Brad Breeck", "Piger" },
        { "Flamewall", "Camellia", "bliss" },
        { "BANANA BUS\nBREAKDOWN", "fearless.", "skit.png" },
        { "DRAGONLADY", "Nankumo", "_Play_" },
        { "Limbus Company X Arknights\nCollab - Intervallo VI-EX Boss\nTheme 2", "Studio EIM", "Flareiozum" },
        { "Finixe (Cut Ver.)", "Silentroom", "lalafk" },
        { "In Love", "YOU LOVE HER", "Zorhan" },
        { "Artificial Chariot", "Riya", "Slipty" },
        { "White Surf Style 6", "Pedro Silva", "Whenpigfly666" },
        { "Precipice (Tanger\nRemix)", "Tanger", "Krmailence (CCC)" },
        { "Rockefeller Street\n(Nightcore Cut Ver.)", "Getter Jaani", "zeli" },
        { "Winter (The Wind Can\nBe Still)", "ConcernedApe", "DopeGamer" },
        { "(CCC) Creative Freedom\nEMEIFIED", "Emei", "FortT2" },
        { "THE FINAL STRATEGY", "rundownSD", "PhilG / Zeni" },
        { "Terminally Online", "Glitch Cat X wh1teskyy", "CoolModder" },
        { "FAILURE_CRITICAL", "Azali", "JLM" },
        { "P`rismatic fut`URE", "豊穣ミノリ", "azabi" },
        { "Toaster with Teeth", "Kasey Ozymy", "Gavi Guy" },
        { "Commatose", "Glass beach", "Unity" },
        { "The Devourer Of Gods", "DM DOKURO", "Hosted By Kakadu" },
        { "Tetoris", "Hiiragi Magnetite", "Worn + Asphalt09" },
        { "BACKSTREET BOUNCE", "KEY AFTER KEY", "DerpyTheNub" },
        { "Spoken For", "FLAVOR FOLEY", "olivia" },
        { "A Fool Moon Night", "Koxx", "zeli, Bliss, Piger, PhilG / Zeni" },
        { "The Cat Evolved Into\nThe Microwave-proof\nCat!", "かめりあ", "himych" },
        { "Salmiakki", "Frums", "Kirbo" },
        { "Dark Fountain", "Toby Fox I guess ?", "Whenpigfly666" },
        { "Steve's Lava Chicken\n(Camellia Remix)", "Camellia", "Slipty" },
        { "the night before\nBEATBLOCK", "jupitercl0uds", "jupitercl0uds" },
        { "Thick of It", "IShowSpeed, KSI", "CharterIGuess1" },
        { "A World on Fire", "Bo Burnham", "DPS2004" },
        { "Beyond", "philmakesnoise", "Kirbo" },
    };
    string[] NoteNames = { "Block", "Hold", "Side", "Mine", "Minehold", "Bounce" };
    string[] PaddleModeNames = { "Regular", "None", "360°" };

    [SerializeField] KMSelectable Overlay;
    [SerializeField] SpriteRenderer OverlayRenderer;
    [SerializeField] Sprite[] OverlaySprites;
    [SerializeField] KMSelectable BG;
    [SerializeField] SpriteRenderer BGRenderer;
    [SerializeField] Sprite[] BGSprites;
    [SerializeField] TextMesh[] ChartInfo; // Song Name, Artist, Charter
    [SerializeField] Slider BeatSlider;
    [SerializeField] Text BeatText;
    [SerializeField] KMSelectable[] KeypadButtons; // 0123456789.<
    [SerializeField] KMSelectable ShowResults;
    [SerializeField] TextMesh AccuracyText;
    [SerializeField] SpriteRenderer[] NoteRenderers;
    [SerializeField] TextMesh[] NoteDurations;
    [SerializeField] Sprite[] NoteSprites; // Block, Hold, Side, Mine, Minehold, Bounce
    [SerializeField] SpriteRenderer PaddleRenderer;
    [SerializeField] Sprite[] PaddleModeSprites; // Regular (No Icon), None, 360°
    [SerializeField] GameObject Stage1;
    [SerializeField] GameObject Stage2;
    [SerializeField] AudioClip HLClip;
    [SerializeField] AudioClip StrikeClip;
    [SerializeField] AudioClip CorrectClip;

    int GenChartCount = 8;
    int MinEndBeat = 16;
    int MaxEndBeat = 18;
    List<int> WeightedNoteCounts = new List<int> { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3 };
    List<int> WeightedNoteTypes = new List<int> { 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 5, 5 };
    List<int> WeightedPaddleModes = new List<int> { 0, 0, 0, 0, 0, 1, 1, 2, 2 };

    int genChart;
    List<int> selectionCharts = new List<int>();
    int selectedChart = 0;
    bool highlightBG, highlightPlay;

    int beats;
    List<string[]> chart = new List<string[]>();
    List<int> paddleModes = new List<int>();
    int fullCombo, misses = 0;
    string answerAccuracy;
    int sliderBeat;
    string accuracyInput = "";

    bool inStage2;

    float TPCycleSpeed = 2;

    static int ModuleIdCounter = 1;
    int ModuleId;
    private bool ModuleSolved;

    void Awake()
    {
        ModuleId = ModuleIdCounter++;
        Overlay.OnInteract += delegate () { Submit(); return false; };
        Overlay.OnHighlight += delegate () { OverlayRenderer.sprite = OverlaySprites[1]; HighlightPlay(); };
        Overlay.OnHighlightEnded += delegate () { OverlayRenderer.sprite = OverlaySprites[0]; highlightPlay = false; };
        BG.OnInteract += delegate () { CycleBG(); return false; };
        BG.OnHighlight += delegate () { HighlightBG(); };
        BG.OnHighlightEnded += delegate () { highlightBG = false; };
        ShowResults.OnInteract += delegate () { SubmitAccuracy(); return false; };
        for (int i = 0; i < KeypadButtons.Length; i++)
        {
            int j = i;
            KeypadButtons[i].OnInteract += delegate () { KeypadPress(j); return false; };
        }
    }

    void HighlightPlay()
    {
        if (!highlightPlay)
        {
            Audio.PlaySoundAtTransform(HLClip.name, Overlay.transform);
            highlightPlay = true;
        }
    }

    void HighlightBG()
    {
        if (!highlightBG)
        {
            Audio.PlaySoundAtTransform(HLClip.name, Overlay.transform);
            highlightBG = true;
        }
    }

    void CycleBG()
    {
        Audio.PlaySoundAtTransform(HLClip.name, BG.transform);
        BG.AddInteractionPunch();
        selectedChart++;
        selectedChart %= GenChartCount;
        BGRenderer.sprite = BGSprites[selectionCharts[selectedChart]];
    }

    void Submit()
    {
        Overlay.AddInteractionPunch();
        if (selectionCharts[selectedChart] == genChart)
        {
            Log($"Submitted {LogChartName(selectionCharts[selectedChart])}, which is correct. Off to Stage 2...");
            Audio.PlaySoundAtTransform(CorrectClip.name, BG.transform);
            Stage1.SetActive(false);
            Stage2.SetActive(true);
            GenerateS2();
            inStage2 = true;
        }
        else
        {
            Log($"Submitted {LogChartName(selectionCharts[selectedChart])}, which is incorrect. Strike! Regenerating the module...");
            Audio.PlaySoundAtTransform(StrikeClip.name, BG.transform);
            GetComponent<KMBombModule>().HandleStrike();
            GenerateS1();
        }
    }

    public void SliderValChange()
    {
        sliderBeat = (int)BeatSlider.value;
        BeatText.text = sliderBeat.ToString() + ".000";
        for (int n = 0; n < 3; n++)
        {
            string note = chart[sliderBeat][n];
            if (note == null)
            {
                NoteRenderers[n].sprite = null;
                NoteDurations[n].text = "";
            }
            else
            {
                if (note.Contains(" "))
                {
                    int space = note.IndexOf(" ");
                    NoteRenderers[n].sprite = NoteSprites[NoteNames.IndexOf(x => x == note.Substring(0, space))];
                    NoteDurations[n].text = note.Substring(space + 1);
                }
                else
                {
                    NoteRenderers[n].sprite = NoteSprites[NoteNames.IndexOf(x => x == note)];
                    NoteDurations[n].text = "";
                }
            }
        }
        PaddleRenderer.sprite = PaddleModeSprites[paddleModes[sliderBeat]];
    }

    void KeypadPress(int n)
    {
        if (ModuleSolved) return;
        Audio.PlaySoundAtTransform(HLClip.name, BG.transform);
        if (n == 10) accuracyInput += ".";
        else if (n < 10) accuracyInput += n.ToString();
        else
        {
            if (accuracyInput.Length == 0) return;
            else accuracyInput = accuracyInput.Substring(0, accuracyInput.Length - 1);
        }
        if (accuracyInput.Length > 6) accuracyInput = accuracyInput.Substring(0, accuracyInput.Length - 1);
        AccuracyText.text = accuracyInput;
    }

    void SubmitAccuracy()
    {
        if (ModuleSolved) return;
        Overlay.AddInteractionPunch();
        string submission = accuracyInput.Length == 0 ? "an empty string" : (accuracyInput + "%");
        if (accuracyInput == answerAccuracy)
        {
            Log($"Submitted {submission}, which is correct. Module solved! ^^");
            Audio.PlaySoundAtTransform(CorrectClip.name, BG.transform);
            GetComponent<KMBombModule>().HandlePass();
            ModuleSolved = true;
            if (accuracyInput.Length > 0) AccuracyText.text += "%";
        }
        else
        {
            Log($"Submitted {submission}, which is incorrect. Strike!");
            Audio.PlaySoundAtTransform(StrikeClip.name, BG.transform);
            GetComponent<KMBombModule>().HandleStrike();
            accuracyInput = "";
            AccuracyText.text = "";
        }
    }

    void Start()
    {
        Stage2.SetActive(false);
        GenerateS1();
    }

    void GenerateS1()
    {
        int totalCharts = Charts.Length / 3;

        genChart = Rnd.Range(0, totalCharts);
        for (int i = 0; i < 3; i++) ChartInfo[i].text = Charts[genChart, i];
        ChartInfo[0].fontSize = (genChart == 98 || genChart == 127) ? 65 : 80; // icantbelieveiletyougetaway + ...Intervallo VI-EX Boss Theme 2 edge cases (the first is one technically word, so I cannot put a line break anywhere into it, and the other is way too long to fit with the normal font size)
        ChartInfo[1].transform.localPosition = new Vector3(-0.0405f, 0.0151f, -0.0392f + -0.0131f * Charts[genChart, 0].Count(x => x == '\n'));

        selectionCharts = new List<int>();
        selectionCharts.Add(genChart);
        for (int i = 0; i < GenChartCount - 1; i++)
        {
            int addChart = Rnd.Range(0, totalCharts);
            while (selectionCharts.Contains(addChart)) addChart = Rnd.Range(0, totalCharts);
            selectionCharts.Add(addChart);
        }
        selectionCharts = selectionCharts.Shuffle();
        while (selectionCharts[0] == genChart) selectionCharts = selectionCharts.Shuffle();
        BGRenderer.sprite = BGSprites[selectionCharts[0]];
        selectedChart = 0;
        Log($"Answer chart - {LogChartName(genChart)}.");
        Log($"Selectable charts, in order - {selectionCharts.Select(x => LogChartName(x)).Join(", ")}.");
    }

    void GenerateS2()
    {
        beats = Rnd.Range(MinEndBeat, MaxEndBeat + 1);
        BeatSlider.maxValue = beats - 1;
        Log($"Generating the module's {beats}-beat chart:");
        for (int i = 0; i < beats; i++)
        {
            string[] beat = new string[3];
            List<string> logBeat = new List<string>();
            int notes = WeightedNoteCounts.PickRandom();
            for (int j = 0; j < notes; j++)
            {
                int noteType = WeightedNoteTypes.PickRandom();
                if (i == beats - 1)
                {
                    while (noteType == 1 || noteType == 4 || noteType == 5) noteType = WeightedNoteTypes.PickRandom();
                }
                int duration = -1;
                if (noteType == 1 || noteType == 4 || noteType == 5) duration = Rnd.Range(1, Math.Min(6, beats - i));
                beat[j] = NoteNames[noteType] + (duration > 0 ? $" {duration}" : "");
                logBeat.Add(duration > 0 ? $"{NoteNames[noteType]} (duration = {duration})" : NoteNames[noteType]);
            }
            chart.Add(beat);

            int paddle = WeightedPaddleModes.PickRandom();
            paddleModes.Add(paddle);

            Log($"Beat {i}.000: {logBeat.Join(", ")}; Paddle - {PaddleModeNames[paddle]}.");
        }
        CalculateS2();
        SliderValChange();
    }

    void CalculateS2()
    {
        bool[] minePresent = new bool[beats];
        bool[] mineHoldEnd = new bool[beats];
        for (int b = 0; b < beats; b++)
        {
            for (int n = 0; n < 3; n++)
            {
                string note = chart[b][n];
                if (note == null) continue;
                int duration = -1;
                if (note.Contains(" "))
                {
                    int space = note.IndexOf(" ");
                    duration = int.Parse(note.Substring(space + 1));
                    note = note.Substring(0, space);
                }
                switch (note)
                {
                    case "Block":
                        if (paddleModes[b] == 1) misses++;
                        fullCombo++;
                        break;
                    case "Hold":
                        if (paddleModes[b] == 1) misses += 2;
                        else
                        {
                            for (int bi = b; bi < (b + duration + 1); bi++)
                            {
                                if (paddleModes[bi] == 1)
                                {
                                    misses++;
                                    break;
                                }
                            }
                        }
                        fullCombo += 2;
                        break;
                    case "Side":
                        if (paddleModes[b] != 0) misses++;
                        fullCombo++;
                        break;
                    case "Mine":
                        if (paddleModes[b] == 2) misses++;
                        minePresent[b] = true;
                        break;
                    case "Minehold":
                        for (int bi = b; bi < (b + duration + 1); bi++) if (paddleModes[bi] == 2) misses++;
                        mineHoldEnd[b + duration] = true;
                        break;
                    case "Bounce":
                        for (int bi = b; bi < (b + duration + 1); bi++) if (paddleModes[bi] == 1) misses++;
                        fullCombo += duration + 1;
                        break;
                    default:
                        break;
                }
            }
        }
        fullCombo += minePresent.Count(x => x) + mineHoldEnd.Count(x => x);

        float accuracy = (float)Math.Floor((double)(fullCombo - misses) / fullCombo * 10000) / 100;
        if (accuracy >= 0)
        {
            answerAccuracy = accuracy.ToString("F2");
            Log($"After processing all the notes, Full Combo = {fullCombo}, Misses = {misses}, which makes the answer {answerAccuracy}%");
        }
        else
        {
            answerAccuracy = "";
            Log($"After processing all the notes, Full Combo = {fullCombo}, Misses = {misses}, which would've made the answer ~{accuracy.ToString("F2")}%, which is a negative number - submit an empty string instead.");
        }
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
    private readonly string TwitchHelpMessage = @"For Stage 1: Use <!{0} cycle (#)> to cycle the background once (or, optionally, # times). Use <!{0} play> or <!{0} submit> to press the Play button. " + 
                                                 "For Stage 2: Use <!{0} cycle> to cycle through all of the chart's beats. Use <!{0} cyclespeed #> to set the cycle speed to one beat per # seconds (default = 2 seconds). Use <!{0} beat #> to cycle to beat #.000. Use <!{0} submit #> to submit the accuracy #.";
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
                    if (!inStage2)
                    {
                        int cycleCount = 1;
                        if (commandArgs.Length == 2)
                        {
                            if (int.TryParse(commandArgs[1], out cycleCount))
                            {
                                if (cycleCount < 1)
                                {
                                    yield return "sendtochaterror Invalid cycle count!";
                                    yield break;
                                }
                            }
                            else
                            {
                                yield return "sendtochaterror Invalid cycle count!";
                                yield break;
                            }
                        }
                        yield return null;
                        for (int i = 0; i < cycleCount; i++)
                        {
                            BG.OnInteract();
                            yield return new WaitForSeconds(0.1f);
                        }
                        yield return new WaitForSeconds(0.5f);
                    }
                    else
                    {
                        if (commandArgs.Length != 1)
                        {
                            yield return "sendtochaterror Invalid command!";
                            yield break;
                        }
                        else
                        {
                            yield return null;
                            BeatSlider.value = 0;
                            while (BeatSlider.value < beats - 1)
                            {
                                SliderValChange();
                                yield return new WaitForSeconds(TPCycleSpeed);
                                BeatSlider.value++;
                            }
                            yield return new WaitForSeconds(0.5f);
                        }
                    }
                    break;
                case "PLAY":
                    if (inStage2)
                    {
                        yield return "sendtochaterror Command unavailable in Stage 2!";
                        yield break;
                    }
                    else
                    {
                        if (commandArgs.Length != 1)
                        {
                            yield return "sendtochaterror Invalid command!";
                            yield break;
                        }
                        else
                        {
                            yield return null;
                            Overlay.OnInteract();
                            yield return new WaitForSeconds(0.5f);
                        }
                    }
                    break;
                case "CYCLESPEED":
                    if (!inStage2)
                    {
                        yield return "sendtochaterror Command unavailable in Stage 1!";
                        yield break;
                    }
                    else
                    {
                        if (commandArgs.Length != 2)
                        {
                            yield return "sendtochaterror Invalid command!";
                            yield break;
                        }
                        else
                        {
                            float newCycleSpeed;
                            if (float.TryParse(commandArgs[1], out newCycleSpeed))
                            {
                                if (newCycleSpeed <= 0)
                                {
                                    yield return "sendtochaterror Invalid cycle speed!";
                                    yield break;
                                }
                                else if (newCycleSpeed >= 15)
                                {
                                    yield return "sendtochaterror Cycle speed too long!";
                                    yield break;
                                }
                                else
                                {
                                    TPCycleSpeed = newCycleSpeed;
                                    yield return $"sendtochat Setting the cycle speed to {TPCycleSpeed} seconds per beat.";
                                }
                            }
                            else
                            {
                                yield return "sendtochaterror Invalid cycle speed!";
                                yield break;
                            }
                        }
                    }
                    break;
                case "BEAT":
                    if (!inStage2)
                    {
                        yield return "sendtochaterror Command unavailable in Stage 1!";
                        yield break;
                    }
                    else
                    {
                        if (commandArgs.Length != 2)
                        {
                            yield return "sendtochaterror Invalid command!";
                            yield break;
                        }
                        else
                        {
                            int cycleBeat;
                            if (int.TryParse(commandArgs[1], out cycleBeat))
                            {
                                if (cycleBeat < 0 || cycleBeat >= beats)
                                {
                                    yield return "sendtochaterror Invalid beat!";
                                    yield break;
                                }
                                else
                                {
                                    yield return null;
                                    BeatSlider.value = cycleBeat;
                                    SliderValChange();
                                    yield return new WaitForSeconds(0.5f);
                                }
                            }
                            else
                            {
                                yield return "sendtochaterror Invalid beat!";
                                yield break;
                            }
                        }
                    }
                    break;
                case "SUBMIT":
                    if (!inStage2)
                    {
                        if (commandArgs.Length != 1)
                        {
                            yield return "sendtochaterror Invalid command!";
                            yield break;
                        }
                        else
                        {
                            yield return null;
                            Overlay.OnInteract();
                            yield return new WaitForSeconds(0.5f);
                        }
                    }
                    else
                    {
                        if (commandArgs.Length != 2)
                        {
                            yield return "sendtochaterror Invalid command!";
                            yield break;
                        }
                        else
                        {
                            if (Regex.IsMatch(commandArgs[1], @"[^0-9\.<]"))
                            {
                                yield return "sendtochaterror Invalid submission!";
                                yield break;
                            }
                            else
                            {
                                yield return null;
                                foreach (char c in commandArgs[1])
                                {
                                    KeypadButtons["0123456789.<".IndexOf(c)].OnInteract();
                                    yield return new WaitForSeconds(0.05f);
                                }
                                ShowResults.OnInteract();
                            }
                        }
                    }
                    break;
                default:
                    yield return "sendtochaterror Invalid command!";
                    yield break;
            }
        }
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        yield return null;
        if (!inStage2)
        {
            while (selectionCharts[selectedChart] != genChart)
            {
                BG.OnInteract();
                yield return new WaitForSeconds(0.1f);
            }
            Overlay.OnInteract();
        }
        foreach (char c in answerAccuracy)
        {
            KeypadButtons["0123456789.<".IndexOf(c)].OnInteract();
            yield return new WaitForSeconds(0.05f);
        }
        ShowResults.OnInteract();
    }
}
