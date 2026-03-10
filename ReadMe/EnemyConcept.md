# Enemy Concept

## Ghostling

![Ghostling](/ReadMe/gfx/Ghost.png)

>hij beweegt in hetzelfde rasterpatroon als de speler met een vergelijkbare snelheid
>
>volgt de speler in het maze en probeert de hitbox van de speler aan te raken
>
>als de trigger van de Ghostling de hitbox collider van de speler raakt, sterft de speler

flowchart TD
    B(Enemy Behaviour)
    B --> C{Flies trough the maze}
    C -->|Sees the player| D[Follows the traces/points the player left behind]
    C -->|Lost the player at the last trace| E[Starts Flying rounds again trough the maze]
    C -->|If collision contact with player| F[Player dies and restarts with one life less]


