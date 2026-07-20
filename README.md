# TP Restaurant

## 3. Workflow de traitement de commandes

![doc/State pattern.png](doc/State%20pattern.png)

La classe `Order` contient un attribut `state` de type `IOrderSpace`, initialisé à la classe concrète `Created` pour représenter l'état initial.  

À chaque mouvement d'état (route `/api/orders/{id}/state`), on appelle la méthode `.Next()` de cet état pour récupérer l'instance du prochain état.  
