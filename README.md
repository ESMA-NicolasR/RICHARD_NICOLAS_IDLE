# END WORLD HUNGER
Idle Game for school project

## Le jeu
Le but de ce jeu est de vaincre la faim dans le monde. Le joueur peut cliquer sur un bouton pour ramasser des graines.
Ces graines lui permettent de remplir des missions, de débloquer des améliorations ou bien de planter des aliments.
En cliquant sur les aliments à maturité, le joueur gagne des ressources correspondantes : cérales, fruits ou légumes.
Le joueur pourra ainsi remplir des missions de plus en plus importantes pour nourrir la population mondiale, tout en
investissant ses ressources dans des améliorations telles qu'un gain de graines automatisé, des récoltes plus importantes,
un temps de pousse accéléré, la récolte automatique, etc. Au fur et à mesure de sa progression, l'interaction de joueur avec les différents
systèmes pourra changer et il pourra adapter son style de jeu ainsi que se fixer des objectifs personnels (débloquer tous les champs automatiques par exemple).

Il n'y a pas de fin programmée au jeu, toutefois on peut considérer avoir vu toutes les mécaniques une fois que toutes les
améliorations ont été achetées une fois. Si le joueur arrive à nourrir la population mondiale, il pourra se considérer comme un
paragon de patience et de persévérence.

Une sauvegarde des données du jeu est proposée grâce au menu en haut à gauche de l'écran mais ne conserve que les ressources
possédées à l'instant T, les améliorations débloquées ne sont pas sauvegardées.

## Le projet
La structure de ce jeu permet à un développeur d'étendre ou de modifier facilement son contenu : nouvelles améliorations,
équilibrage des valeurs, nouveaux aliments, nouveau types de ressources, nouvelles missions, etc.
Le plus dur sera sans doute de trouver de la place sur l'écran pour ajouter des mécaniques !

La plupart des éléments de jeu sont modifiables en l'état dans le dossier Assets/Data. Pour en ajouter, il suffit dans l'éditeur Unity
de faire clic droit -> create -> data puis de choisir si on veut créer une nouvelle Task, Food, etc.

Les Food permettent de déclarer un aliment, qui possède notamment des valeur de coût, de type de ressource, de récolte et de temps de pousse.

Les Task permettent de déclarer deux types de mission. Les missions principales, qui ont un objectif fixé et permettent de débloquer une amélioration,
ainsi que les missions secondaires, qui sont générées aléatoirement à partir de valeurs fournies (quels types de ressource, en quelle quantité, quelle récompense).

Les Upgrade permettent de faire le lien entre des évènements dans le jeu (achat dans la boutique, complétion de mission) et des méthodes qui ont été codées.
Elles se déclinent en deux type : les coûts manuels, avec une indication précise du coût pour chaque rang d'amélioration, et les coûts automatiques,
avec des paramètres permettant de laisser le jeu calculer le coût de chaque rang. Chaque amélioration peut également avoir un rang maximal limité ou bien illimité.

Pour ajouter des types de ressources ou des nouvelles upgrades, il est possible de modifier le fichier Assets/Scripts/Helpers/MyEnums.
Attention cependant à bien ajouter les nouvelles valeurs en fin d'énumération afin de ne pas décaler les valeurs existantes.

Le système de sauvegarde permet à n'importe quel GameObject de souscrire à deux évènements : SaveSystem.OnSave et SaveSystem.OnLoad.
Ceux-ci fournissent un objet de type SaveData, dans lequel on peut écrire ou lire des données intéressantes à sauvegarder et charger.
