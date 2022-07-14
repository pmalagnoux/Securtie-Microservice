# Securtie-Microservice

Le projet contient une API simple de blocnote et un clientMVC permettant de récupérer les données.  
  
Ce projet consiste a sécuriser l'accès au microservice et de sécuriser la communication entre l'API et le client. Le service d'authentification est réalisé avec IdentifyServer4 qui utilise OAuth 2 et OpenID et l'API Gateway est réalisé avec Ocelot. Cette implémentation de sécurité va permettre d'instaurer la communication avec Jeton de sécurité et aussi l'ajout d'une passerelle de sécurité intermédiaire (API Gateway) pour limiter l'accès.


# Installation

Une fois que l'environnement est lancé avec le .sln, il faut vérifier quelques points avant de pourvoir lancer l'application.  
  
  1.  Il faut vérifier que pour tous les projets dans la partie débug en haut, que le nom du projet correspondent au nom du launcher de l'application. Il se peut que de base il soit sur IIS Express et il faut le changer avec le bon nom du projet.  

  2.  Il faut ensuite modifier les paramètres de la solution afin de créer le lancement de tous les projets en même temps. Pour se faire il faut faire clic droit sur la solution et ouvir les propriétés. Il faut ensuite selcetionner, dans l'onglet Propriétés Communes -> Propriété de démarrage, Plusieurs projet de démarage et selectionner pour les 4 projets : Démarrer.  

  3. Ensuite on peut lancer l'application et 4 consoles s'ouvrent avec le client.

  Au cas ou cela ne se lance pas automatiquement on peut y accéder à l'adresse suivante :
   https://localhost:5002/  

  Pour l'authentification, nous avons laissé les identifiants de base soit :
   
    nom d'utilisateur - mot de passe 1 : alice - a1
    nom d'utilisateur - mot de passe 2 : bob - b1  


