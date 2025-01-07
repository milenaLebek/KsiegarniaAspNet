
# Księgarnia ASP.NET MVC

To jest aplikacja internetowa dla księgarni, napisana w ASP.NET MVC, z użyciem Entity Framework i bazy danych SQLite. Aplikacja pozwala na zarządzanie książkami, autorami oraz gatunkami książek. Zawiera panel administracyjny do dodawania, edytowania i usuwania książek, autorów i gatunków.

## Wymagania

Aby uruchomić projekt, musisz mieć zainstalowane następujące oprogramowanie:

- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet) lub wyższy
- [Visual Studio](https://visualstudio.microsoft.com/) lub [JetBrains Rider](https://www.jetbrains.com/rider/)
- [SQLite](https://www.sqlite.org/download.html) (jeśli nie masz, aplikacja może korzystać z wbudowanego pliku bazy danych)

## Instalacja

1. Sklonuj repozytorium na swoje lokalne urządzenie:

   ```bash
   git clone https://github.com/TwojaNazwaUzytkownika/ksiegarnia.git
   ```

2. Przejdź do katalogu projektu:

   ```bash
   cd ksiegarnia
   ```

3. Zainstaluj zależności:

   ```bash
   dotnet restore
   ```

4. Zbuduj projekt:

   ```bash
   dotnet build
   ```

5. Uruchom aplikację:

   ```bash
   dotnet run
   ```

6. Aplikacja powinna być dostępna pod adresem: `https://localhost:5001`

## Konfiguracja

### Łańcuch połączenia z bazą danych

W pliku `appsettings.json` znajduje się konfiguracja połączenia z bazą danych:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=./ksiegarnia.db"
}
```

Domyślnie aplikacja używa bazy danych SQLite przechowywanej w pliku `ksiegarnia.db`. Możesz dostosować tę konfigurację, zmieniając ścieżkę lub typ bazy danych (np. SQL Server).

### Testowi użytkownicy

Podczas pierwszego uruchomienia aplikacja utworzy dwóch użytkowników:

- **Admin**
  - Email: `admin@ksiegarnia.com`
  - Hasło: `Admin123!`
  - Rola: `Admin`

- **Użytkownik**
  - Email: `user@ksiegarnia.com`
  - Hasło: `User123!`
  - Rola: `User`

Te dane zostaną zapisane w bazie danych i będą dostępne w aplikacji. Użytkownik z rolą `Admin` ma dostęp do panelu administracyjnego, a użytkownik z rolą `User` ma dostęp do strony głównej.

## Opis działania aplikacji

### Strona Główna

Po wejściu na stronę główną (dostępną pod `/Home/Index`) aplikacja wyświetla listę książek, wraz z autorami i gatunkami. Użytkownicy mogą kliknąć na książkę, aby zobaczyć szczegóły.

### Panel Administracyjny

#### Zarządzanie Autorami
Aplikacja pozwala na dodawanie, edytowanie i usuwanie autorów książek w sekcji `/Author/`.

#### Zarządzanie Książkami
Zarządzanie książkami odbywa się w sekcji `/Book/`. Wymagane jest posiadanie roli `Admin`, aby dodać, edytować lub usunąć książki.

#### Zarządzanie Gatunkami
Gatunki książek można zarządzać w sekcji `/Genre/`. Tylko użytkownicy z rolą `Admin` mogą dodawać, edytować lub usuwać gatunki.

### Koszyk

Aplikacja zawiera prostą stronę `/Book/Cart`, która wyświetla koszyk, jednak ta funkcjonalność nie została zaimplementowana w tej wersji.

## Struktura Projektu

- `Controllers` – zawiera logikę kontrolerów MVC, takich jak `BookController`, `AuthorController` i `GenreController`.
- `Models` – zawiera modele danych, takie jak `Book`, `Author`, `Genre` oraz `User` (rozszerzający klasę `IdentityUser`).
- `Data` – zawiera konfigurację bazy danych i logikę inicjalizacji danych, w tym `ApplicationDbContext` oraz metodę `SeedData` do dodawania użytkowników i ról.
- `Views` – zawiera widoki Razor, które renderują HTML na stronie.

## Licencja

Ten projekt jest licencjonowany na zasadach [MIT License](LICENSE).
