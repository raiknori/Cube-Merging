
# 2048 3D Prototype

## Objective

A basic 3D physical prototype of the popular 2048 game, designed for Mobile/Pc platforms.

## Platform

* Android/IOS
* PC

## Gameplay

* **Location:** Long rectangular board bounded by walls.
* **Cube spawning:** At the start, a cube spawns at the center with a Power-of-2 (Po2) value:

  * 75% chance: 2
  * 25% chance: 4
* **Controls:**

  * Touch and hold to prepare the cube.
  * Drag left/right to move cube horizontally.
  * Release to launch cube forward.
* **Merging:** Cubes merge if:

  * They collide with enough impulse.
  * They have the same Po2 value.
  * Resulting cube has a value equal to the sum of merged cubes.
* **Scoring:** Each merge gives a score equal to `Po2 / 2`.

  * Example: merging 2+2 → 1 point, 4+4 → 2 points, 8+8 → 4 points, etc.
* **Game over:** Defined by the inability to spawn or move cubes.

## Architecture

* Focus on **Dependency Injection (DI)** using **Zenject**.
* Designed with a **scalable architecture** for future updates.
* Clean separation of input, cube logic, and game rules for maintainability.

## Notes

* Prototype emphasizes modularity and future expandability.

