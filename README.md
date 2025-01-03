# Top-Down HDRP Unity Action Game

## Overview

This project is a top-down action game developed in **Unity (version 2022 or newer)**, leveraging the **High Definition Render Pipeline (HDRP)** for visually polished graphics. The core gameplay features a unique **rope-based mechanic** where the player captures and redirects projectiles launched by a dynamic cannon. The game's difficulty progressively increases, challenging the player to adapt their strategies.

## Gameplay Mechanics

*   **Rope-Based Projectile Control:** The player uses a mouse-controlled rope to attach to incoming cannonballs. Once attached, the player can swing the cannonball around a fixed anchor point and release it to redirect its trajectory.
*   **Dynamic Cannon System:** A cannon fires projectiles at the player with increasing frequency, creating a challenging and engaging experience.
*   **Momentum-Based Physics:**  Released cannonballs retain momentum, allowing for strategic aiming and destruction of targets.

## Technical Highlights

*   **Unity Engine (HDRP):** The game utilizes Unity's HDRP to achieve high-fidelity graphics, including:
    *   **Realistic Water Simulation:** Implemented to enhance the visual appeal of the game environment.
    *   **Custom Particle System:** Designed for visually striking projectile trails.
    *   **Dynamic Point Lights:** Uses a custom script to generate multiple point lights around the player, this script allows for easy editing of light properties such as color, intensity, and distribution radius all from the Unity editor.

*   **C# Scripting:** The game's logic is implemented using C# and leverages Unity's component-based architecture. Key scripts include:
    *   `CannonSpawner`: Controls the spawning and initial velocity of cannonballs.
    *   `ObjectMomentum`: Manages the kinematic state and velocity of cannonballs.
    *   `RopeController`: Handles the player's interaction with cannonballs, including attachment, rotation, and release.
    *   `RopeRenderer`: Renders the rope visually using a `LineRenderer` component.
    *   `Lights`: Generates multiple point lights around the player, this script allows for easy editing of light properties such as color, intensity, and distribution radius all from the Unity editor.

*   **.NET Framework:** Used in conjunction with C# for core game logic.

## Code Structure

The project follows a modular design, making the codebase easy to understand and maintain. Key scripts are well-commented and adhere to Unity's scripting conventions.

### Scripts

*   **`CannonSpawner.cs`:**
    *   Spawns cannonballs at regular intervals.
    *   Sets the initial velocity of the cannonballs.

*   **`ObjectMomentum.cs`:**
    *   Allows cannonballs to maintain momentum after being released.
    *   Provides a method to toggle the kinematic state of the attached `Rigidbody`.

*   **`RopeController.cs`:**
    *   Detects mouse clicks and finds the nearest cannonball within a specified range.
    *   Calculates the angular velocity and rotation of the attached cannonball around the anchor point.
    *   Releases the cannonball, applying the calculated momentum.
    *   Manages the `isAttached` state and interacts with the `ObjectMomentum` script.

*   **`RopeRenderer.cs`:**
    *   Uses a `LineRenderer` to visually represent the rope.
    *   Updates the `LineRenderer`'s positions based on the `RopeController`'s state.

*   **`Lights.cs`:**
    *   Uses a loop to generate the desired number of lights in a circle around the object.
    *   Calculates the angle and position for each light based on the desired light count and radius.
    *   Sets the intensity of each light, ensuring a smooth falloff from the center.

## Setup Instructions

1. **Clone the Repository:**
    ```bash
    git clone [Your Repository URL]
    ```
2. **Open in Unity:** Open the project in Unity (version 2022 or newer).
3. **Ensure HDRP is Configured:** Make sure the project is set up to use the High Definition Render Pipeline.
4. **Play:** Press the Play button in the Unity Editor to start the game.

## Controls

*   **Left Mouse Button:** Click and hold to attach the rope to a cannonball.
*   **Mouse Movement:** Swing the attached cannonball around the anchor point.
*   **Release Left Mouse Button:** Release the cannonball.

## Future Development

*   **Target System:** Introduce targets that the player can destroy by redirecting cannonballs.
*   **Power-Ups:** Implement power-ups that enhance the player's abilities or modify the rope's behavior.
*   **Enhanced Visuals:** Further refine the game's visuals using HDRP features, such as advanced lighting and post-processing effects.
*   **Sound Design:** Add sound effects and music to enhance the gameplay experience.

**Please feel free to explore the code and experiment with the game. For any questions or feedback, please contact Christopher Monteleone at christophergmonteleone@gmail.com.**
