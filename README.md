# Game_1
Нарубай побільше золота за 5 хв.

1. Щоб загрузити проект в Unity, потрібно спочатку створити клон репозиторія в GitHub.
2. Потім створити в UnityHub новий проект версій 2021.3.5f1 і додати до назви _1.
3. Відкрити новий проект, потім його закрити.
4. Всі файли з папки, що створить клон GitHub потрібно скопіювати в новий проект, який був створений в пункті 2 із заміною файлів.
5. Потім видалити папку клона і назвати папку проекта так як клон, тобто видалити _1
6. Потім в UnityHub зі списку видалити проект з _1, та добавити проект без _1
7. Потім відкрити проект в UnityHub. Він може не відкритися з першого разу, з другого разу він в мене відкрився, бо догружав namespace TMPro.
8. Коли вже відкриється проект в Unity, то потрібно відкрити сцену Main_2, бо вона використовуеться в скрипті EndMenu в методі 
public void ButtonRestartClick()
    {
        SceneManager.LoadScene("Main_2");
    }
