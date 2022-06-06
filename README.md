### Задача: 

Сделать web api для взаимодействия с базой данных, в которой хранятся данные о видеоиграх, реализовать CRUD операции с ней, а также метод для получения списка игр определённого жанра.
Информация о игре: название, студия разработчик, несколько жанров, которым соответствует игра.
Используя. NET core, entity framework.
Действуя согласно SOLID MVC MVVM.
Сделать минимум 3 слоя абстракций, а контроллеры "тонкими".

### Реализация
  Data access layer - src/Apricode.ApricodeGames.API/Data<br />
  Business logic layer - srcsrc/Apricode.ApricodeGames.API/Business<br />
  Presentation layer - srcsrc/Apricode.ApricodeGames.API/Controllers<br /><br />
CRUD операции сделаны для GameItem

Genre и DevelopmentStudio предопределены в бд
