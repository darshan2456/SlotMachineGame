Absolutely. Since this is a **small Unity project you actually built yourself**, I'd make the README look like a proper GitHub project rather than a generic college-assignment README.

# 🎰 SlotMachineGame

> A simple pixel-art slot machine built in **Unity and C#**, featuring randomized reels, animated lever mechanics, deterministic reel stopping based on randomly generated targets, and win/loss detection.

## 🎮 Overview

**SlotMachineGame** is a small 2D slot-machine game developed in Unity as a hands-on project for learning game development, Unity's component-based architecture, C# scripting, coroutines, and game-state orchestration.

The machine consists of three independently controlled reels. When the player starts a game, each reel receives a randomly generated symbol and spins until that target symbol reaches the designated stopping position.

The project deliberately keeps the architecture modular: **random number generation, reel behavior, lever animation, UI interaction, and game orchestration are handled by separate components.**

---

## 🧠 How It Works

The core game flow is:

```text
        Player presses PLAY
                │
                ▼
        GameController
                │
                ▼
        Wait before spin
                │
                ▼
          Pull the lever
                │
                ▼
        Generate 3 symbols
                │
       ┌────────┼────────┐
       ▼        ▼        ▼
     Reel 1   Reel 2   Reel 3
       │        │        │
       ▼        ▼        ▼
     Spin     Spin     Spin
       │        │        │
       └────────┼────────┘
                ▼
       Wait until all stop
                │
                ▼
           Check result
           /          \
          ▼            ▼
       WIN 🎉        LOSS
```

The important part is that **randomness determines the result before the reels visually spin**.

For example:

```text
RandomGenerator
      │
      ├── Reel 1 → Cherry
      ├── Reel 2 → Cherry
      └── Reel 3 → Cherry
                     │
                     ▼
                  JACKPOT!
```

The reels then visually animate toward those generated targets.

---

## 🏗️ Architecture

The project is split into several focused controllers:

| Component         | Responsibility                                 |
| ----------------- | ---------------------------------------------- |
| `GameController`  | Orchestrates the entire game sequence          |
| `ReelController`  | Controls individual reel movement and stopping |
| `RandomGenerator` | Generates random symbol IDs                    |
| `LeverController` | Handles lever animation/state                  |
| `PopupController` | Controls the game popup and starts the game    |
| `PlayButton`      | Handles the Play button                        |
| `RetryButton`     | Restarts the game                              |
| `ExitButton`      | Handles exiting the game                       |

### GameController

The `GameController` acts as the **orchestrator**.

It doesn't directly manipulate the internals of a reel. Instead, it tells each component what to do:

```csharp
results[i] = randomGenerator.GenerateSymbol();

reels[i].startSpin(results[i]);
```

After starting all reels, it waits:

```csharp
yield return new WaitUntil(AllReelsStopped);
```

and only then evaluates the result:

```csharp
CheckWin();
```

This keeps the game logic centralized while allowing each component to remain relatively independent

---


## 🏆 Winning Logic

After all three reels have stopped, their generated results are compared.

A jackpot occurs when:

```text
Reel 1 == Reel 2 == Reel 3
```

For example:

```text
🍒 | 🍒 | 🍒   → WIN 🎉
```

while:

```text
🍒 | 🔔 | 7️⃣   → LOSS
```

---

## 🛠️ Built With

* **Unity 6.6**
* **C#**
* Unity Coroutines
* Unity GameObjects & Components
* 2D Sprite Rendering
* Git / GitHub

---

## 🚀 Running the Project

1. Clone the repository:

```bash
git clone <repository-url>
```

2. Open the project using **Unity Hub**.

3. Open the main scene:

```text
Assets/Scenes/SampleScene
```

4. Press **Play** ▶️.

5. Hit **Play** on the slot machine and pull the lever.

6. Pray to the RNG gods. 🎰

---

## 📚 What I Learned

This project was primarily built to understand practical Unity development and C# architecture.

Key concepts explored:

* Unity's **GameObject + Component** model
* C# object references through Unity's Inspector
* `MonoBehaviour`
* `Update()`
* Coroutines and `IEnumerator`
* `WaitForSeconds`
* `WaitUntil`
* Sprite manipulation
* Transform movement
* Component-to-component communication
* Random number generation
* Basic game-state management
* Separation of responsibilities between controllers

---


## 👨‍💻 Author

**Darshan**

Built as a hands-on Unity/C# project while learning game development and object-oriented software architecture.

---

## ⭐ Final Note

This project started as a simple **"make a slot machine"** exercise and evolved into a nice little example of separating **game orchestration from individual component behavior**.

Small project, but a surprisingly good sandbox for learning how game systems actually fit together.
