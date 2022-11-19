using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// /// <summary>
// /// This is obviously an example and I have no idea what kind of game you're making.
// /// You can use a similar manager for controlling your menu states or dynamic-cinematics, etc
// /// </summary>
// [Serializable]
// public enum GameState {
//     Starting = 0,
//     Playing = 1,
//     GameOver = 2,
// }

/// <summary>
/// Nice, easy to understand enum-based game manager. For larger and more complex games, look into
/// state machines. But this will serve just fine for most games.
/// </summary>
public class GameManager : MonoBehaviour {
    private int _score = 0;
    private int _life = 3;

    public GameObject scoreLabel;
    public GameObject lifesLabel;
    
    // public static event Action<GameState> OnBeforeStateChanged;
    // public static event Action<GameState> OnAfterStateChanged;
    
    private void Awake() {
        AnimalCollisions.OnAnimalFed += RaiseScore;
        AnimalCollisions.OnAnimalHurt += LooseLife;
        // ChangeState(GameState.Starting);
    }

    private void OnDestroy()
    {
        AnimalCollisions.OnAnimalFed -= RaiseScore;
        AnimalCollisions.OnAnimalHurt -= LooseLife;
    }
    //
    // public GameState State { get; private set; }
    //
    // // Kick the game off with the first state
    // private void Start() {
    //     
    // }
    //
    // public void ChangeState(GameState newState) {
    //     OnBeforeStateChanged?.Invoke(newState);
    //
    //     State = newState;
    //     switch (newState) {
    //         case GameState.Starting:
    //             HandleStarting();
    //             break;
    //         case GameState.Playing:
    //             HandlePlaying();
    //             break;
    //         case GameState.GameOver:
    //             HandleGameOver();
    //             break;
    //         default:
    //             throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    //     }
    //
    //     OnAfterStateChanged?.Invoke(newState);
    //     
    //     Debug.Log($"New state: {newState}");
    // }
    //
    // private void HandleStarting() {
    //     ChangeState(GameState.Starting);
    // }
    // private void HandlePlaying() {
    //     ChangeState(GameState.Playing);
    // }
    //
    // private void HandleGameOver() {
    //     ChangeState(GameState.GameOver);
    // }

    private void RaiseScore()
    {
        _score += 1;
        TextMeshProUGUI textUI = scoreLabel.GetComponent<TextMeshProUGUI>();
        textUI.text = $"Nombre de nourris {_score}";
    }
    private void LooseLife()
    {
        _life -= 1;
        TextMeshProUGUI textUI = lifesLabel.GetComponent<TextMeshProUGUI>();
        textUI.text = $"Vies : {_life}";

        if (_life == 0)
        {
            Debug.Log("Game OVER");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
