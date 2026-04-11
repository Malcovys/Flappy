# 🐦 Flappy Bird 2D

A Flappy Bird clone built with **Unity** for Android. Tap to flap through an endless stream of pipes, beat your high score, and earn stars along the way!

## 📱 Download

A pre-built Android APK is available in the [`Builds/`](Builds/Flappy_V1.0.apk) folder:

```
Builds/Flappy_V1.0.apk
```

## 🎮 Gameplay

- **Tap / click** to make the bird flap upward.
- Avoid the pipes — hitting one or flying off-screen ends the run.
- Each pipe you clear earns **1 point**.
- Your best score is saved automatically between sessions.

### ⭐ Star Rewards

| Star   | Required High Score |
|--------|-------------------|
| 🥉 Bronze | 10 |
| 🥈 Silver | 20 |
| 🥇 Gold   | 50 |

## 🏗️ Project Structure

```
Assets/
├── Medias/          # Sprites, audio, fonts, animations, UI
├── Prefab/          # Reusable Unity prefabs
├── Scenes/
│   ├── MainScene    # Home / main menu
│   └── PlayScene    # Gameplay
└── Scripts/
    ├── GamePlay/    # Core game logic
    │   ├── GameManager.cs       # Game state machine & pipe spawning
    │   ├── PlayerController.cs  # Flap physics & death detection
    │   ├── Pipe.cs              # Pipe movement & recycling
    │   ├── PipeTeleport.cs      # Pipe position reset
    │   └── UIController.cs      # In-game HUD
    ├── Home/        # Main menu
    │   ├── HomeManager.cs
    │   └── HomeUIController.cs
    └── Tools/       # Shared utilities
        ├── AudioManager.cs
        ├── CameraController.cs  # Screen-shake on death
        ├── ScoreManager.cs      # Score & high-score (PlayerPrefs)
        ├── StarManager.cs       # Bronze / Silver / Gold star logic
        ├── ScrollingBackground.cs
        └── TransitionManager.cs
```

## 🛠️ Built With

- [Unity](https://unity.com/) — game engine
- [DOTween](http://dotween.demigiant.com/) — animations & tweening

## 🚀 Getting Started

1. Clone the repository.
2. Open the project in **Unity** (the project targets Android; make sure the Android Build Support module is installed).
3. Open `Assets/Scenes/MainScene.unity` and press **Play** to run in the editor.
4. To build the APK: **File → Build Settings → Android → Build**.
