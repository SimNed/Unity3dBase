# Unity3dBase
Base de travail pour le développement de jeux Unity 3d

Ce code comprend :

- Un système de contrôle
- Un système de dialogue
- Un système d'intéractions
- Un système de changement de scène

Le programme est séparé en deux types de scènes, la scène de management et les scènes actives. Les scènes actives contiennent les différents éléments du jeu (le joueur actuel, les personnages, les intéractions, les objets 3d). Elles envoient les informations qu'elles contiennent à la scène de management qui est cargée de gérer l'ensemble des actions du jeu (contrôles du jeu, changement de scène, lancement des intéractions etc). 
