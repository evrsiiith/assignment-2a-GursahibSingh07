using UnityEngine;
using System.Collections.Generic;
using VReqDV;

namespace Version_7
{
    public class RiddleUI : MonoBehaviour
    {
        public static RiddleUI Instance;
        public string riddleText = "";
        public bool showRiddle = true;
        public string feedbackText = "";
        public float feedbackTimer = 0f;
        public bool okClicked = false;

        void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            if (feedbackTimer > 0)
            {
                feedbackTimer -= Time.deltaTime;
                if (feedbackTimer <= 0)
                    feedbackText = "";
            }
        }

        void OnGUI()
        {
            if (showRiddle && !string.IsNullOrEmpty(riddleText))
            {
                float w = Screen.width * 0.6f;
                float h = Screen.height * 0.4f;
                float x = (Screen.width - w) / 2f;
                float y = (Screen.height - h) / 2f;

                GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
                boxStyle.fontSize = 24;
                boxStyle.alignment = TextAnchor.MiddleCenter;
                boxStyle.wordWrap = true;
                boxStyle.normal.textColor = Color.white;

                GUI.Box(new Rect(x, y, w, h), riddleText, boxStyle);

                float btnW = 120f;
                float btnH = 40f;
                GUIStyle btnStyle = new GUIStyle(GUI.skin.button);
                btnStyle.fontSize = 20;
                if (GUI.Button(new Rect(x + (w - btnW) / 2f, y + h + 10, btnW, btnH), "OK", btnStyle))
                {
                    okClicked = true;
                }
            }

            if (!string.IsNullOrEmpty(feedbackText))
            {
                GUIStyle feedbackStyle = new GUIStyle(GUI.skin.label);
                feedbackStyle.fontSize = 28;
                feedbackStyle.alignment = TextAnchor.UpperCenter;
                feedbackStyle.normal.textColor = Color.white;
                GUI.Label(new Rect(0, 20, Screen.width, 50), feedbackText, feedbackStyle);
            }
        }
    }

    public static class UserAlgorithms
    {
        private static readonly string[][] riddles = new string[][]
        {
            new string[] { "First the color of roses,\nthen the sky,\nthen the forest.", "Red", "Blue", "Green" },
            new string[] { "Start with nature,\nfollow with passion,\nend with ocean.", "Green", "Red", "Blue" },
            new string[] { "Sky first,\nthen grass,\nthen a ruby.", "Blue", "Green", "Red" },
            new string[] { "Grass, ocean, roses.\nIn that order.", "Green", "Blue", "Red" },
            new string[] { "Rose, forest, sky.\nPress in order.", "Red", "Green", "Blue" },
        };

        private static int currentRiddleIndex = -1;
        private static List<string> userSequence = new List<string>();
        private static Dictionary<string, float> cooldownTimers = new Dictionary<string, float>();
        private static Dictionary<string, Color> originalColors = new Dictionary<string, Color>();
        private static bool initialized = false;

        private static void Initialize()
        {
            if (initialized) return;
            initialized = true;

            SetObjectColor("RedButton", Color.red);
            SetObjectColor("GreenButton", Color.green);
            SetObjectColor("BlueButton", Color.blue);
            SetObjectColor("RedPillar", new Color(0.6f, 0.6f, 0.6f));
            SetObjectColor("GreenPillar", new Color(0.6f, 0.6f, 0.6f));
            SetObjectColor("BluePillar", new Color(0.6f, 0.6f, 0.6f));
            SetObjectColor("TreasureChest", new Color(0.55f, 0.27f, 0.07f));
            SetObjectColor("RiddleBoard", Color.white);
            SetObjectColor("OKButton", new Color(0.4f, 0.8f, 0.4f));
            SetObjectColor("ResetButton", new Color(1f, 0.6f, 0.2f));

            originalColors["RedButton"] = Color.red;
            originalColors["GreenButton"] = Color.green;
            originalColors["BlueButton"] = Color.blue;

            GameObject riddleBoard = GameObject.Find("RiddleBoard");
            if (riddleBoard != null && RiddleUI.Instance == null)
            {
                riddleBoard.AddComponent<RiddleUI>();
            }

            PickRandomRiddle();
        }

        private static void SetObjectColor(string name, Color color)
        {
            GameObject obj = GameObject.Find(name);
            if (obj != null)
            {
                var renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.material.color = color;
            }
        }

        private static void PickRandomRiddle()
        {
            int newIndex;
            if (riddles.Length > 1)
            {
                do
                {
                    newIndex = Random.Range(0, riddles.Length);
                } while (newIndex == currentRiddleIndex);
            }
            else
            {
                newIndex = 0;
            }
            currentRiddleIndex = newIndex;

            if (RiddleUI.Instance != null)
            {
                RiddleUI.Instance.riddleText = riddles[currentRiddleIndex][0];
                RiddleUI.Instance.showRiddle = true;
            }
        }

        private static string GetButtonColor(string objectName)
        {
            if (objectName.Contains("Red")) return "Red";
            if (objectName.Contains("Green")) return "Green";
            if (objectName.Contains("Blue")) return "Blue";
            return "";
        }

        private static string[] GetCorrectSequence()
        {
            if (currentRiddleIndex < 0 || currentRiddleIndex >= riddles.Length)
                return new string[0];
            string[] riddle = riddles[currentRiddleIndex];
            string[] seq = new string[riddle.Length - 1];
            for (int i = 1; i < riddle.Length; i++)
                seq[i - 1] = riddle[i];
            return seq;
        }

        // ===================== Behavior Methods =====================

        public static bool IsOKClicked()
        {
            Initialize();
            if (RiddleUI.Instance != null && RiddleUI.Instance.okClicked)
            {
                RiddleUI.Instance.okClicked = false;
                return true;
            }
            return false;
        }

        public static void DismissRiddle()
        {
            Initialize();
            Debug.Log("[RiddleGame] Riddle dismissed. Start pressing buttons!");

            if (RiddleUI.Instance != null)
                RiddleUI.Instance.showRiddle = false;

            GameObject riddleBoard = GameObject.Find("RiddleBoard");
            if (riddleBoard != null)
            {
                var renderer = riddleBoard.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.enabled = false;
                StateAccessor.SetState("RiddleBoard", "Hidden", riddleBoard);
            }

            GameObject okBtn = GameObject.Find("OKButton");
            if (okBtn != null)
            {
                var renderer = okBtn.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.enabled = false;
                var collider = okBtn.GetComponent<Collider>();
                if (collider != null)
                    collider.enabled = false;
            }

            userSequence.Clear();
        }

        public static bool IsButtonClicked(GameObject obj)
        {
            Initialize();
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject == obj)
                        return true;
                }
            }
            return false;
        }

        public static void PressButton(GameObject obj)
        {
            Initialize();
            string color = GetButtonColor(obj.name);
            Debug.Log($"[RiddleGame] Button pressed: {obj.name} ({color})");

            userSequence.Add(color);

            var renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = originalColors.ContainsKey(obj.name)
                    ? originalColors[obj.name] * 0.3f
                    : Color.gray;
            }

            cooldownTimers[obj.name] = Time.time + 1.0f;

            StateAccessor.SetState(obj.name, "Pressed", obj);

            Debug.Log($"[RiddleGame] Sequence so far: {string.Join(", ", userSequence)}");
        }

        public static bool IsCooldownDone(GameObject obj)
        {
            Initialize();
            if (cooldownTimers.ContainsKey(obj.name))
                return Time.time >= cooldownTimers[obj.name];
            return true;
        }

        public static void ResetButtonVisual(GameObject obj)
        {
            Initialize();
            if (originalColors.ContainsKey(obj.name))
            {
                var renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.material.color = originalColors[obj.name];
            }
            StateAccessor.SetState(obj.name, "Idle", obj);
        }

        public static bool IsSequenceCorrect()
        {
            Initialize();
            string[] correct = GetCorrectSequence();
            if (correct.Length == 0) return false;
            if (userSequence.Count < correct.Length) return false;

            for (int i = 0; i < correct.Length; i++)
            {
                if (userSequence[i] != correct[i])
                    return false;
            }
            return true;
        }

        public static bool IsSequenceWrong()
        {
            Initialize();
            string[] correct = GetCorrectSequence();
            if (correct.Length == 0) return false;
            if (userSequence.Count < correct.Length) return false;

            for (int i = 0; i < correct.Length; i++)
            {
                if (userSequence[i] != correct[i])
                    return true;
            }
            return false;
        }

        public static void OpenChest()
        {
            Initialize();
            Debug.Log("[RiddleGame] Correct sequence! Treasure chest opened!");

            GameObject chest = GameObject.Find("TreasureChest");
            if (chest != null)
            {
                var renderer = chest.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.material.color = new Color(1f, 0.84f, 0f);
                chest.transform.localScale = new Vector3(1.8f, 0.5f, 1.2f);
                StateAccessor.SetState("TreasureChest", "Open", chest);
            }

            if (RiddleUI.Instance != null)
            {
                RiddleUI.Instance.feedbackText = "Correct! Treasure unlocked!";
                RiddleUI.Instance.feedbackTimer = 3f;
            }
        }

        public static void HandleWrongSequence()
        {
            Initialize();
            Debug.Log("[RiddleGame] Wrong sequence! Try again.");

            userSequence.Clear();

            if (RiddleUI.Instance != null)
            {
                RiddleUI.Instance.feedbackText = "Wrong sequence! Try again.";
                RiddleUI.Instance.feedbackTimer = 2f;
            }
        }

        public static bool IsResetClicked()
        {
            Initialize();
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    GameObject resetBtn = GameObject.Find("ResetButton");
                    if (resetBtn != null && hit.collider.gameObject == resetBtn)
                        return true;
                }
            }
            return false;
        }

        public static void ResetAll()
        {
            Initialize();
            Debug.Log("[RiddleGame] Resetting game...");

            userSequence.Clear();
            cooldownTimers.Clear();

            GameObject chest = GameObject.Find("TreasureChest");
            if (chest != null)
            {
                var renderer = chest.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.material.color = new Color(0.55f, 0.27f, 0.07f);
                chest.transform.localScale = new Vector3(1.5f, 1f, 1f);
                StateAccessor.SetState("TreasureChest", "Locked", chest);
            }

            string[] buttonNames = { "RedButton", "GreenButton", "BlueButton" };
            foreach (var name in buttonNames)
            {
                GameObject btn = GameObject.Find(name);
                if (btn != null)
                {
                    if (originalColors.ContainsKey(name))
                    {
                        var renderer = btn.GetComponent<Renderer>();
                        if (renderer != null)
                            renderer.material.color = originalColors[name];
                    }
                    StateAccessor.SetState(name, "Idle", btn);
                }
            }

            GameObject riddleBoard = GameObject.Find("RiddleBoard");
            if (riddleBoard != null)
            {
                var renderer = riddleBoard.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.enabled = true;
                StateAccessor.SetState("RiddleBoard", "Showing", riddleBoard);
            }

            GameObject okBtn = GameObject.Find("OKButton");
            if (okBtn != null)
            {
                var renderer = okBtn.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.enabled = true;
                var collider = okBtn.GetComponent<Collider>();
                if (collider != null)
                    collider.enabled = true;
            }

            PickRandomRiddle();
        }
    }
}