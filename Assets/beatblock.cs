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

    [SerializeField] KMSelectable MenuRight;
    [SerializeField] SpriteRenderer MenuRightSprite;
    [SerializeField] Sprite[] MenuRights;
    [SerializeField] KMSelectable Background;
    [SerializeField] SpriteRenderer BackgroundSprite;
    [SerializeField] Sprite[] Backgrounds;

    static int ModuleIdCounter = 1;
    int ModuleId;
    private bool ModuleSolved;

    void Awake()
    {
        ModuleId = ModuleIdCounter++;
        //button.OnInteract += delegate () { buttonPress(); return false; };
        MenuRight.OnHighlight += delegate () { MenuRightSprite.sprite = MenuRights[1]; };
        MenuRight.OnHighlightEnded += delegate () { MenuRightSprite.sprite = MenuRights[0]; };
    }

    void Start()
    {

    }

    void Log(string arg)
    {
        Debug.Log($"[Beatblock #{ModuleId}] {arg}");
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use <!{0}> to do something.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string Command)
    {
		var commandArgs = Command.ToUpperInvariant().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        yield return null;
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        yield return null;
    }
}
