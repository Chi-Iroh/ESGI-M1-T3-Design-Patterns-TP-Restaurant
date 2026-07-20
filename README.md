# TP Restaurant

## 2. Calcul flexible du prix total (pattern Strategy)

![doc/Strategy pattern.png](doc/Strategy%20pattern.png)

La classe `Order` calcule son prix grâce à un double pattern Strategy.  
Elle calcule le prix de base avec des méthodes de tarification (somme des produits ou formule à prix fixe), puis applique les réductions (happy hour, tarif de groupe).  
Les méthodes de tarification et de réductions sont séparées en deux interfaces distinctes pour clarifier, puisque leur objectif est différent.  

## 3. Workflow de traitement de commandes (pattern State)

![doc/State pattern.png](doc/State%20pattern.png)

La classe `Order` contient un attribut `state` de type `IOrderSpace`, initialisé à la classe concrète `Created` pour représenter l'état initial.  

À chaque mouvement d'état (route `/api/orders/{id}/state`), on appelle la méthode `.Next()` de cet état pour récupérer l'instance du prochain état.  

## 4. Notifications inter-services

![doc/Observer pattern.png](doc/Observer%20pattern.png)

La classe `Order` contient une liste d'observateurs à appeler à chaque changement d'état sur la commande.  
Chaque classe observatrice implémente l'interface qui définit une unique méthode à appeler pour la notifier de la modification. C'est à chaque observateur de vérifier s'il doit se déclencher.  
