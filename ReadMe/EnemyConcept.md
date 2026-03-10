# Enemy Concept

## Ghostling

![Ghostling](/ReadMe/gfx/Ghost.png)

> hij beweegt in hetzelfde rasterpatroon als de speler met een vergelijkbare snelheid
>
> volgt de speler in het maze en probeert de hitbox van de speler aan te raken
>
> als de trigger van de Ghostling de hitbox collider van de speler raakt, sterft de speler

```mermaid
flowchart TD
    B[Enemy Behaviour] --> C[Flies through the maze]
    C --> D{Sees the player}
    D -- Yes --> E[Follows the traces/points the player left behind]
    D -- No --> C
    E --> F{Lost the player?}
    F -- Yes --> G[Starts flying around the maze again through the maze]
    F -- No --> E
    E --> H{Collision contact with player?}
    H -- Yes --> I[Player dies and restarts with one life less]