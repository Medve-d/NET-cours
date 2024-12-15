1.Créer une BDD

Le fichier de configuration permet de se connecter à une BDD nommé "rpidev" avec comme user "root" et pas de mdp 
l'ip est 127.0.0.1

une fois fais, on peut alors vérifier si le code est fonctionnel grâce à la commande dotnet build (/mvc.csproj)

si le code est OK, on peut alors éxécuter le code à l'aide de dotnet run

On peut donc créer un étudiant avec le lien localhost:5237/Student/Add
on peut le modifier avec localhost:5237/Student/Edit
on peut le supprimer avec localhost:5237/Student/Delete

On peut donc créer un professeur avec le lien localhost:5237/Teacher/Add
on peut le modifier avec localhost:5237/Teacher/Edit
on peut le supprimer avec localhost:5237/Teacher/Delete

On peut également créer un compte avec localhost:5237/Account/Register
On peut également se connecter à l'aide de localhost:5237/Account/Login

2. Création d'événements 

Nous avons également le pouvoir de créér des évenements uniquement lorsqu'on est connecté avec un compte avec le role Teacher